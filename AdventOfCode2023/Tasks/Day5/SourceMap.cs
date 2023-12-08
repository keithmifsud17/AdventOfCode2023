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

        public IEnumerable<LongRange> Map(string source, string destination, LongRange sourceRange)
        {
            if (maps.SingleOrDefault(x => x.Source == source && x.Destination == destination) is { } map)
            {
                return map.Map(sourceRange);
            }

            map = maps.Single(x => x.Source == source);

            var destinationRange = map.Map(sourceRange).ToArray();

            return destinationRange.SelectMany(r => Map(map.Destination, destination, r).ToArray());
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

        internal IEnumerable<LongRange> Map(LongRange sourceRange)
        {
            List<LongRange> ranges = [];
            List<LongRange> remaining = [sourceRange];
            foreach (var map in maps)
            {
                List<LongRange> newRemaining = [];
                foreach (var r in remaining)
                {
                    var result = map.MapDestinations(r);

                    if (result.Range != null)
                    {
                        ranges.Add(result.Range);
                    }
                    newRemaining.AddRange(result.Remaining);
                }

                remaining = newRemaining;
                if (newRemaining.Count == 0) break;
            }

            return ranges.Concat(remaining);
        }
    }
    internal record Map(long SourceStart, long DestinationStart, long Counter)
    {
        private readonly LongRange MapSourceRange = new(SourceStart, SourceStart + Counter - 1);
        private readonly LongRange MapDestinationRange = new(DestinationStart, DestinationStart + Counter - 1);

        public bool TryGetDestination(long sourceId, [NotNullWhen(true)] out long? destinationId)
        {
            if (sourceId >= SourceStart && sourceId < SourceStart + Counter)
            {
                destinationId = MapDestination(sourceId);
                return true;
            }

            destinationId = null;
            return false;
        }

        public MapDestinationResult MapDestinations(LongRange sourceRange)
        {
            if (MapSourceRange.Start <= sourceRange.Start && MapSourceRange.End >= sourceRange.End)
            {
                return new(new(MapDestination(sourceRange.Start), MapDestination(sourceRange.End)), []);
            }
            else if (MapSourceRange.Start > sourceRange.Start && MapSourceRange.End < sourceRange.End)
            {
                return new(
                    MapDestinationRange, 
                    [
                        new(sourceRange.Start, MapSourceRange.Start - 1),
                        new(MapSourceRange.End + 1, sourceRange.End)
                    ]);
            }
            else if (MapSourceRange.Start > sourceRange.Start && MapSourceRange.End >= sourceRange.End && MapSourceRange.Start <= sourceRange.End)
            {
                return new(
                    new(MapDestination(MapSourceRange.Start), MapDestination(sourceRange.End)),
                    [
                        new(sourceRange.Start, MapSourceRange.Start - 1)
                    ]);
            }
            else if (MapSourceRange.Start <= sourceRange.Start && MapSourceRange.End < sourceRange.End && MapSourceRange.End >= sourceRange.Start)
            {
                return new(
                    new(MapDestination(sourceRange.Start), MapDestination(MapSourceRange.End)),
                    [
                        new(MapSourceRange.End + 1, sourceRange.End)
                    ]);
            }

            return new(null, [ sourceRange ]);
        }

        private long MapDestination(long sourceId) => sourceId + (DestinationStart - SourceStart);
    }

    internal record MapDestinationResult(LongRange? Range, IEnumerable<LongRange> Remaining);
}
