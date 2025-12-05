namespace advent_of_code_2025.day5;

public class day5
{
    public static void Part1(string path)
    {
        var input = FormatInput(path);
        var sum = input.numbers.Count(x => input.ranges.Any(y => y.IsInRange(x)));
        Console.WriteLine($"sum: {sum}");
    }
    
    public static void Part2(string path)
    {
        var input = FormatRangePart2(path);
        var sum = input.Where(range => !range.CompletelyOverlapped).Sum(r => r.AmountOfIds);
        Console.WriteLine($"sum: {sum}");
    }

    private static List<Range> FormatRangePart2(string path)
    {
        var rawRanges = File.ReadAllLines(path).Where(x => x.Contains('-'));
        var ranges = rawRanges
            .Select(x => new Range(long.Parse(x.Split('-')[0]), long.Parse(x.Split('-')[1])))
            .DistinctBy(x => (x.Start, x.End))
            .ToList();
        
        foreach (var range in ranges)
        {
            range.CompletelyOverlapped = ranges.Any(x => x.CompletelyOverlaps(range) && range != x);
        }
        
        foreach (var range in ranges.Where(x => !x.CompletelyOverlapped))
        {
            foreach (var r in ranges.Where(x => !x.CompletelyOverlapped))
            {
                if (r.Overlaps(range) && r != range) r.UpdateRange(range);
            }
        }

        return ranges;
    }

    private static (List<Range> ranges, List<long> numbers) FormatInput(string path)
    {
        var file = File.ReadAllLines(path);
        var rawRanges = file.Where(x => x.Contains('-'));
        var ranges = new List<Range>();
        foreach (var range in rawRanges)
        {
            ranges.Add(new Range(long.Parse(range.Split("-")[0]), long.Parse(range.Split("-")[1])));
        }

        var numbers = file.Where(x => !x.Contains('-') && x.Length > 0).Select(long.Parse).ToList();
        return (ranges, numbers);
    }

    private class Range(long start, long end)
    {
        public long Start { get; set; } = start;
        public long End { get; set; } = end;
        public long AmountOfIds => End - Start + 1;
        public bool CompletelyOverlapped { get; set; }
        public bool IsInRange(long number) => number >= Start && number <= End;
        public bool Overlaps(Range range) => IsInRange(range.Start) || IsInRange(range.End);
        public bool CompletelyOverlaps(Range range) => Start <= range.Start && End >= range.End;
        public void UpdateRange(Range overlappingRange)
        {
            if (overlappingRange.CompletelyOverlaps(this)) 
                CompletelyOverlapped = true;
            
            else if (overlappingRange.IsInRange(Start))
                Start = overlappingRange.End + 1;
            
            else if (overlappingRange.IsInRange(End))
                End = overlappingRange.Start - 1;
        }
    }
}