using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day13
    {
        public static Int64 Day13a(string[] input)
        {
            var time = Int64.Parse(input[0]);
            var busses = input[1].Split(',');
            var minWait = Int64.MaxValue;
            Int64 minBusNr = 0;
            foreach (var bus in busses)
            {
                if (bus == "x") continue;
                var busNr = Int64.Parse(bus);
                var wait = busNr - time % busNr;
                if (wait < minWait)
                {
                    minWait = wait;
                    minBusNr = busNr;
                }
            }
            return minWait * minBusNr;
        }

        public static Int64 Day13b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day13.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day13a : {0}   Time: {1}", Day13a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day13b : {0}   Time: {1}", Day13b(lines), sw.ElapsedMilliseconds);
        }
    }
}
