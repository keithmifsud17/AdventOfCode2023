using AdventOfCode2023.Tasks.Day1;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
    config.AddBranch("day1", day1 =>
    {
        day1.AddCommand<Day1>("part1").WithDescription("--- Day 1: Trebuchet?! Part One ---");
        day1.AddCommand<Day1B>("part2").WithDescription("--- Day 1: Trebuchet?! Part Two ---");
    });
});

return await app.RunAsync(args);