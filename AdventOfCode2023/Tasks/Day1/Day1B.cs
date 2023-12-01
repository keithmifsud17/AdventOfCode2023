using CommandLine;
using System.Text;

namespace AdventOfCode2023.Tasks.Day1
{
    [Verb("day1B", aliases: new[] { "trebuchetB", "trebuchet_part_2" }, HelpText = "--- Day 1: Trebuchet?! Part Two ---")]
    internal class Day1B : ICommand
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

        [Option('f', "file", Required = true, HelpText = "Input file to be processed.")]
        public required string InputFile { get; set; }

        public async ValueTask ExecuteAsync()
        {
            var lines = await File.ReadAllLinesAsync(InputFile);

            Console.WriteLine(lines.Sum(CalibrateLine));
        }

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

            Console.WriteLine($"{line}, {newLine}, {builder}");

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
    }
}
