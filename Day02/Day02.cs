using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day02
    {
        public static int Day02a(IEnumerable<string> input)
        {
            var valid_pw = 0;
            foreach (var line in input)
            {
                var tokens = line.Split();
                var minmax = tokens[0].Split('-');
                var min = int.Parse(minmax[0]);
                var max = int.Parse(minmax[1]);
                var c = tokens[1][0];
                var pw = tokens[2];
                var c_count = pw.Count(x => x == c);
                if (c_count >= min && c_count <= max) valid_pw++;
            }
            return valid_pw;
        }

        public static int Day02b(IEnumerable<string> input)
        {
            var valid_pw = 0;
            foreach (var line in input)
            {
                var tokens = line.Split();
                var minmax = tokens[0].Split('-');
                var pos1 = int.Parse(minmax[0]) -1;
                var pos2 = int.Parse(minmax[1]) -1;
                var c = tokens[1][0];
                var pw = tokens[2];
                if (pw[pos1] != c ^ pw[pos2] != c) valid_pw++;
            }
            return valid_pw;
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day02.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day02a : {0}   Time: {1}", Day02a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day02b : {0}   Time: {1}", Day02b(lines), sw.ElapsedMilliseconds);
        }
    }
}
