namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(3, separator: "\n");

    private static void Main(string[] args)
    {
        Day3.Part1(TestInput); 
        Day3.Part2(_realInput); 
    }
}