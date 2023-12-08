using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day7
{
    internal class Day7 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var games = lines.Select(line =>
            {
                var elements = line.Split(' ');

                return new Game(elements[0], int.Parse(elements[1]));
            });

            var totalWinnings = games
                .OrderBy(g => g.Scores.ElementAt(0))
                .ThenBy(g => g.Scores.ElementAt(1))
                .ThenBy(g => g.Scores.ElementAt(2))
                .ThenBy(g => g.Scores.ElementAt(3))
                .ThenBy(g => g.Scores.ElementAt(4))
                .Select((g, i) => g.Winnings * (i + 1))
                .Sum();

            AnsiConsole.WriteLine("Total Winnings {0}", totalWinnings);

            return 0;
        }
    }
}
