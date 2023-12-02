using AdventOfCode2023;
using AdventOfCode2023.Tasks.Day1;
using AdventOfCode2023.Tasks.Day2;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
    config.AddBranch<FileInputSettings>("day1", day1 =>
    {
        day1.AddCommand<Day1>("part1").WithDescription("--- Day 1: Trebuchet?! Part One ---");
        day1.AddCommand<Day1B>("part2").WithDescription("--- Day 1: Trebuchet?! Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day2", day2 =>
    {
        day2.AddCommand<Day2>("part1").WithDescription("--- Day 2: Cube Conundrum Part One ---");
        day2.AddCommand<Day2B>("part2").WithDescription("--- Day 2: Cube Conundrum Part Two ---");
    });
});

return await app.RunAsync(args);