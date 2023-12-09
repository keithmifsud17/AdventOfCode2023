using System.Text.RegularExpressions;

namespace AdventOfCode2023.Tasks.Day8
{
    internal static partial class Day8Parser
    {
        public static Dictionary<string, Dictionary<Direction, string>> ParseNodes(IEnumerable<string> lines) => lines
            .Select(l => NodeRegex().Match(l))
            .Where(m => m.Success)
            .ToDictionary(
                keySelector: match => match.Groups["node"].Value,
                elementSelector: match => new Dictionary<Direction, string>()
                {
                    { Direction.Left, match.Groups["left"].Value },
                    { Direction.Right, match.Groups["right"].Value },
                });

        public static LinkedList<Direction> ParseInstructions(string line) => new(line.Select(x => x == 'L' ? Direction.Left : Direction.Right));

        [GeneratedRegex(@"^(?'node'\w{3}) = \((?'left'\w{3}), (?'right'\w{3})\)$")]
        private static partial Regex NodeRegex();
    }
}
