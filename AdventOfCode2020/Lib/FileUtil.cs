using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Lib
{
    public static class FileUtil<T>
    {
        public static List<T> ReadFileLinesAsList(string path, Func<string, T> parseFn)
        {
            var lines = File.ReadLines(path);
            return lines.Select(parseFn).ToList();
        }
    }
}
