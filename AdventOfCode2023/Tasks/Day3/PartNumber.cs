using Spectre.Console;

namespace AdventOfCode2023.Tasks.Day3
{
    public record PartNumber(int Value, int Length, int X, int Y) : GearRatioElement(X, Y)
    {
        private readonly Lazy<IEnumerable<GearRatioElement>> _lazyPositions = new(() =>
            Enumerable.Range(0, Length)
                .Select(i => new GearRatioElement(X, Y + i)));

        public IEnumerable<GearRatioElement> Positions => _lazyPositions.Value;
    }
}
