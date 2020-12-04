using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2020.Lib;

namespace AdventOfCode2020.Problems._03
{
    public class Day3 : Day<List<string>>
    {
        private const string InputPath =
            @"C:\Users\nrabins\Development\AdventOfCode\AdventOfCode2020\AdventOfCode2020\Problems\03\Day3Input.txt";

        protected override List<string> GetInput()
        {
            return FileUtil<string>.ReadFileLinesAsList(InputPath, a => a);
        }

        public override string Part1()
        {
            var rows = GetInput();
            var treeCollisions = CountCollisions(rows, 3, 1);
            return $"Collided with {treeCollisions} tree(s)";
        }

        public override string Part2()
        {
            var rows = GetInput();

            // (x, y)
            var inputs = new List<(int, int)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            var totalProduct = inputs.Aggregate(1L, (product, tuple) =>
            {
                var collisions = CountCollisions(rows, tuple.Item1, tuple.Item2);
                return product * collisions;
            });

            return $"Product of collisions of all 5 paths = {totalProduct}";

        }

        private long CountCollisions(List<string> rows, int dx, int dy)
        {
            var rowLength = rows[0].Length;
            var x = 0;
            var y = 0;

            var treeCollisions = 0;
            while (y < rows.Count)
            {
                var isTree = rows[y][x] == '#';
                if (isTree)
                {
                    treeCollisions++;
                }

                x = (x + dx) % rowLength;
                y += dy;
            }

            return treeCollisions;
        }
    }
}
