namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        MMMSXXMASM
        MSAMXMSMSA
        AMXSXMAAMM
        MSAMASMSMX
        XMASAMXAMM
        XXAMMXXAMA
        SMSMSASXSS
        SAXAMASAAA
        MAMMMXMMMM
        MXMXAXMASX
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(4, separator: "\n");

    private static void Main(string[] args)
    {
        Day4.Part1(_realInput); 
        Day4.Part2(_realInput); 
    }
}