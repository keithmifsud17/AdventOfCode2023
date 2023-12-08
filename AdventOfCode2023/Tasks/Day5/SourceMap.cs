using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Tasks.Day5
{
    internal class SourceMapCollection
    {
        private readonly List<SourceMap> maps = [];

        public void AddSourceMap(SourceMap sourceMap) => maps.Add(sourceMap);

        public long Map(string source, string destination, long sourceId)
        {
            if (maps.SingleOrDefault(x => x.Source == source && x.Destination == destination) is { } map)
            {
                return map.Map(sourceId);
            }

            map = maps.Single(x => x.Source == source);

            return Map(map.Destination, destination, map.Map(sourceId));
        }
    }

    internal record SourceMap(string Source, string Destination)
    {
        private List<Map> maps = [];

        public void AddMap(Map map) => maps = maps.Append(map).OrderBy(x => x.SourceStart).ToList();

        public long Map(long sourceId)
        {
            foreach (var map in maps)
            {
                if (map.TryGetDestination(sourceId, out var destinationId)) 
                    return destinationId.Value;
            }

            return sourceId;
        }
    }
    internal record Map(long SourceStart, long DestinationStart, long Counter)
    {
        public bool TryGetDestination(long sourceId, [NotNullWhen(true)] out long? destinationId)
        {
            if (sourceId >= SourceStart && sourceId < SourceStart + Counter)
            {
                destinationId = sourceId + (DestinationStart - SourceStart);
                return true;
            }

            destinationId = null;
            return false;
        }
    }
}
