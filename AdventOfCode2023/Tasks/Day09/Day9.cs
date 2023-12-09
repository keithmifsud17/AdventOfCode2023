using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day9
{
    internal class Day9 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var sum = lines
                .Select(line => line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse))
                .Select(sequence => new Sequence(sequence.ToArray()))
                .Sum(sequence => sequence.Next);

            AnsiConsole.WriteLine("Next input sum: {0}", sum);

            return 0;
        }
    }
}
