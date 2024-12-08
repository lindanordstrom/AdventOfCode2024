namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        190: 10 19
        3267: 81 40 27
        83: 17 5
        156: 15 6
        7290: 6 8 6 15
        161011: 16 10 13
        192: 17 8 14
        21037: 9 7 18 13
        292: 11 6 16 20
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(7, separator: "\n");

    private static void Main(string[] args)
    {
        Day7.Part1(_realInput);
        Day7.Part2(_realInput); 
    }
}