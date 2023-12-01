using Spectre.Console.Cli;

namespace AdventOfCode2023.Tasks.Day1
{
    internal class Day1Settings : CommandSettings
    {
        [CommandArgument(0, "<file>")]
        public required string InputFile { get; set; }
    }
}
