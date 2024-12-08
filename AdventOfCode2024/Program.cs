namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        ....#.....
        .........#
        ..........
        ..#.......
        .......#..
        ..........
        .#..^.....
        ........#.
        #.........
        ......#...
        """
            .Split("\n");

    private static string[] _realInput = InputLoader.Load(6, separator: "\n");

    private static void Main(string[] args)
    {
        Day6.Part1(_realInput); 
        Day6.Part2(TestInput); 
    }
}