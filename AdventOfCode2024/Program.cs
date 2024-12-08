namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        20: 1 2 3 4 5 6
        21: 1 2 3 4 5 6
        90: 1 2 3 4 5 6
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(7, separator: "\n");

    private static void Main(string[] args)
    {
        Day7.Part1(_realInput);
        Day7.Part2(TestInput); 
    }
}