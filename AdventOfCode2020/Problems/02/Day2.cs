using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2020.Lib;

namespace AdventOfCode2020.Problems._02
{
    public class Day2 : Day<List<PolicyAndPassword>>
    {
        private const string InputPath = @"C:\Users\nrabins\Development\AdventOfCode\AdventOfCode2020\AdventOfCode2020\Problems\02\Day2Input.txt";

        protected override List<PolicyAndPassword> GetInput()
        {
            return FileUtil<PolicyAndPassword>.ReadFileLinesAsList(InputPath, PolicyAndPassword.Parse);
        }

        public override string Part1()
        {
            var policies = GetInput();
            var validPolicies = policies.Where(p => p.Part1IsValid());
            return $"Valid policies: {validPolicies.Count()}";
        }

        public override string Part2()
        {
            var policies = GetInput();
            var validPolicies = policies.Where(p => p.Part2IsValid());
            return $"Valid policies: {validPolicies.Count()}";
        }
    }

    public class PolicyAndPassword
    {
        public char RequiredCharacter { get; set; }
        
        public int MinCount { get; set; }
        
        public int MaxCount { get; set; }

        public string Password { get; set; }
        public static PolicyAndPassword Parse(string raw)
        {
            var regex = new Regex(@"(\d+)-(\d+) (\S): (\S+)", RegexOptions.Singleline);
            var groups = regex.Match(raw).Groups;
            return new PolicyAndPassword
            {
                MinCount = int.Parse(groups[1].Value),
                MaxCount = int.Parse(groups[2].Value),
                RequiredCharacter = groups[3].Value[0],
                Password = groups[4].Value,
            };
        }

        public bool Part1IsValid()
        {
            var count = Password.Split(RequiredCharacter).Length - 1;
            return count >= MinCount && count <= MaxCount;
        }

        public bool Part2IsValid()
        {
            var indexes = new List<int> { MinCount - 1, MaxCount - 1 };
            var matchingCharacterCount = indexes.Count(i => Password[i] == RequiredCharacter);

            return matchingCharacterCount == 1;
        }
    }
}
