using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public static class Day3
{
    public static void Part1(string[] input)
    {
        Console.WriteLine(SumFromBlock(input.First()));
    }
    
    public static void Part2(string[] input)
    {
        var line = string.Join("", input);
        line = line.Insert(line.Length, "don't()").Insert(0, "do()");
        var regex = new Regex(@"do\(\)(.*?)don't\(\)");
        var matches = regex.Matches(line).Select(m => m.Groups[0].Value).ToList();
        Console.WriteLine(matches.Sum(SumFromBlock));
    }
    
    private static int SumFromBlock(string s)
    {
        var regex = new Regex(@"mul\((\d+),(\d+)\)");
        var matches = regex.Matches(s)
            .Select(m => (int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value)));
        return matches.Sum(match => match.Item1 * match.Item2);
    }
}