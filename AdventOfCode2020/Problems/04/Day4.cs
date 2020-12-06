using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2020.Lib;

namespace AdventOfCode2020.Problems._04
{
    public class Day4 : Day<List<Passport>>
    {
        private const string InputPath = @"04\Day4Input.txt";

        protected override List<Passport> GetInput()
        {
            return FileUtil<Passport>.ReadSeparatedLinesAsList(PathRoot + InputPath, Passport.Parse);
        }

        public override string Part1()
        {
            var passports = GetInput();
            var validPassports = passports.Where(p => p.IsValid());
            return $"Valid passport count: {validPassports.Count()}";
        }

        public override string Part2()
        {
            var passports = GetInput();
            var validPassports = passports.Where(p => p.IsValidPart2());
            return $"Valid passport count: {validPassports.Count()}";
        }
    }
    public class Passport
    {
        public string BirthYearRaw { get; set; }
        public string IssueYearRaw { get; set; }
        public string ExpirationYearRaw { get; set; }
        public string HeightRaw { get; set; }
        public string HairColorRaw { get; set; }
        public string EyeColorRaw { get; set; }
        public string PassportIdRaw { get; set; }
        public string CountryIdRaw { get; set; }

        //private static Regex _heightRegex = new Regex(@"(\d+)(\w+)");

        public static Passport Parse(List<string> lines)
        {
            var raw = string.Join(" ", lines);
            var infos = raw.Split(" ").Select(info =>
            {
                 var parts = info.Split(":");
                 return Tuple.Create(parts[0], parts[1]);
            });

            var passport = new Passport();

            foreach (var info in infos)
            {
                var code = info.Item1;
                var value = info.Item2;

                switch (code)
                {
                    case ("byr"): passport.BirthYearRaw = value; break;
                    case ("iyr"): passport.IssueYearRaw = value; break;
                    case ("eyr"): passport.ExpirationYearRaw = value; break;
                    case ("hgt"): passport.HeightRaw = value; break;
                        //var groups = _heightRegex.Match(value).Groups;
                        //passport.Raw = int.Parse(groups[1].Value);
                        //passport.HeightUnit = groups[2].Value;
                    case ("hcl"): passport.HairColorRaw = value; break;
                    case ("ecl"): passport.EyeColorRaw = value; break;
                    case ("pid"): passport.PassportIdRaw = value; break;
                    case ("cid"): passport.CountryIdRaw = value; break;
                    default:
                        throw new Exception($"Unrecognized passport field {code}");
                }
            }

            return passport;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(BirthYearRaw)
                   && !string.IsNullOrEmpty(ExpirationYearRaw)
                   && !string.IsNullOrEmpty(EyeColorRaw)
                   && !string.IsNullOrEmpty(HairColorRaw)
                   && !string.IsNullOrEmpty(HeightRaw)
                   && !string.IsNullOrEmpty(IssueYearRaw)
                   && !string.IsNullOrEmpty(PassportIdRaw);
        }

        public bool IsValidPart2()
        {
            return IsValid() &&
                   BirthYearIsValid() &&
                   IssueYearIsValid() &&
                   ExpirationYearIsValid() &&
                   HeightIsValid() &&
                   HairColorIsValid() &&
                   EyeColorIsValid() &&
                   PassportIdIsValid();
        }

        private readonly Regex _passportRegex = new Regex(@"^\d{9}$");
        private bool PassportIdIsValid()
        {
            return _passportRegex.IsMatch(PassportIdRaw);
        }

        private readonly Regex _eyeColorRegex = new Regex(@"^(amb|blu|brn|gry|grn|hzl|oth)$");
        private bool EyeColorIsValid()
        {
            return _eyeColorRegex.IsMatch(EyeColorRaw);
        }

        private readonly Regex _hairColorRegex = new Regex(@"^#[a-f0-9]{6}$");
        private bool HairColorIsValid()
        {
            return _hairColorRegex.IsMatch(HairColorRaw);
        }

        private readonly Regex _heightRegex = new Regex(@"^(\d+)(cm|in)$");
        private bool HeightIsValid()
        {
            var match = _heightRegex.Match(HeightRaw);
            if (!match.Success)
            {
                return false;
            }

            var number = int.Parse(match.Groups[1].Value);
            var unit = match.Groups[2].Value;

            return unit switch
            {
                "cm" => (number >= 150 && number <= 193),
                "in" => (number >= 59 && number <= 76),
                _ => throw new Exception($"Unrecognized unit: {unit}")
            };
        }

        private readonly Regex _yearRegex = new Regex(@"^\d{4}$");
        private bool ExpirationYearIsValid()
        {
            if (!_yearRegex.IsMatch(ExpirationYearRaw))
            {
                return false;
            }

            var year = int.Parse(ExpirationYearRaw);
            return year >= 2020 && year <= 2030;
        }

        private bool IssueYearIsValid()
        {
            if (!_yearRegex.IsMatch(IssueYearRaw))
            {
                return false;
            }

            var year = int.Parse(IssueYearRaw);
            return year >= 2010 && year <= 2020;
        }

        private bool BirthYearIsValid()
        {
            if (!_yearRegex.IsMatch(BirthYearRaw))
            {
                return false;
            }

            var year = int.Parse(BirthYearRaw);
            return year >= 1920 && year <= 2002;
        }
    }
}
