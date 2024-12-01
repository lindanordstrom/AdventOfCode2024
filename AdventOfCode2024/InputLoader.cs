namespace AdventOfCode2024;

public static class InputLoader
{
    public static string[] Load(int day, string separator = "\n")
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Cookie", $"session={Private.sessionId}");
        var result = client.GetStringAsync($"https://adventofcode.com/2024/day/{day}/input").Result.Trim().Split(separator);
        
        if (result.Last() == "" || result.Last() == "\n")
            result = result[..^1];
        
        return result;
    }
}