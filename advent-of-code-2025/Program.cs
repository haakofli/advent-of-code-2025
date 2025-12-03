using System.Diagnostics;
using advent_of_code_2025.day1;
using advent_of_code_2025.day2;
using advent_of_code_2025.day3;

var stopwatch = Stopwatch.StartNew();

var path = "../../../inputs/day3.txt";
day3.Part2(path);

stopwatch.Stop();
Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms");