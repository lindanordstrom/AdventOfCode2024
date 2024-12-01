namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        3   4
        4   3
        2   5
        1   3
        3   9
        3   3
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(1, separator: "\n");

    private static void Main(string[] args)
    {
        Day1.Part1(_realInput);
        Day1.Part2(_realInput);
    }
}