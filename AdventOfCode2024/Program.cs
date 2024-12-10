namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        2333133121414131402
        """
            .Split("\n");
    private static string[] _realInput = InputLoader.Load(9, separator: "X");

    private static void Main(string[] args)
    {
        Day9.Part1(TestInput); 
        Day9.Part2(_realInput); 
    }
}