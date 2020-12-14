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
            var busses = input[1].Split(',');
            var busIDs = new List<Int64>();
            var busRem = new List<Int64>();

            // Bus listNr=0 arrives at  t  =>  t % ID = 0
            // Bus listNr=n arrives at  t+n  =>  t % ID = ID-n = rem
            for (var i = 0; i!= busses.Length; ++i)
            {
                if (busses[i] == "x") continue;
                var id = Int64.Parse(busses[i]);
                busIDs.Add(id);
                busRem.Add(id - i);
            }

            // Input:  num[] = {3, 4, 5}, rem[] = {2, 3, 1}

            // * x =  ( ∑ (rem[i]*pp[i]*inv[i]) ) % prod
            //   Where 0 <= i <= n-1

            //rem[i] is given array of remainders

            //prod is product of all given numbers
            //prod = num[0] * num[1] * ... * num[k-1]
            Int64 prod = 1;
            foreach (var id in busIDs) prod *= id;

            //pp[i] is product of all divided by num[i]
            //pp[i] = prod / num[i]
            var pp = new List<Int64>();
            foreach (var id in busIDs) pp.Add(prod/id);

            var inv = new List<Int64>();
            for (var i = 0; i != busIDs.Count; ++i)
                inv.Add(inverse(pp[i], busIDs[i]));

            //inv[i] = Modular Multiplicative Inverse of 
            //         pp[i] with respect to num[i]

            // Returns modulo inverse of a with respect to m using extended 
            // Euclid Algorithm. Refer below post for details: 
            // https://www.geeksforgeeks.org/multiplicative-inverse-under-modulo-m/ 
            Int64 inverse(Int64 a, Int64 m)
            {
                var m0 = m;
                var x0 = (Int64)0;
                var x1 = (Int64)1;

                if (m == 1)
                    return 0;

                // Apply extended Euclid Algorithm 
                while (a > 1)
                {
                    // q is quotient 
                    var q = a / m;
                    var t = m;

                    // m is remainder now, process same as 
                    // euclid's algo 
                    m = a % m;
                    a = t;
                    t = x0;
                    x0 = x1 - q * x0;
                    x1 = t;
                }
                // Make x1 positive 
                if (x1 < 0)
                    x1 += m0;

                return x1;
            }

            var x = (Int64)0;
            for (var i = 0; i != busIDs.Count; ++i)
            {
                x += busRem[i] * pp[i] * inv[i];
            }

            //Example:

            //Let us take below example to understand the solution
            //   num[] = {3, 4, 5}, rem[] = {2, 3, 1}
            //   prod  = 60 
            //   pp[]  = {20, 15, 12}
            //   inv[] = {2,  3,  3}  // (20*2)%3 = 1, (15*3)%4 = 1
            //                        // (12*3)%5 = 1

            //   x = (rem[0]*pp[0]*inv[0] + rem[1]*pp[1]*inv[1] + 
            //        rem[2]*pp[2]*inv[2]) % prod
            //     = (2*20*2 + 3*15*3 + 1*12*3) % 60
            //     = (40 + 135 + 36) % 60
            //     = 11

            return x % prod;
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
