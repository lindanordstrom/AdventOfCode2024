namespace AdventOfCode2024;

public static class Day5
{
    public static void Part1(string[] input)
    {
        var sum = 0;
        var pageList = GetPageList(input);

        foreach (var pages in pageList)
        {
            var pagesArray = pages.Split(",");
            var middle = pagesArray.Length / 2;
            var middleValue = pagesArray[middle];
            sum += int.Parse(middleValue);
        }
        Console.WriteLine(sum);
    }
    
    public static void Part2(string[] input)
    {
        var sum = 0;
        var pageList = GetPageList(input, PageListType.Invalid);
        
        foreach (var pages in pageList)
        {
            var loop = true;
            var pagesArray = pages.Split(",");
            while (loop)
            {
                var incorrectPagesFound = 0;
                foreach (var rules in input.First().Split("\n"))
                {
                    var firstRule = rules.Split("|").First();
                    var secondRule = rules.Split("|").Last();
                    var firstIndex = Array.IndexOf(pagesArray, firstRule);
                    var secondIndex = Array.IndexOf(pagesArray, secondRule);
                    if (firstIndex != -1 && secondIndex != -1 && firstIndex > secondIndex)
                    {
                        pagesArray[firstIndex] = secondRule;
                        pagesArray[secondIndex] = firstRule;
                        incorrectPagesFound++;
                    }
                }
                if (incorrectPagesFound == 0) loop = false;
            }
            
            var middle = pagesArray.Length / 2;
            var middleValue = pagesArray[middle];
            sum += int.Parse(middleValue);
        }
        
        Console.WriteLine(sum);
    }
    
    private static List<string> GetPageList(string[] input, PageListType type = PageListType.Valid)
    {
        var rulesList = input.First().Split("\n");
        var pageList = input.Last().Split("\n");
        var invalidPages = new List<string>();
        
        foreach (var rules in rulesList)
        {
            var firstRule = rules.Split("|").First();
            var secondRule = rules.Split("|").Last();
            
            foreach (var pages in pageList)
            {
                var firstIndex = pages.IndexOf(firstRule);
                var secondIndex = pages.IndexOf(secondRule);
                if (firstIndex != -1 && secondIndex != -1 && firstIndex > secondIndex)
                {
                    pageList = pageList.Where(x => x != pages).ToArray();
                    if (type == PageListType.Invalid) 
                        invalidPages.Add(pages);
                    break;
                } 
            }
        }
        return type == PageListType.Valid ? pageList.ToList() : invalidPages;
    }

    private enum PageListType
    {
        Valid,
        Invalid
    }
}