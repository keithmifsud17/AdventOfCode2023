using AdventOfCode2023;
using AdventOfCode2023.Tasks.Day1;
using AdventOfCode2023.Tasks.Day2;
using AdventOfCode2023.Tasks.Day3;
using AdventOfCode2023.Tasks.Day4;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
    config.AddBranch<FileInputSettings>("day1", day =>
    {
        day.AddCommand<Day1>("part1").WithDescription("--- Day 1: Trebuchet?! Part One ---");
        day.AddCommand<Day1B>("part2").WithDescription("--- Day 1: Trebuchet?! Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day2", day =>
    {
        day.AddCommand<Day2>("part1").WithDescription("--- Day 2: Cube Conundrum Part One ---");
        day.AddCommand<Day2B>("part2").WithDescription("--- Day 2: Cube Conundrum Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day3", day =>
    {
        day.AddCommand<Day3>("part1").WithDescription("--- Day 3: Gear Ratios Part One ---");
        day.AddCommand<Day3B>("part2").WithDescription("--- Day 3: Gear Ratios Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day4", day =>
    {
        day.AddCommand<Day4>("part1").WithDescription("--- Day 4: Scratchcards Part One ---");
        day.AddCommand<Day4B>("part2").WithDescription("--- Day 4: Scratchcards Part Two ---");
    });
});

return await app.RunAsync(args);