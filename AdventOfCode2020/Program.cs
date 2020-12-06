using System;
using System.Linq;
using AdventOfCode2020.Problems._04;

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

            var day = new Day4();
            
            Console.WriteLine("Running Part 1...");
            var part1Result = day.Part1();
            Console.WriteLine(part1Result);

            Console.WriteLine("Running Part 2...");
            var part2Result = day.Part2();
            Console.WriteLine(part2Result);

        }
    }

}
