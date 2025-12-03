namespace advent_of_code_2025.day3;

public class day3
{
    public static void Part1(string path)
    {
        var banks = GetBatteryBanks(path);

        long sum = 0;
        foreach (var bank in banks)
        {
            var firstBattery = bank.FindHighestBattery(0, bank.Sequence.Length - 1);
            var secondBattery = bank.FindHighestBattery(firstBattery.index + 1, bank.Sequence.Length);
            sum += long.Parse(firstBattery.value.ToString() + secondBattery.value.ToString());
        }
        
        Console.WriteLine($"sum: {sum}");
    }
    
    public static void Part2(string path)
    {
        var banks = GetBatteryBanks(path);

        long sum = 0;
        foreach (var bank in banks)
        {
            var bankBattery = "";
            (int index, long value) previousBattery = (-1, bank.Sequence.Length - 1);
            for (int i = 12; i >= 1; i--)
            {
                previousBattery = bank.FindHighestBattery(previousBattery.index + 1, bank.Sequence.Length - (i-1));
                bankBattery += previousBattery.value.ToString();
            }
            
            sum += long.Parse(bankBattery);
        }
        
        Console.WriteLine($"sum: {sum}");
    }

    private static BatteryBank[] GetBatteryBanks(string path)
    {
        var file = File.ReadAllLines(path);
        return file.Select(x => new BatteryBank
        {
            Sequence = x.Select(y => int.Parse(y.ToString())).ToArray()
        }).ToArray();
    }
    
    private class BatteryBank
    {
        public int[] Sequence { get; set; }

        public (int index, long value) FindHighestBattery(int start, int end)
        {
            var highest = 0;
            var highestIndex = 0;
            for (int i = start; i < end; i++)
            {
                if (Sequence[i] == 9)
                {
                    return (i, Sequence[i]);
                }
                if (Sequence[i] > highest)
                {
                    highest = Sequence[i];
                    highestIndex = i;
                }
            }
            
            return (highestIndex, highest);
        }
    }
}