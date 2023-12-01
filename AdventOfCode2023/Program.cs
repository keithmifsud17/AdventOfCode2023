using AdventOfCode2023;
using CommandLine;
using System.Reflection;

var types = LoadVerbs();
await Parser.Default.ParseArguments(args, types)
    .WithNotParsed((_) => { })
    .WithParsedAsync(async o =>
    {
        if (o is ICommand c)
        {
            await c.ExecuteAsync();
        }
    });

static Type[] LoadVerbs() => Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.GetCustomAttribute<VerbAttribute>() != null)
    .ToArray();