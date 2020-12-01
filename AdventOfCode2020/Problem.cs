using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public abstract class Problem<TInput, TOutput>
    {
        protected abstract TOutput Execute(TInput input);
    }
}
