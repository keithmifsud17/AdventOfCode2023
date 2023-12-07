using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.DaySample
{
    internal class DaySampleB : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            AnsiConsole.WriteLine("");

            return 0;
        }
    }
}
