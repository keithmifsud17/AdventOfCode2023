using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day4
{
    internal class Day4 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var total = lines
                .Select(x =>
                {
                    var numbers = x.Split(':')[1].Split('|');
                    var winners = numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                    var myNumbers = numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                    var commons = winners.Intersect(myNumbers).Count();
                    return commons == 0 ? 0 : Math.Pow(2, commons - 1);
                })
                .Sum(x => x);

            AnsiConsole.WriteLine("Sum: {0}", total);

            return 0;
        }
    }
}
