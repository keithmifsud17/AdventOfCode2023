namespace AdventOfCode2023.Tasks.Day9
{
    internal record Sequence(long[] Input)
    {
        public long Next => CalculateNextInput(Input);
        public long Previous => CalculateNextInput(Input.Reverse().ToArray());

        private static long CalculateNextInput(long[] input)
        {
            var difference = new long[input.Length - 1];
            for (int i = 0; i < difference.Length; i++)
            {
                difference[i] = input[i + 1] - input[i];
            }

            if (difference.All(x => x == 0)) return input[^1];

            var nestedDiff = CalculateNextInput(difference);

            return input[^1] + nestedDiff;
        }
    }
}
