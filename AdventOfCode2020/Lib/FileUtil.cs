using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Lib
{
    public static class FileUtil
    {
        public static List<int> ReadFileAsIntList(string path)
        {
            var lines = System.IO.File.ReadLines(path);
            return lines.Select(int.Parse).ToList();
        }
    }
}
