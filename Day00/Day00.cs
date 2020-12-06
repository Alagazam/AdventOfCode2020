using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day00
    {
        public static Int64 Day00a(string[] input)
        {
            return 0;
        }

        public static Int64 Day00b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day00.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day00a : {0}   Time: {1}", Day00a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day00b : {0}   Time: {1}", Day00b(lines), sw.ElapsedMilliseconds);
        }
    }
}
