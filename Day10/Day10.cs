using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day10
    {
        public static Int64 Day10a(string[] input)
        {
            var intArray = new SortedSet<Int64>(input.Select(Int64.Parse));

            var diff1 = 0;
            var diff2 = 0;
            var diff3 = 1;  // one more for last hop
            Int64 prev = 0;
            foreach (var i in intArray)
            {
                if (i - prev == 1) diff1++;
                else if (i - prev == 2) diff2++;
                else if (i - prev == 3) diff3++;
                prev = i;
            }
            return diff1 * diff3;
        }

        public static Int64 Day10b(string[] input)
        {
            var intArray = new SortedSet<Int64>(input.Select(Int64.Parse));
            intArray.Add(0);
            intArray.Add(intArray.Max + 3);

            var runList = new Dictionary<int, int>();

            // Find out how long runs of one-gaps exists and how many
            Int64 prev = 0;
            int run = 0;
            foreach (var i in intArray)
            {
                if (i - prev == 1) run++;
                else if (run > 0)
                {
                    if (runList.ContainsKey(run))
                        runList[run]++;
                    else
                        runList.Add(run,1);
                    run = 0;
                }
                prev = i;
            }
            // Runs up to 4 gives this:
            //45 => 1   => 1  (45)
            //456  => 1 1  => 2  (456 / 4 6)
            //4567 => 1 1 1  => 4    (4567 / 4 67 / 45 7 / 4 7)
            //45678 => 1 1 1 1  => 7   (45678 / 4 678 / 45 78 / 456 8 / 4 6 8 / 4  78 / 45  8 )
            Int64 comb = 1;
            foreach(var r in runList)
            {
                switch (r.Key)
                {
                    case 1: break;
                    case 2: comb *= (Int64)Math.Pow(2, r.Value); break;
                    case 3: comb *= (Int64)Math.Pow(4, r.Value); break;
                    case 4: comb *= (Int64)Math.Pow(7, r.Value); break;
                    case 5: throw new ArgumentException();
                }
                Console.WriteLine("run:" + r.ToString());
            }

            return comb;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day10.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day10a : {0}   Time: {1}", Day10a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day10b : {0}   Time: {1}", Day10b(lines), sw.ElapsedMilliseconds);
        }
    }
}
