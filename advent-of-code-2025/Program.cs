using System.Diagnostics;
using advent_of_code_2025.day1;
using advent_of_code_2025.day2;
using advent_of_code_2025.day3;
using advent_of_code_2025.day4;
using advent_of_code_2025.day5;

var stopwatch = Stopwatch.StartNew();

var path = "../../../inputs/day5.txt";
day5.Part2(path);

stopwatch.Stop();
Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms");