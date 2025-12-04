using System.Diagnostics;
using advent_of_code_2025.day1;
using advent_of_code_2025.day2;
using advent_of_code_2025.day3;
using advent_of_code_2025.day4;

var stopwatch = Stopwatch.StartNew();

var path = "../../../inputs/day4.txt";
day4.Part2(path);

stopwatch.Stop();
Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms");