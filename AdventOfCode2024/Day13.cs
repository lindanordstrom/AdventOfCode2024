namespace AdventOfCode2024;

public static class Day13
{
    public static void Part1(string[] input)
    {
        Console.WriteLine(TokensNeeded(input, false));
    }
    
    public static void Part2(string[] input)
    {
        Console.WriteLine(TokensNeeded(input, true));
    }
    
    private static long TokensNeeded(string[] input, bool isPart2)
    {
        long sum = 0;
        foreach (var game in input)
        {
            var lines = game.Split("\n");
            var buttonA = lines[0].Split(" ");
            var buttonB = lines[1].Split(" ");
            var prize = lines[2].Split(" ");
            var prizeX = long.Parse(prize[1].Split("=")[1].Trim(','));
            var prizeY = long.Parse(prize[2].Split("=")[1]);
            if (isPart2)
            {
                prizeX += 10000000000000;
                prizeY += 10000000000000;
            }
            var aX = long.Parse(buttonA[2].Split("+")[1].Trim(','));
            var bX = long.Parse(buttonB[2].Split("+")[1].Trim(','));
            var aY = long.Parse(buttonA[3].Split("+")[1]);
            var bY = long.Parse(buttonB[3].Split("+")[1]);
            
            var b = (prizeY * aX - prizeX * aY) / (double)(aX * bY - bX * aY);
            var a = (prizeX -  bX * b) / aX;

            if (a % 1 == 0 && b % 1 == 0 && (isPart2 || a <= 100 && b <= 100))
            {
                sum += (long)a * 3 + (long)b;
            }
        }
        return sum;
    }
}

