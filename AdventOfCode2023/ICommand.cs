namespace AdventOfCode2023
{
    internal interface ICommand
    {
        ValueTask ExecuteAsync();
    }
}
