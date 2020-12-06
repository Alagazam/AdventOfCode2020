using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day01
    {
        public static int Day01a(IEnumerable<string> input)
        {
            var ints = input.Select(x => int.Parse(x));
            foreach (var x in ints)
            {
                foreach (var y in ints)
                {
                    if (x + y == 2020) return x * y;
                }
            }
            return 0;
        }

        public static int Day01b(IEnumerable<string> input)
        {
            var ints = input.Select(x => int.Parse(x));
            foreach (var x in ints)
            {
                foreach (var y in ints)
                {
                    foreach (var z in ints)
                    {
                        if (x + y + z == 2020) return x * y * z;
                    }
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day01.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day01a : {0}   Time: {1}", Day01a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day01b : {0}   Time: {1}", Day01b(lines), sw.ElapsedMilliseconds);
        }
    }
}
