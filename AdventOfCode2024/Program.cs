namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        7 6 4 2 1
        1 2 7 8 9
        9 7 6 2 1
        1 3 2 4 5
        8 6 4 4 1
        1 3 6 7 9
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(2, separator: "\n");

    private static void Main(string[] args)
    {
        Day2.Part1(_realInput);
        Day2.Part2(_realInput);
    }
}