namespace AdventOfCode2024;

public static class Day2
{
    public static void Part1(string[] input)
    {
        var sum = input.Count(line => line.IsLineSafe());
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input) {
        var sum = input.Count(line => line.IsLineSafe(true));
        Console.WriteLine(sum);
    }
    
    private static bool CheckIfAscending(List<int> numbers)
    { 
        var ascendingCount = 0;
        var descendingCount = 0;
        for (var i = 0; i < 4; i++)
        {
            if (numbers[i] < numbers[i + 1])
                ascendingCount++;
            else if (numbers[i] > numbers[i + 1])
                descendingCount++;
        }
        return ascendingCount > descendingCount;
    }
    
    private static bool CheckIfSafe(int previousNumber, int currentNumber, bool isAscending)
    {
        var diff = Math.Abs(previousNumber - currentNumber);
        var diffIsWithingRange = diff is <= 3 and >= 1;
        var ascendsSafely = isAscending && previousNumber < currentNumber;
        var descendsSafely = !isAscending && previousNumber > currentNumber;
        return (ascendsSafely || descendsSafely) && diffIsWithingRange;
    }
    
    private static bool IsLineSafe(this string line, bool tolerateBadLevel = false)
    {
        var numbers = line.Split(" ").Select(int.Parse).ToList();
        var isAscending = CheckIfAscending(numbers);
        return numbers.AreNumbersSafe(isAscending, tolerateBadLevel);
    }
    
    private static bool AreNumbersSafe(this List<int> numbers, bool isAscending, bool tolerateBadLevel = false)
    {
        for (var i = 0; i < numbers.Count - 1; i++)
        {
            var currentNumber = numbers[i];
            var nextNumber = numbers[i+1];
            if (CheckIfSafe(currentNumber, nextNumber, isAscending)) continue;
            if (!tolerateBadLevel) return false;
            
            var n1 = new List<int>(numbers);
            var n2 = new List<int>(numbers);
            n1.RemoveAt(i);
            n2.RemoveAt(i + 1);
            return n1.AreNumbersSafe(isAscending) || n2.AreNumbersSafe(isAscending);
        }
        return true;
    }
}