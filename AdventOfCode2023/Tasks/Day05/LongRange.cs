namespace AdventOfCode2023.Tasks.Day5
{
    internal record LongRange(long Start, long End)
    {
        public long Count => End - Start + 1;
    }
}
