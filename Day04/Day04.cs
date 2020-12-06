using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                foreach(var v in values)
                {
                    if (v == PassFields.cid) continue;
                    if (!fields.ContainsKey(v)) return false;
                }
                return true;
            }
        }
        public static Int64 Day04a(string[] input)
        {
            int valid = 0;
            int invalid = 0;
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
                            Console.WriteLine("Valid: " + passStr);
                            valid++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid: " + passStr);
                            invalid++;
                        }
                    }
                    passStr= "";
                }
            }
            return valid;
        }

        //public static Int64 Day04b(string[] input)
        //{
        //    return CheckSlope(input, 1, 1)
        //        * CheckSlope(input, 3, 1)
        //        * CheckSlope(input, 5, 1)
        //        * CheckSlope(input, 7, 1)
        //        * CheckSlope(input, 1, 2)
        //        ;
        //}



        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day04.txt");
            Console.WriteLine("Day04a : {0}", Day04a(lines));
            //Console.WriteLine("Day04b : {0}", Day04b(lines));
        }
    }
}
