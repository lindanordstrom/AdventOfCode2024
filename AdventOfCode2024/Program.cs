﻿namespace AdventOfCode2024;

internal static class Program
{
    private static string[] TestInput => 
        """
        Button A: X+94, Y+34
        Button B: X+22, Y+67
        Prize: X=8400, Y=5400
        
        Button A: X+26, Y+66
        Button B: X+67, Y+21
        Prize: X=12748, Y=12176
        
        Button A: X+17, Y+86
        Button B: X+84, Y+37
        Prize: X=7870, Y=6450
        
        Button A: X+69, Y+23
        Button B: X+27, Y+71
        Prize: X=18641, Y=10279
        """
            .Split("\n\n");
    private static string[] _realInput = InputLoader.Load(13, separator: "\n\n");

    private static void Main(string[] args)
    {
        Day13.Part1(_realInput);
        Day13.Part2(_realInput); 
    }
}