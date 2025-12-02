namespace advent_of_code_2025.day2;

public class day2
{
    private static readonly CurrentPart _part = CurrentPart.PartTwo;

    public static void Day2Part1(string path)
    {
        var productIdRanges = PopulateProductIdRangeFromInput(path);
        var sum = productIdRanges.Select(x => x.CountInvalidIds()).Sum();
        Console.WriteLine($"Invalid ids: {sum}");
    }
    
    public static void Day2Part2(string path)
    {
        var productIdRanges = PopulateProductIdRangeFromInput(path);
        var sum = productIdRanges.Select(x => x.CountInvalidIds()).Sum();
        Console.WriteLine($"Invalid ids: {sum}");
    }

    private class ProductIdRange
    {
        public long Start { get; init; }
        public long End { get; init; }

        public long CountInvalidIds()
        {
            long sum = 0;
            for (long i = Start; i < End + 1; i++)
            {
                if (IsInvalid(i)) sum += i;
            }
            return sum;
        }

        private bool IsInvalid(long id)
        {
            if (_part is CurrentPart.PartOne)
            {
                var stringId = id.ToString();
                if (stringId.Length % 2 != 0) return false;
                var firstPart = stringId.Substring(0, stringId.Length / 2);
                var secondPart = stringId.Substring(stringId.Length / 2);
                return firstPart.Equals(secondPart);
            }
            else
            {
                var stringId = id.ToString();
                for (int chunkSize = 1; chunkSize < stringId.Length / 2 + 1; chunkSize++)
                {
                    var chunks = new HashSet<string>();
                    for (int i = 0; i < stringId.Length; i += chunkSize)
                    {
                        if (chunks.Count > 1) continue;
                        int currentChunkLength = Math.Min(chunkSize, stringId.Length - i);
                        var chunk = stringId.Substring(i, currentChunkLength);
                        chunks.Add(chunk);
                    }
                    if (chunks.Any(x => x.StartsWith('0'))) continue;
                    if (chunks.Count != 1) continue;

                    return true;
                }

                return false;
            }
        }
    }

    private static ProductIdRange[] PopulateProductIdRangeFromInput(string path)
    {
        var file = File.ReadAllText(path);
        return file.Split(",").Select(pir => new ProductIdRange
        {
            Start = long.Parse(pir.Split("-").First()),
            End = long.Parse(pir.Split("-").Last())
        }).ToArray();
    }
}