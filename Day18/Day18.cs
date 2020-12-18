using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day18
    {
        public static Int64 calc(string exp, out int lastIndex)
        {
            Console.WriteLine(exp);
            var acc = 0L;
            var op = ' ';
            lastIndex = 0;
            for (var index = 0; index != exp.Length; ++index)
            {
                var c = exp[index];
                if (c == '+')
                { op = '+'; }
                else if (c == '*')
                { op = '*';  }
                else if (c == '(')
                {
                    var li = 0;
                    ++index;
                    if (op == ' ') acc = calc(exp[index..], out li);
                    else if (op == '+') acc += calc(exp[index..], out li);
                    else if (op == '*') acc *= calc(exp[index..], out li);
                    index += li;
                }
                else if (c == ')')
                {
                    Console.WriteLine(acc);
                    lastIndex = index;
                    return acc;
                }
                else if (c>='0' && c<='9')
                {
                    var val = c - '0';
                    if (op == ' ') acc = val;
                    else if (op == '+') acc += val;
                    else if (op == '*') acc *= val;
                }
                lastIndex = index;
            }
            Console.WriteLine(acc);
            return acc;
        }

        public static Int64 Day18a(string[] input)
        {
            var sum = 0L;
            foreach (var line in input)
            {
                var li = 0;
                sum += calc(line, out li);
            }
            return sum;
        }

        public static Int64 Day18b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day18.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day18a : {0}   Time: {1}", Day18a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day18b : {0}   Time: {1}", Day18b(lines), sw.ElapsedMilliseconds);
        }
    }
}
