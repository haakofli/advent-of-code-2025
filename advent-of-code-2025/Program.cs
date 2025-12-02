using System.Diagnostics;
using advent_of_code_2025.day1;
using advent_of_code_2025.day2;

var stopwatch = Stopwatch.StartNew();

var path = "../../../inputs/day2.txt";
day2.Day2Part2(path);

stopwatch.Stop();
Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms");