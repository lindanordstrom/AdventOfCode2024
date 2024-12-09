namespace AdventOfCode2024;

public static class Day8
{
    public static void Part1(string[] input)
    {
        Dictionary<string, List<(int, int)>> frequences = new();
        HashSet<(int, int)> anitnodes = new();

        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] != '.')
                {
                    var key = input[row][col].ToString();
                    if (!frequences.ContainsKey(key))
                    {
                        frequences[key] = new List<(int, int)> { (row, col) };
                    }
                    else
                    {
                        frequences[key].Add((row, col));
                    }
                }
            }
        }
        
        foreach (var (key, value) in frequences)
        {
            for (var i = 0; i < value.Count - 1; i++)
            {
                for (var j = i + 1; j < value.Count; j++)
                {
                    Console.WriteLine($"{key} {value[i]} {value[j]}");
                    var horizontalDistance = value[i].Item1 - value[j].Item1;
                    var verticalDistance = value[i].Item2 - value[j].Item2;
                    var antinode1 = (value[i].Item1 + horizontalDistance, value[i].Item2 + verticalDistance);
                    var antinode2 = (value[j].Item1 - horizontalDistance, value[j].Item2 - verticalDistance);
                    Console.WriteLine($"{antinode1} {antinode2}");
                    if (antinode1.Item1 >= 0 && antinode1.Item1 < input.Length && antinode1.Item2 >= 0 && antinode1.Item2 < input[0].Length)
                        anitnodes.Add(antinode1);
                    if (antinode2.Item1 >= 0 && antinode2.Item1 < input.Length && antinode2.Item2 >= 0 && antinode2.Item2 < input[0].Length)
                        anitnodes.Add(antinode2);
                }
            }
        }
        
        Console.WriteLine(anitnodes.Count);
    }
    
    public static void Part2(string[] input)
    {
    }
}
