using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day2
{
    internal class Day2B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var games = Day2Parser.ParseGames(lines);

            AnsiConsole.WriteLine("Powers: {0}", games
                .Aggregate(0, (b, g) =>
                {
                    var red = g.Bags.Where(x => x.Red > 0).Max(x => x.Red);
                    var blue = g.Bags.Where(x => x.Blue > 0).Max(x => x.Blue);
                    var green = g.Bags.Where(x => x.Green > 0).Max(x => x.Green);

                    return b + (red * blue * green);
                }));

            return 0;
        }
    }
}
