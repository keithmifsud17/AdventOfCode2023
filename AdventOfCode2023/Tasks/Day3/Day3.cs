using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day3
{
    internal class Day3 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var elements = Day3Parser.ParseElements(lines);

            var symbolNeighbors = elements.OfType<GearRatioSymbol>().SelectMany(s => s.Neighbors).ToArray();

            var groups = elements.OfType<PartNumber>()
                .Where(n => n.Positions.Intersect(symbolNeighbors).Any());

            AnsiConsole.WriteLine("Sum: {0}", groups.Sum(x => x.Value));

            return 0;
        }
    }
}
