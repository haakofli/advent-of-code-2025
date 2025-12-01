namespace advent_of_code_2025.day1;

public class day1
{
    public static void Day1Part1(string path)
    {
        var file = File.ReadAllLines(path);

        var dial = 50;
        var count = 0;
        foreach (var line in file)
        {
            var direction = line[0];
            var number = int.Parse(line[1..]);
            dial = direction == 'L' ? dial - number : dial + number; 
            while (dial < 0) dial += 100;
            while (dial > 99) dial -= 100;

            if (dial == 0) count++;
        }
        
        Console.WriteLine($"Dial is {dial}");
        Console.WriteLine($"Count: {count}");
    }

    public static void Day1Part2(string path)
    {
        var file = File.ReadAllLines(path);

        var dial = 50;
        var count = 0;
        foreach (var line in file)
        {
            var direction = line[0];
            var number = int.Parse(line[1..]);

            for (var i = 1; i < number + 1; i++)
            {
                dial = direction == 'L' ? dial-1 : dial+1;
                if (dial == -1) dial = 99;
                if (dial == 100) dial = 0;
                if (dial == 0) count++;
            }
        }
        
        Console.WriteLine($"Count: {count}");
    }
}