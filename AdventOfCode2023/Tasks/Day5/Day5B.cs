using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day5
{
    internal class Day5B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var seeds = ParseSeeds(lines[0].Split(' ').Skip(1).Select(long.Parse).ToArray())
                .OrderBy(x => x.Start)
                .ToList();

            var maps = Day5Parser.ParseSourceMap(lines);

            IEnumerable<long> MapRange(SeedRange seed)
            {
                for (long i = seed.Start; i <= seed.End; i++)
                {
                    yield return maps.Map("seed", "location", i);
                }
            };

            var min = seeds
                .SelectMany(MapRange)                
                .Min();

            AnsiConsole.WriteLine("Lowest location: {0}", min);

            return 0;
        }

        private static IEnumerable<SeedRange> ParseSeeds(long[] list)
        {
            for (int i = 0; i < list.Length; i += 2)
            {
                yield return new SeedRange(list[i], list[i + 1]);
            }
        }

        internal record SeedRange(long Start, long Counter) 
        {
            public long End => Start + Counter - 1;
        }
    }
}
