using System.Numerics;

namespace AdventOfCode2024;

public static class Day9
{
    public static void Part1(string[] input)
    {
        var filesList = GetFilesList(input);
        for (var i = filesList.Count - 1; i >= 0; i--)
        {
            if (!filesList.Contains(-1)) break;
            var firstFreeSpaceIndex = filesList.IndexOf(-1);
            filesList.Swap(i, firstFreeSpaceIndex);
            filesList.RemoveAt(i);
        }
        Console.WriteLine(GetChecksum(filesList));
    }
    
    public static void Part2(string[] input)
    {
        var filesList = GetFilesList(input);
        for (var i = filesList.Count - 1; i >= 0;)
        {
            var lastChar = filesList[i];
            //Console.WriteLine("--->" + lastChar);
            if (lastChar == -1)
            {
                i--;
                continue;
            };
            var lastCharIndexes = filesList.Select((x, j) => x == lastChar ? j : -1).Where(x => x != -1).ToList();
            //lastCharIndexes.ForEach(Console.WriteLine);
            //Console.WriteLine();
            
            var freeSpaceIndexes = filesList.Select((x, j) => x == -1 ? j : -1).Where(x => x != -1).ToList();
            for (var j = 0; j < freeSpaceIndexes.Count; j++)
            {
                if (j + lastCharIndexes.Count > freeSpaceIndexes.Count) break;
                if (freeSpaceIndexes[j + lastCharIndexes.Count - 1] != freeSpaceIndexes[j] + lastCharIndexes.Count - 1) continue;
                for (var k = 0; k < lastCharIndexes.Count; k++)
                {
                    if (freeSpaceIndexes[j + k] > lastCharIndexes[k]) continue;
                    //Console.WriteLine($"Swapping {freeSpaceIndexes[j + k]} with {lastCharIndexes[k]}");
                    filesList.Swap(freeSpaceIndexes[j + k], lastCharIndexes[k]);
                }
                break;
            }
            
            i -= lastCharIndexes.Count;
        }
        
        //filesList.ForEach(Console.Write);
        //Console.WriteLine();
        Console.WriteLine(GetChecksum(filesList));
    }
    
    private static List<int> GetFilesList(string[] input)
    {
        var s = input[0];
        var filesString = new string(s.Where((x,i) => i % 2 == 0).ToArray());
        var filesList = new List<int>();
        var freeSpaceString = new string(s.Where((x,i) => i % 2 != 0).ToArray());

        for (var i = 0; i < filesString.Length; i++)
        {
            filesList.AddRange(Enumerable.Repeat(i, int.Parse(filesString[i].ToString())));
            if (i < freeSpaceString.Length)
                filesList.AddRange(Enumerable.Repeat(-1, int.Parse(freeSpaceString[i].ToString())));
        }
        
        return filesList;
    }
    
    private static BigInteger GetChecksum(List<int> filesList)
    {
        BigInteger sum = 0;
        for (var i = 0; i < filesList.Count; i++)
        {
            if (filesList[i] == -1) continue;
            sum += filesList[i] * i;
        }
        return sum;
    }
    
    private static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
    {
        (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        return list;
    }
}
