using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2020.Lib;

namespace AdventOfCode2020.Problems._01
{
    public class Day1 : Day<List<int>>
    {
        private const string InputPath = @"01\Day1Input.txt";

        protected override List<int> GetInput()
        {
            return FileUtil<int>.ReadFileLinesAsList(PathRoot + InputPath, int.Parse);
        }

        public override string Part1()
        {
            var expenses = GetInput().ToList();

            for (var i = 0; i < expenses.Count - 1; i++)
            {
                var iExpense = expenses[i];
                for (var j = i + 1; j < expenses.Count; j++)
                {
                    var jExpense = expenses[j];
                    if (iExpense + jExpense == 2020)
                    {
                        return $"{iExpense * jExpense}";
                    }
                }
            }
            return "None found";
        }

        public override string Part2()
        {
            var expenses = GetInput();

            for (var i = 0; i < expenses.Count - 2; i++)
            {
                var iExpense = expenses[i];
                for (var j = i + 1; j < expenses.Count - 1; j++)
                {
                    var jExpense = expenses[j];
                    for (int k = j + 1; k < expenses.Count; k++)
                    {
                        var kExpense = expenses[k];
                        if (iExpense + jExpense + kExpense == 2020)
                        {
                            return $"{iExpense * jExpense * kExpense}";
                        }
                    }

                }
            }

            return "None found";
        }
    }
}
