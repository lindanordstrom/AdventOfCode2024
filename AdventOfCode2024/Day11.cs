using System.Numerics;

namespace AdventOfCode2024;

public static class Day11
{
    public static void Part1(string[] input)
    {
        var sum = input.Sum(number => CalculateNumbers(BigInteger.Parse(number), 25));
        sum += input.Length;
        Console.WriteLine(sum);
    }
    
    public static void Part2(string[] input)
    {
        var sum = input.Sum(number => CalculateNumbers(BigInteger.Parse(number), 75));
        sum += input.Length;
        Console.WriteLine(sum);
    }
    
    private static int CalculateNumbers(BigInteger number, int times, int currentIteration = 0)
    {
        var sum = 0;
        if (currentIteration == times)
            return sum;
        
        var numberString = number.ToString();
        if (number == 0)
        {
            sum += CalculateNumbers(1, times, currentIteration: currentIteration + 1);
        }
        else if (numberString.Length % 2 == 0)
        {
            var numberOfCharacters = numberString.Length / 2;
            var firstHalf = numberString[..numberOfCharacters];
            var secondHalf = numberString[numberOfCharacters..];
            sum += CalculateNumbers(BigInteger.Parse(secondHalf), times, currentIteration: currentIteration + 1);
            sum += CalculateNumbers(BigInteger.Parse(firstHalf), times, currentIteration: currentIteration + 1);
            sum += 1;
        }
        else
        {
            sum += CalculateNumbers(number * 2024, times, currentIteration: currentIteration + 1);
        }
        return sum;
    }
    //
    // private static int CalculateNumbers(string input, int times)
    // {
    //     var numbers = new List<BigInteger> { BigInteger.Parse(input) };
    //     for (var count = 1; count <= times; count++)
    //     {
    //         for (var i = 0; i < numbers.Count; i++)
    //         {
    //             var numberString = numbers[i].ToString();
    //             if (numbers[i] == 0)
    //             {
    //                 numbers[i] = 1;
    //             }
    //             else if (numberString.Length % 2 == 0)
    //             {
    //                 var numberOfCharacters = numberString.Length / 2;
    //                 var firstHalf = numberString[..numberOfCharacters];
    //                 var secondHalf = numberString[numberOfCharacters..];
    //                 numbers[i] = BigInteger.Parse(secondHalf);
    //                 numbers.Insert(i, BigInteger.Parse(firstHalf));
    //                 i++;
    //             }
    //             else
    //             {
    //                 numbers[i] *= 2024;
    //             }
    //         }
    //     }
    //     return numbers.Count;
    // }
}
