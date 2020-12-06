using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day03
    {
        public static Int64 Day03a(string[] input)
        {
            var right = 3;
            var down = 1;
            return CheckSlope(input, right, down);
        }

        public static Int64 Day03b(string[] input)
        {
            return CheckSlope(input, 1, 1)
                * CheckSlope(input, 3, 1)
                * CheckSlope(input, 5, 1)
                * CheckSlope(input, 7, 1)
                * CheckSlope(input, 1, 2)
                ;
        }

        private static Int64 CheckSlope(string[] input, int right, int down)
        {
            var len = input[0].Length;
            var x = 0;
            var y = 0;
            var hit = 0;
            do
            {
                if (input[y][x % len] == '#') hit++;

                x += right;
                y += down;
            } while (y < input.Count());

            return hit;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day03.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day03a : {0}   Time: {1}", Day03a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day03b : {0}   Time: {1}", Day03b(lines), sw.ElapsedMilliseconds);
        }
    }
}
