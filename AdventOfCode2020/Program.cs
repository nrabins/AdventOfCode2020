using System;
using System.Linq;
using AdventOfCode2020.Problems._01;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter a <number>.<part> to run a specific problem. Leave blank and press enter to run most recent.");

            //var choice = Console.ReadLine();

            //var allDays = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes())
            //    .Where(t => t.IsClass && !string.IsNullOrWhiteSpace(t.Namespace) && t.Namespace.Contains("roblems"));

            //if (string.IsNullOrWhiteSpace(choice))
            //{
            //    problem = LatestProblem();
            //}

            var day = new Day1();
            
            Console.WriteLine("Running Part 1...");
            var day1Result = day.Part1();
            Console.WriteLine(day1Result);

            Console.WriteLine("Running Part 2...");
            var day2Result = day.Part2();
            Console.WriteLine(day2Result);

        }
    }

}
