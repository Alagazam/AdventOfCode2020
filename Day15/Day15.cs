using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day15
    {
        public static Int64 Count(string input, int stop)
        {
            var spoken = new Dictionary<int, Tuple<int, int>>();
            var begin = input.Split(',');
            var index = 0;
            var lastSpoken = -1;
            foreach (var number in begin)
            {
                ++index;
                lastSpoken = int.Parse(number);
                spoken[lastSpoken] = new Tuple<int, int>(index, index);
            }
            // 0 3 6 0 3 3 1 0 4 0
            // 1 2 3 4 5 6 7 8 9 10
            while (index < stop)
            {
                ++index;
                var speakTup = spoken[lastSpoken];
                var speak = speakTup.Item2 - speakTup.Item1;
                if (!spoken.ContainsKey(speak))
                    spoken[speak] = new Tuple<int, int>(index, index);
                else
                {
                    var tup = spoken[speak];
                    spoken[speak] = new Tuple<int, int>(tup.Item2, index);
                }
                lastSpoken = speak;
                //Console.WriteLine(lastSpoken);
            }
            return lastSpoken;
        }
        public static Int64 Day15a(string[] input)
        {
            return Count(input[0], 2020);
        }

        public static Int64 Day15b(string[] input)
        {
            return Count(input[0], 30000000);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day15.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day15a : {0}   Time: {1}", Day15a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day15b : {0}   Time: {1}", Day15b(lines), sw.ElapsedMilliseconds);
        }
    }
}
