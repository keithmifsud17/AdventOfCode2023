using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day6
{
    internal class Day6 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var races = ParseRaces(lines);

            int combinations = races.Select(race =>
            {
                int combinations = 0;

                for (int i = 1; i <= race.Time; i++)
                {
                    if (i * (race.Time - i) > race.Distance) combinations++;   
                }

                return combinations;
            }).Aggregate(1, (t, c) => t * c);

            AnsiConsole.WriteLine("Combinations: {0}", combinations);

            return 0;
        }

        private static IEnumerable<Race> ParseRaces(string[] lines)
        {
            var times = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse);
            var distances = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse);

            return times.Select((t, i) => new Race(t, distances.ElementAt(i)));
        }
    }
}
