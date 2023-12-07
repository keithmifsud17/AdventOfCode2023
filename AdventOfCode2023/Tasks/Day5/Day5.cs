using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day5
{
    internal class Day5 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var seeds = lines[0].Split(' ').Skip(1).Select(long.Parse);

            var maps = new Dictionary<(string Source, string Destination), List<Func<long, long>>>();
            string currentSource = "";
            string currentDestination = "";
            for (int i = 2; i < lines.Length; i++)
            {
                if (lines[i].Contains("map"))
                {
                    var map = lines[i][..^5].Split('-');
                    currentSource = map[0];
                    currentDestination = map[2];

                    maps.Add((currentSource, currentDestination), []);
                }
                else if (lines[i].Length > 0)
                {
                    var map = lines[i].Split(' ').Select(long.Parse);
                    long source = map.ElementAt(1);
                    long destination = map.ElementAt(0);
                    long counter = map.ElementAt(2);

                    maps[(currentSource, currentDestination)].Add(x =>
                    {
                        if (x >= source && x <= source + counter)
                        {
                            return x + (destination - source);
                        }

                        return long.MinValue;
                    });
                }
            }

            var min = seeds.Select(seed => Map(maps, "seed", "location", seed)).Min();

            AnsiConsole.WriteLine("Lowest location: {0}", min);

            return 0;
        }

        private static long Map(Dictionary<(string Source, string Destination), List<Func<long, long>>> maps, string source, string destination, long sourceId)
        {
            if (maps.ContainsKey((source, destination)))
            {
                var map = maps[(source, destination)];
                var value = map.Select(x => x(sourceId)).Max();
                return value > long.MinValue ? value : sourceId;
            }
            else
            {
                var map = maps.Single(x => x.Key.Source == source);
                var value = map.Value.Select(x => x(sourceId)).Max();
                return Map(maps, map.Key.Destination, destination, value > long.MinValue ? value : sourceId);
            }
        }
    }
}
