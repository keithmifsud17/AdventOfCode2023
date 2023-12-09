using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day6
{
    internal class Day6B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var race = ParseRace(lines);

            int combinations = 0;

            for (int i = 1; i <= race.Time; i++)
            {
                if (i * (race.Time - i) > race.Distance) combinations++;
            }

            AnsiConsole.WriteLine("Combinations: {0}", combinations);

            return 0;
        }

        private static Race ParseRace(string[] lines)
        {
            var time = long.Parse(string.Join("", lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1)));
            var distance = long.Parse(string.Join("", lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1)));

            return new Race(time, distance);
        }
    }
}
