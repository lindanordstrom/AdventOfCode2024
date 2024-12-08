using System.Numerics;

namespace AdventOfCode2024;

public static class Day7
{
    public static void Part1(string[] input)
    {
        Console.WriteLine(CalculateSum(input));
    }
    
    public static void Part2(string[] input)
    {
        Console.WriteLine(CalculateSum(input));
    }
    
    private static BigInteger CalculateSum(string[] input)
    {
        BigInteger sum = 0;
        foreach (var line in input)
        {
            var parts = line.Split(": ");
            var testValue = BigInteger.Parse(parts[0]);
            var numbers = parts[1].Split(" ").Select(BigInteger.Parse).ToList();

            if (CheckIfPossible(numbers.ToArray(), testValue, true))
                sum += testValue;
        }
        return sum;
    }
    
    private static bool CheckIfPossible(BigInteger[] numbers, BigInteger testValue, bool useConcatenation = false)
    {
        if (numbers.Length == 1)
            return numbers[0] == testValue;
        
        var sumOfNumbers = numbers.Aggregate((a, b) => a + b);
        var productOfNumbers = numbers.Aggregate((a, b) => a * b);
            
        if (sumOfNumbers == testValue || productOfNumbers == testValue)
            return true;
        
        var addedNumbers = new List<BigInteger> { numbers[0] + numbers[1] } ;
        addedNumbers.AddRange(numbers.Skip(2));
        var multipliedNumbers = new List<BigInteger> { numbers[0] * numbers[1] } ;
        multipliedNumbers.AddRange(numbers.Skip(2));
        
        var concatenatedNumbersPossible = false;
        if (useConcatenation)
        {
            var concatenatedNumbers = new List<BigInteger> { BigInteger.Parse(numbers[0].ToString() + numbers[1]) } ;
            concatenatedNumbers.AddRange(numbers.Skip(2));
            concatenatedNumbersPossible = CheckIfPossible(concatenatedNumbers.ToArray(), testValue, useConcatenation);
        }
        return CheckIfPossible(addedNumbers.ToArray(), testValue, useConcatenation) || 
               CheckIfPossible(multipliedNumbers.ToArray(), testValue, useConcatenation) || 
               concatenatedNumbersPossible;
    }

}
