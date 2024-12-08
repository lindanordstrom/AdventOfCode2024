namespace AdventOfCode2024;

public static class Day6
{
    private enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public static void Part1(string[] input)
    {
        var sum = 0;
        var blockers = new List<(int, int)>();
        var uniqueVisits = blockers.ToHashSet();
        var currentPos = (-1, -1);
        var direction = Direction.None;

        for (var row = 0; row < input.Length; row++)
        {
            for (var column = 0; column < input[row].Length; column++)
            {
                if (input[row][column] == '.')
                {
                    continue;
                }
                if (input[row][column] == '#')
                {
                    blockers.Add((row, column));
                    continue;
                }

                currentPos = (row, column);

                direction = input[row][column] switch
                {
                    '>' => Direction.Right,
                    '<' => Direction.Left,
                    '^' => Direction.Up,
                    'v' => Direction.Down,
                    _ => direction
                };
            }
        }

        while (true)
        {
            if (direction == Direction.Up)
            {
                var matches = blockers.Where(tuple => tuple.Item1 < currentPos.Item1 && tuple.Item2 == currentPos.Item2)
                    .OrderBy(tuple => tuple.Item1);
                if (!matches.Any())
                {
                    for (var visit = currentPos.Item1; visit >= 0; visit--)
                        uniqueVisits.Add((visit, currentPos.Item2));
                    break;
                }
                var nextPos = (matches.Last().Item1 + 1, currentPos.Item2);
                for (var visit = currentPos.Item1; visit >= nextPos.Item1; visit--)
                    uniqueVisits.Add((visit, currentPos.Item2));
                currentPos = nextPos;
                direction = Direction.Right;
                Console.WriteLine(currentPos);
            } else if (direction == Direction.Right)
            {
                var matches = blockers.Where(tuple => tuple.Item1 == currentPos.Item1 && tuple.Item2 > currentPos.Item2)
                    .OrderBy(tuple => tuple.Item2);
                if (!matches.Any())
                {
                    for (var visit = currentPos.Item2; visit < input.First().Length; visit++)
                        uniqueVisits.Add((currentPos.Item1, visit));
                    break;
                }
                var nextPos = (currentPos.Item1, matches.First().Item2 - 1);
                for (var visit = currentPos.Item2; visit <= nextPos.Item2; visit++)
                    uniqueVisits.Add((currentPos.Item1, visit));
                currentPos = nextPos;
                direction = Direction.Down;
                Console.WriteLine(currentPos);
            } else if (direction == Direction.Down)
            {
                var matches = blockers.Where(tuple => tuple.Item1 > currentPos.Item1 && tuple.Item2 == currentPos.Item2)
                    .OrderBy(tuple => tuple.Item1);
                if (!matches.Any())
                {
                    for (var visit = currentPos.Item1; visit < input.Length; visit++)
                        uniqueVisits.Add((visit, currentPos.Item2));
                    break;
                }
                var nextPos = (matches.First().Item1 - 1, currentPos.Item2);
                for (var visit = currentPos.Item1; visit <= nextPos.Item1; visit++)
                    uniqueVisits.Add((visit, currentPos.Item2));
                currentPos = nextPos;
                direction = Direction.Left;
                Console.WriteLine(currentPos);
            } else if (direction == Direction.Left)
            {
                var matches = blockers.Where(tuple => tuple.Item1 == currentPos.Item1 && tuple.Item2 < currentPos.Item2)
                    .OrderBy(tuple => tuple.Item2);
                if (!matches.Any())
                {
                    for (var visit = currentPos.Item2; visit >= 0; visit--)
                        uniqueVisits.Add((currentPos.Item1, visit));
                    break;
                }
                var nextPos = (currentPos.Item1, matches.Last().Item2 + 1);
                for (var visit = currentPos.Item2; visit >= nextPos.Item2; visit--)
                    uniqueVisits.Add((currentPos.Item1, visit));
                currentPos = nextPos;
                direction = Direction.Up;
                Console.WriteLine(currentPos);
            }
        }
        
        Console.WriteLine(uniqueVisits.Count);
    }
    
    public static void Part2(string[] input)
    {
        var sum = 0;
        Console.WriteLine(sum);
    }
}