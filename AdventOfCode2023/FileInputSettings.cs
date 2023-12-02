using Spectre.Console.Cli;

namespace AdventOfCode2023
{
    internal class FileInputSettings : CommandSettings
    {
        [CommandArgument(0, "<file>")]
        public required string InputFile { get; set; }
    }
}
