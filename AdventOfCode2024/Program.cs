namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        
        """
            .Split(" ");

    private static string[] _realInput = InputLoader.Load(1, separator: " ");

    private static void Main(string[] args)
    {
        Day1.Part1(TestInput);
        Day1.Part2(TestInput);
    }
}