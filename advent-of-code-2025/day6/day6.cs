namespace advent_of_code_2025.day6;

public class day
{
    public static void Part1(string path)
    {
        var problems = ParseProblemsPart1(path);
        var sum = problems.Select(problem => problem.Solve()).Sum();
        Console.WriteLine(sum);
    }

    public static void Part2(string path)
    {
        var problems = ParseProblemsPart2(path);
        var sum = problems.Select(problem => problem.Solve()).Sum();
        Console.WriteLine(sum);
    }

    private static List<Problem> ParseProblemsPart2(string path)
    {
        var grid = File.ReadAllLines(path);
        var problems = new List<Problem>();
        var problem = new Problem();

        for (int i = grid[0].Length - 1; i >= 0; i--)
        {
            var nextNumber = "";
            foreach (var t in grid)
            {
                var charToCheck = t[i];
                
                switch (charToCheck)
                {
                    case '*' or '+':
                        if (int.TryParse(nextNumber, out var n1)) problem.Numbers.Add(n1);
                        nextNumber = "";

                        problem.Operator = charToCheck.ToString();
                        problems.Add(problem);
                        problem = new Problem();
                        break;

                    case >= '0' and <= '9':
                        nextNumber += charToCheck;
                        break;

                    default:
                        if (int.TryParse(nextNumber, out var n2)) problem.Numbers.Add(n2);
                        nextNumber = "";
                        break;
                }
            }
        }
        return problems;
    }
    
    private static List<Problem> ParseProblemsPart1(string path)
    {
        var grid = File.ReadLines(path)
            .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Where(a => a.Length > 0)
            .ToArray();

        var problemsAsRows = Enumerable.Range(0, grid[0].Length)
            .Select(c => grid.Select(r => r[c]).ToArray());

        return problemsAsRows.Select(row => new Problem
        {
            Numbers = row.Where(entry => int.TryParse(entry, out _)).Select(int.Parse).ToList(),
            Operator = row.First(entry => !int.TryParse(entry, out _))
        }).ToList();
    }

    private class Problem
    {
        public List<int> Numbers { get; set; } = new();
        public string Operator { get; set; } = string.Empty;
        public long Solve() => Operator switch
            {
                "+" => Numbers.Sum(),
                "*" => Numbers.Aggregate(1L, (acc, x) => acc * x),
                _ => throw new Exception("Unknown operator")
            };

        public void PrintProblem()
        {
            var expr = string.Join($" {Operator} ", Numbers);
            Console.WriteLine($"{expr} = {Solve()}");
        }
    }
}