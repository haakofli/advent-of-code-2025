using System.Diagnostics;
using DayNs = advent_of_code_2025.day6;

var dayFile = typeof(DayNs.day).Namespace!.Split('.').Last();
var path = $"../../../inputs/{dayFile}.txt";

var sw = Stopwatch.StartNew();

DayNs.day.Part2(path);

sw.Stop();
Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds}ms");