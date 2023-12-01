using Spectre.Console;
using Spectre.Console.Cli;
using System.Text;

namespace AdventOfCode2023.Tasks.Day1
{
    internal class Day1 : AsyncCommand<Day1Settings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, Day1Settings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            AnsiConsole.WriteLine(lines.Sum(CalibrateLine));

            return 0;
        }

        private int CalibrateLine(string line)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    builder.Append(line[i]);
                    break;
                }
            }

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    builder.Append(line[i]);
                    break;
                }
            }

            return int.Parse(builder.ToString());
        }
    }
}
