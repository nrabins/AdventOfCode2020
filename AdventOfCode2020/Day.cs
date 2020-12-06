using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public abstract class Day<TInput>
    {
        protected string PathRoot = @"C:\Users\nrabins\Development\AdventOfCode\AdventOfCode2020\AdventOfCode2020\Problems\";
        
        protected abstract TInput GetInput();

        public abstract string Part1();

        public abstract string Part2();

    }
}
