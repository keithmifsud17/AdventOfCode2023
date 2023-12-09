using AdventOfCode2023;
using AdventOfCode2023.Tasks.Day1;
using AdventOfCode2023.Tasks.Day2;
using AdventOfCode2023.Tasks.Day3;
using AdventOfCode2023.Tasks.Day4;
using AdventOfCode2023.Tasks.Day5;
using AdventOfCode2023.Tasks.Day6;
using AdventOfCode2023.Tasks.Day7;
using AdventOfCode2023.Tasks.Day8;
using AdventOfCode2023.Tasks.Day9;
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

    config.AddBranch<FileInputSettings>("day5", day =>
    {
        day.AddCommand<Day5>("part1").WithDescription("--- Day 5: If You Give A Seed A Fertilizer Part One ---");
        day.AddCommand<Day5B>("part2").WithDescription("--- Day 5: If You Give A Seed A Fertilizer Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day6", day =>
    {
        day.AddCommand<Day6>("part1").WithDescription("--- Day 6: Wait For It Part One ---");
        day.AddCommand<Day6B>("part2").WithDescription("--- Day 6: Wait For It Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day7", day =>
    {
        day.AddCommand<Day7>("part1").WithDescription("--- Day 7: Camel Cards Part One ---");
        day.AddCommand<Day7B>("part2").WithDescription("--- Day 7: Camel Cards Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day8", day =>
    {
        day.AddCommand<Day8>("part1").WithDescription("--- Day 8: Haunted Wasteland Part One ---");
        day.AddCommand<Day8B>("part2").WithDescription("--- Day 8: Haunted Wasteland Part Two ---");
    });

    config.AddBranch<FileInputSettings>("day9", day =>
    {
        day.AddCommand<Day9>("part1").WithDescription("--- Day 9: Mirage Maintenance Part One ---");
        day.AddCommand<Day9B>("part2").WithDescription("--- Day 9: Mirage Maintenance Part Two ---");
    });
});

return await app.RunAsync(args);