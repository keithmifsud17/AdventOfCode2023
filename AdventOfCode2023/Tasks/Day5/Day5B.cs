using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day5
{
    internal class Day5B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var seeds = lines[0].Split(' ').Skip(1).Select(long.Parse);

            var maps = Day5Parser.ParseSourceMap(lines);

            var min = seeds.Select(seed => maps.Map("seed", "location", seed)).Min();

            AnsiConsole.WriteLine("Lowest location: {0}", min);

            return 0;
        }
    }
}
