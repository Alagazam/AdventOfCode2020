using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class Day04
    {
        enum PassFields { byr, iyr, eyr, hgt, hcl, ecl, pid, cid };
        class Passport
        {
            public Passport(string passStr)
            {
                fields = new Dictionary<PassFields, string>();
                var passFrields = passStr.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach(var pf in passFrields)
                {
                    var tokens = pf.Split(':');
                    fields.Add(Enum.Parse<PassFields>(tokens[0]), tokens[1]);
                }

            }

            Dictionary<PassFields, string> fields;

            public bool IsValid()
            {
                var values = Enum.GetValues(typeof(PassFields)).Cast<PassFields>();
                foreach (var v in values)
                {
                    if (v == PassFields.cid) continue;
                    if (!fields.ContainsKey(v)) return false;

                }
                return true;
            }

            public bool IsValidB()
            {
                if (!IsValid()) return false;

                foreach (var f in fields)
                {
                    switch (f.Key)
                    {
                        case PassFields.byr:
                            var byr = int.Parse(f.Value);
                            if (byr < 1920 || byr > 2002) return false;
                            break;
                        case PassFields.iyr:
                            var iyr = int.Parse(f.Value);
                            if (iyr < 2010 || iyr > 2020) return false;
                            break;
                        case PassFields.eyr:
                            var eyr = int.Parse(f.Value);
                            if (eyr < 2020 || eyr > 2030) return false;
                            break;
                        case PassFields.hgt:
                            if (f.Value.Substring(2).Equals("in"))
                            {
                                var inch = int.Parse(f.Value.Substring(0, 2));
                                if (inch >= 59 || inch <= 76) continue;
                            }
                            else if (f.Value.Length >3 && f.Value.Substring(3).Equals("cm"))
                            {
                                var cm = int.Parse(f.Value.Substring(0, 3));
                                if (cm >= 150 || cm <= 193) continue;
                            }
                            return false;
                        case PassFields.hcl:
                            if (!Regex.IsMatch(f.Value, @"^#[\d|abcdef]{6}$")) return false;
                            break;
                        case PassFields.ecl:
                            if (!Regex.IsMatch(f.Value, @"^amb|blu|brn|gry|grn|hzl|oth$")) return false;
                            break;
                        case PassFields.pid:
                            if (!Regex.IsMatch(f.Value, @"^\d{9}$")) return false;
                            break;
                        case PassFields.cid:
                            break;
                    }

                }
                return true;
            }
        }
        public static Int64 Day04a(string[] input)
        {
            int valid = 0;
            var passStr = "";
            foreach (var line in input)
            {
                if (passStr != "") passStr += " ";
                passStr += line;

                if (line.Equals("") || line.Equals(input.Last()))
                {
                    if (!passStr.Equals(""))
                    {
                        var p = new Passport(passStr);
                        if (p.IsValid())
                        {
                            valid++;
                        }
                    }
                    passStr= "";
                }
            }
            return valid;
        }

        public static Int64 Day04b(string[] input)
        {
            int valid = 0;
            var passStr = "";
            foreach (var line in input)
            {
                if (passStr != "") passStr += " ";
                passStr += line;

                if (line.Equals("") || line.Equals(input.Last()))
                {
                    if (!passStr.Equals(""))
                    {
                        var p = new Passport(passStr);
                        if (p.IsValidB())
                        {
                            valid++;
                        }
                    }
                    passStr = "";
                }
            }
            return valid;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day04.txt");
            Console.WriteLine("Day04a : {0}", Day04a(lines));
            Console.WriteLine("Day04b : {0}", Day04b(lines));
        }
    }
}
