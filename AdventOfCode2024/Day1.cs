namespace AdventOfCode2024;

public static class Day1
{
    public static void Part1(string[] input)
    {
        var (listA, listB) = GetLists(input);
        listA.Sort();
        listB.Sort();
        var sum = listA.Select((item, index) => Math.Abs(item - listB[index])).Sum();
        Console.WriteLine(sum);
    }

    public static void Part2(string[] input) {
        var (listA, listB) = GetLists(input);
        var sum = 0;
        listA.ForEach(value => sum += value * listB.Count(v => v == value));
        Console.WriteLine(sum);
    }
    
    private static (List<int>, List<int>) GetLists(string[] input)
    {
        var listA = new List<int>();
        var listB = new List<int>();
        foreach (var line in input)
        {
            var values = line.Split(" ").Select(int.Parse);
            listA.Add(values.First());
            listB.Add(values.Last());
        }
        return (listA, listB);
    }
}