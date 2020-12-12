using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day12
    {
        public static Int64 Day12a(string[] input)
        {
            var x = 0;
            var y = 0;
            var dir = 0;
            var directions = "ESWN";

            foreach (var line in input)
            {
                var instr = line[0];
                var oper = int.Parse(line[1..]);
                switch (instr)
                {
                    case 'R': dir = (dir + oper / 90); if ( dir > 3 ) dir -= 4; break;
                    case 'L': dir = (dir - oper / 90); if ( dir < 0 ) dir += 4; break;
                    case 'F': instr = directions[dir]; break;
                }
                switch (instr)
                {
                    case 'E': x += oper; break;
                    case 'N': y += oper; break;
                    case 'W': x -= oper; break;
                    case 'S': y -= oper; break;
                }
            }
            return Math.Abs(x)+ Math.Abs(y);
        }

        public static Int64 Day12b(string[] input)
        {
            var wpx = 10;
            var wpy = 1;
            var x = 0;
            var y = 0;

            static void swap(ref int a, ref int b) { var t = a; a = b; b = t; };

            foreach (var line in input)
            {
                var instr = line[0];
                var oper = int.Parse(line[1..]);
                var rot = 0;
                switch (instr)
                {
                    case 'L': rot = oper / 90; break;
                    case 'R': rot = 4 - oper / 90; break;
                    case 'F': x += wpx * oper; y += wpy * oper; break;
                    case 'E': wpx += oper; break;
                    case 'N': wpy += oper; break;
                    case 'W': wpx -= oper; break;
                    case 'S': wpy -= oper; break;
                }
                switch (rot)
                {
                    case 0: break;
                    case 1: swap(ref wpx, ref wpy); wpx = -wpx; break;
                    case 2: wpx = -wpx; wpy = -wpy; break;
                    case 3: swap(ref wpx, ref wpy); wpy = -wpy; break;
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day12.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day12a : {0}   Time: {1}", Day12a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day12b : {0}   Time: {1}", Day12b(lines), sw.ElapsedMilliseconds);
        }
    }
}
