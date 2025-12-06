namespace advent_of_code_2025.day4;

public class day
{
    public static void Part1(string path)
    {
        var nodes = CreateNodeMap(path);
        var count = nodes.Sum(nodeRow => nodeRow.Count(node => node is { NeighboorsWithPaperRolls: < 4, IsPaperRoll: true }));
        Console.WriteLine(count);
    }
    
    public static void Part2(string path)
    {
        var nodes = CreateNodeMap(path);
        var totalCount = 0;
        
        while (true)
        {
            var nodesToUpdate = nodes.SelectMany(x => x).Where(node => node is { NeighboorsWithPaperRolls: < 4, IsPaperRoll: true }).ToArray();
            foreach (var node in nodesToUpdate) node.Value = ".";
            var currentCount = nodesToUpdate.Count();
            totalCount += currentCount;
            if (currentCount == 0) break;
        }
        
        Console.WriteLine(totalCount);
    }

    private static List<List<Node>> CreateNodeMap(string path)
    {
        var lines = File.ReadAllLines(path);
        var paddedRows = lines.Select(x => "." + x + ".").ToArray();
        var emptyPaddedRow = new string('.', paddedRows.First().Length);
        var paddedLines = new[] { emptyPaddedRow }.Concat(paddedRows).Concat([emptyPaddedRow]).ToArray();
        
        var nodes = new List<List<Node>>();
        
        for (int i = 0; i < paddedLines.Length ; i++)
        {
            nodes.Add(new List<Node>());
            for (int j = 0; j < paddedLines[i].Length; j++)
            {
                nodes[i].Add(new Node(paddedLines[i][j].ToString(), i, j));
            }
        }

        for (int i = 1; i < paddedLines.Length - 1; i++)
        {
            for (int j = 1; j < paddedLines[i].Length - 1; j++)
            {
                nodes[i][j].PopulateNeighboors(nodes);
            }
        }

        return nodes;
    }
    
    private class Node(string value, int xPos, int yPos)
    {
        public string Value { get; set; } = value;
        private int XPos { get; } = xPos;
        private int YPos { get; } = yPos;
        public int NeighboorsWithPaperRolls => IsPaperRoll ? Neightboors?.Count(x => x.IsPaperRoll) ?? 5 : 5;
        public bool IsPaperRoll => Value == "@";

        private Node[]? Neightboors { get; set; }

        public void PopulateNeighboors(List<List<Node>> map)
        {
            var localSubset = new[]
            {
                map[XPos-1][(YPos-1)..(YPos+2)],
                map[XPos][(YPos-1)..(YPos+2)],
                map[XPos+1][(YPos-1)..(YPos+2)],
            };
            Neightboors = localSubset.SelectMany(x => x).Where(x => x != this).ToArray();
        }
    }
}