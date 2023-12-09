namespace AdventOfCode2023.Tasks.Day5
{
    internal record SeedRange(long Start, long Counter)
    {
        public long End => Start + Counter - 1;
    }
}
