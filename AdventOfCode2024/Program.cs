namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        773 79858 0 71 213357 2937 1 3998391
        """
            .Split(" ");
    private static string[] _realInput = InputLoader.Load(11, separator: " ");

    private static void Main(string[] args)
    {
        Day11.Part1(TestInput); 
        Day11.Part2(TestInput); 
    }
}