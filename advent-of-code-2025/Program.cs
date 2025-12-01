using System.Diagnostics;
using advent_of_code_2025.day1;

var stopwatch = Stopwatch.StartNew();

var path = "../../../inputs/day1part1.txt";
day1.Day1Part2(path);

stopwatch.Stop();
Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms");
