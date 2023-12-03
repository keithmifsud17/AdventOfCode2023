namespace AdventOfCode2023.Tasks.Day3
{
    public record GearRatioSymbol(string Symbol, int X, int Y) : GearRatioElement(X, Y)
    {
        private readonly Lazy<IEnumerable<GearRatioElement>> _lazyNeighbors = new(() => [
            new GearRatioElement(X - 1, Y - 1),
            new GearRatioElement(X - 1, Y),
            new GearRatioElement(X - 1, Y + 1),
            new GearRatioElement(X, Y - 1),
            new GearRatioElement(X, Y + 1),
            new GearRatioElement(X + 1, Y - 1),
            new GearRatioElement(X + 1, Y),
            new GearRatioElement(X + 1, Y + 1),
        ]);

        public IEnumerable<GearRatioElement> Neighbors => _lazyNeighbors.Value;
    }
}
