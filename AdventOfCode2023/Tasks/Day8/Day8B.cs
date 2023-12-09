using Spectre.Console;
using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day8
{
    internal class Day8B : AsyncCommand<FileInputSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileInputSettings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            var instructions = Day8Parser.ParseInstructions(lines[0]);
            var nodes = Day8Parser.ParseNodes(lines.Skip(2));

            var current = instructions.First;
            var currentNodes = nodes.Keys.Where(x => x[^1] == 'A').ToArray();
            List<long> results = [];
            int steps = 0;
            while (true)
            {
                currentNodes = currentNodes.Select(currentNode => nodes[currentNode][current!.Value]).ToArray();

                steps++;

                int matches = currentNodes.Count(x => x[^1] == 'Z');
                if (matches > 0)
                {
                    results.AddRange(Enumerable.Range(0, matches).Select(_ => (long)steps));
                    currentNodes = currentNodes.Where(x => x[^1] != 'Z').ToArray();
                }

                if (currentNodes.Length == 0) break;

                current = current!.Next ?? instructions.First;
            }

            AnsiConsole.WriteLine("Steps: {0}", results.LeastCommonMultiple());

            return 0;
        }
    }
}
