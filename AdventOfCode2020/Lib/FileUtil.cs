using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Problems._04;

namespace AdventOfCode2020.Lib
{
    public static class FileUtil<T>
    {
        public static List<T> ReadFileLinesAsList(string path, Func<string, T> parseFn)
        {
            var lines = File.ReadLines(path);
            return lines.Select(parseFn).ToList();
        }

        public static List<T> ReadSeparatedLinesAsList(string path, Func<List<string>, T> parseFn)
        {
            var lines = File.ReadLines(path);
            var groupedLines = new List<List<string>>();
            var currentGroup = new List<string>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    groupedLines.Add(currentGroup);
                    currentGroup = new List<string>();
                    continue;
                }

                currentGroup.Add(line);
            }

            if (currentGroup.Any())
            {
                groupedLines.Add(currentGroup);
            }

            return groupedLines.Select(parseFn).ToList();
        }
    }
}
