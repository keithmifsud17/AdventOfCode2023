using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day8
{
    internal class Day8 : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var instructions = Day8Parser.ParseInstructions(lines[0]);
            var nodes = Day8Parser.ParseNodes(lines.Skip(2));

            var current = instructions.First;
            var currentNode = "AAA";
            int steps = 0;
            while (true)
            {
                currentNode = nodes[currentNode][current!.Value];

                steps++;

                if (currentNode == "ZZZ")
                {
                    break;
                }

                current = current.Next ?? instructions.First;
            }

            AnsiConsole.WriteLine("Steps: {0}", steps);

            return 0;
        }
    }
}
