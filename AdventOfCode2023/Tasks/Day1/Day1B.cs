using Spectre.Console;
using Spectre.Console.Cli;
using System.Text;

namespace AdventOfCode2023.Tasks.Day1
{
    internal class Day1B : AsyncCommand<Day1Settings>
    {
        private static readonly string[] _digits =
        [
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
        ];

        private int CalibrateLine(string line)
        {
            var newLine = SanitizeLine(line);

            var builder = new StringBuilder();

            for (int i = 0; i < newLine.Length; i++)
            {
                if (char.IsDigit(newLine[i]))
                {
                    builder.Append(newLine[i]);
                    break;
                }
            }

            for (int i = newLine.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(newLine[i]))
                {
                    builder.Append(newLine[i]);
                    break;
                }
            }

            AnsiConsole.WriteLine($"{line}, {newLine}, {builder}");

            return int.Parse(builder.ToString());
        }

        private static string SanitizeLine(string line)
        {
            int[] indices = new int[9];

            for (int i = 0; i < line.Length; i++)
            {
                for (int j = 0; j < indices.Length; j++)
                {
                    if (line[i] == _digits[j][indices[j]])
                    {
                        indices[j]++;

                        if (indices[j] == _digits[j].Length)
                        {
                            var builder = new StringBuilder(line[..(i - indices[j] + 1)]);
                            builder.Append(j + 1);
                            builder.Append(line[i..]);

                            return SanitizeLine(builder.ToString());
                        }
                    }
                    else if (indices[j] > 0)
                    {
                        indices[j] = 0;
                        j--;
                    }
                }
            }

            return line;
        }

        public override async Task<int> ExecuteAsync(CommandContext context, Day1Settings settings)
        {
            var lines = await File.ReadAllLinesAsync(settings.InputFile);

            AnsiConsole.WriteLine(lines.Sum(CalibrateLine));

            return 0;
        }
    }
}
