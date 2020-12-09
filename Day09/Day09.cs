using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day09
    {
        public static Int64 Day09a(string[] input, int preAmble)
        {
            var intArray = Array.ConvertAll(input, s => Int64.Parse(s));

            for (var i = preAmble; i!=intArray.Length; ++i)
            {
                bool found = false;
                for (var first=i- preAmble; first != i-1; ++ first)
                {
                    for (var secnd=first+1; secnd != i; ++ secnd)
                    {
                        if (intArray[first] + intArray[secnd] == intArray[i])
                        {
                            found = true;
                            break;
                        }
                    }
//                    if (found) break;
                }
                if (!found) return intArray[i];
            }
            return 0;
        }

        public static Int64 Day09b(string[] input, Int64 expSum)
        {
            var intArray = Array.ConvertAll(input, s => Int64.Parse(s));
            var first = 0;
            var secnd = 0;
            bool found = false;
            for (first = 0; first != input.Length; ++first)
            {
                var sum = intArray[first];
                for (secnd = first+1; secnd != input.Length; ++secnd)
                {
                    sum += intArray[secnd];
                    if (sum == expSum) found = true;
                    if (sum >= expSum) break;
                }
                if (found) break;
            }
            var min = Int64.MaxValue;
            var max = Int64.MinValue;
            for (var i  = first; i != secnd+1; ++i)
            {
                if (intArray[i] < min) min = intArray[i];
                if (intArray[i] > max) max = intArray[i];
            }

            return min + max;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day09.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day09a : {0}   Time: {1}", Day09a(lines, 25), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day09b : {0}   Time: {1}", Day09b(lines, Day09a(lines, 25)), sw.ElapsedMilliseconds);
        }
    }
}
