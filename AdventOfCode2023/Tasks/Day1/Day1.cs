using CommandLine;
using System.Text;

namespace AdventOfCode2023.Tasks.Day1
{
    [Verb("day1", aliases: new[] { "trebuchet" }, HelpText = "--- Day 1: Trebuchet?! ---")]
    internal class Day1 : ICommand
    {

        [Option('f', "file", Required = true, HelpText = "Input file to be processed.")]
        public required string InputFile { get; set; }

        public async ValueTask ExecuteAsync()
        {
            var lines = await File.ReadAllLinesAsync(InputFile);

            Console.WriteLine(lines.Sum(CalibrateLine));
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
