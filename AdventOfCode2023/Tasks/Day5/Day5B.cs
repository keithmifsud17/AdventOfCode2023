using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day5
{
    internal partial class Day5B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var seeds = Day5Parser.ParseSeeds(lines[0].Split(' ').Skip(1).Select(long.Parse).ToArray())
                .OrderBy(x => x.Start)
                .ToList();

            var maps = Day5Parser.ParseSourceMap(lines);

            var x = maps.Map("seed", "location", new LongRange(81, 83)).ToArray();

            var ranges = seeds
                .SelectMany(seedRange => maps.Map("seed", "location", new LongRange(seedRange.Start, seedRange.End)));
                
            var min = ranges
                .MinBy(x => x.Start)
                !.Start;

            AnsiConsole.WriteLine("Lowest location: {0}", min);

            return 0;
        }
    }
}
