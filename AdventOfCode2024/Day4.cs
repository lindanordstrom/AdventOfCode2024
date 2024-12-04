namespace AdventOfCode2024;

public static class Day4
{
    public static void Part1(string[] input)
    {
        var sum = 0;
        for (var row = 0; row < input.Length; row++)
        {
            for (var i = 0; i < input[row].Length; i++)
            {
                if (i < input[row].Length - 3 && 
                    ((input[row][i] == 'X' && input[row][i + 1] == 'M' && input[row][i + 2] == 'A' && input[row][i + 3] == 'S') || 
                    (input[row][i] == 'S' && input[row][i + 1] == 'A' && input[row][i + 2] == 'M' && input[row][i + 3] == 'X')))
                {
                    sum++;
                }
                
                if (row < input.Length - 3 && 
                    ((input[row][i] == 'X' && input[row+1][i] == 'M' && input[row+2][i] == 'A' && input[row+3][i] == 'S') || 
                    (input[row][i] == 'S' && input[row+1][i] == 'A' && input[row+2][i] == 'M' && input[row+3][i] == 'X')))
                {
                    sum++;
                }
                
                if (row < input.Length -3 && i < input[row].Length - 3 &&
                    ((input[row][i] == 'X' && input[row+1][i+1] == 'M' && input[row+2][i+2] == 'A' && input[row+3][i+3] == 'S') || 
                     (input[row][i] == 'S' && input[row+1][i+1] == 'A' && input[row+2][i+2] == 'M' && input[row+3][i+3] == 'X')))
                {
                    sum++;
                }
                
                if ( row > 2 && i < input[row].Length - 3 &&
                    ((input[row][i] == 'X' && input[row-1][i+1] == 'M' && input[row-2][i+2] == 'A' && input[row-3][i+3] == 'S') || 
                     (input[row][i] == 'S' && input[row-1][i+1] == 'A' && input[row-2][i+2] == 'M' && input[row-3][i+3] == 'X')))
                {
                    sum++;
                }
            }
        }
        Console.WriteLine(sum);
    }
    
    public static void Part2(string[] input)
    {
        var sum = 0;
        for (var row = 1; row < input.Length - 1; row++)
        {
            for (var i = 1; i < input[row].Length - 1; i++)
            {
                if (((input[row][i] == 'A' && input[row-1][i-1] == 'M' && input[row+1][i+1] == 'S') || 
                     (input[row][i] == 'A' && input[row-1][i-1] == 'S' && input[row+1][i+1] == 'M')) &&
                    ((input[row][i] == 'A' && input[row-1][i+1] == 'M' && input[row+1][i-1] == 'S') || 
                     (input[row][i] == 'A' && input[row-1][i+1] == 'S' && input[row+1][i-1] == 'M')))
                {
                    sum++;
                }
            }
        }
        Console.WriteLine(sum);
    }
}