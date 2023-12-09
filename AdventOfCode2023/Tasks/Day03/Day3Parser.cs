using System.Text.RegularExpressions;

namespace AdventOfCode2023.Tasks.Day3
{
    internal static partial class Day3Parser
    {
        public static IEnumerable<GearRatioElement> ParseElements(string[] lines)
        {
            var regex = RegexParser();

            return lines.SelectMany((line, row) =>
                regex.Matches(line)
                .Cast<Match>()
                .Select<Match, GearRatioElement>(match =>
                {
                    if (match.Groups["number"].Success)
                    {
                        return new PartNumber(int.Parse(match.Value), match.Value.Length, row, match.Index);
                    }

                    return new GearRatioSymbol(match.Value, row, match.Index);
                }));
        }

        [GeneratedRegex(@"(?'number'[\d]+)|(?'symbol'[^\d\.\r\n])")]
        private static partial Regex RegexParser();
    }
}