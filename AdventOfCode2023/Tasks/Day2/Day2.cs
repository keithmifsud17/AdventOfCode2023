using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day2
{
    internal class Day2 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var games = Day2Parser.ParseGames(lines);

            AnsiConsole.WriteLine("Sum: {0}", games
                .Where(x => x.Bags.All(b => b.Red <= 12 && b.Green <= 13 && b.Blue <= 14))
                .Sum(x => x.Id));

            return 0;
        }
    }
}
