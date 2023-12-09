using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day3
{
    internal class Day3B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var elements = Day3Parser.ParseElements(lines);

            var numbers = elements.OfType<PartNumber>()
                .SelectMany(n => n.Positions.Select(p => (position: p, number: n)))
                .ToArray();

            var result = elements.OfType<GearRatioSymbol>()
                .Select(s =>
                {
                    if (s.Symbol == "*")
                    {
                        var parts = s.Neighbors
                            .Join(
                                numbers, 
                                x => x, 
                                y => y.position,
                                (x, y) => y.number)
                            .Distinct(ReferenceEqualityComparer.Instance);

                        if (parts.Count() == 2)
                        {
                            return parts.OfType<PartNumber>().Aggregate(1, (r, n) => r * n.Value);
                        }
                    }

                    return 0;
                });

            AnsiConsole.WriteLine("Gear Ratio: {0}", result.Sum(x => x));

            return 0;
        }
    }
}
