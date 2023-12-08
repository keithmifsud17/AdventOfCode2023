namespace AdventOfCode2023.Tasks.Day5
{
    internal static class Day5Parser
    {
        public static SourceMapCollection ParseSourceMap(string[] lines)
        {
            var maps = new SourceMapCollection();

            SourceMap currentSourceMap = null!;
            for (int i = 2; i < lines.Length; i++)
            {
                if (lines[i].Contains("map"))
                {
                    var map = lines[i][..^5].Split('-');
                    currentSourceMap = new SourceMap(map[0], map[2]);
                    maps.AddSourceMap(currentSourceMap);
                }
                else if (lines[i].Length > 0)
                {
                    var map = lines[i].Split(' ').Select(long.Parse);
                    long source = map.ElementAt(1);
                    long destination = map.ElementAt(0);
                    long counter = map.ElementAt(2);

                    currentSourceMap.AddMap(new(source, destination, counter));
                }
            }

            return maps;
        }
    }
}
