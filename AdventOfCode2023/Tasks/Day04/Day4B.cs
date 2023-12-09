using Spectre.Console;
using Spectre.Console.Cli;
using System;

namespace AdventOfCode2023.Tasks.Day4
{
    internal class Day4B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var tickets = new int[lines.Length];

            var total = lines
                .Aggregate(new Data(new int[lines.Length], 0, 0), (data, input) =>
                {
                    var (tickets, index, sum) = data;

                    var numbers = input.Split(':')[1].Split('|');
                    var winners = numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                    var myNumbers = numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                    var score = winners.Intersect(myNumbers).Count();

                    foreach (var x in Enumerable.Range(index + 1, score))
                    {
                        if (x < lines.Length)
                            tickets[x] += tickets[index] + 1;
                    }

                    return new Data(tickets, index + 1, sum + tickets[index] + 1);
                }).Sum;

            AnsiConsole.WriteLine("Sum: {0}", total);

            return 0;
        }

        private record Data(int[] Tickets, int Index, int Sum);
    }
}
