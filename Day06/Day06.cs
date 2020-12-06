using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day06
    {
        public static Int64 Day06a(string[] input)
        {
            var sum = 0;
            var answers = new SortedSet<char>();
            foreach (var line in input)
            {
                if (!line.Equals(""))
                {
                    foreach (var c in line)
                    {
                        answers.Add(c);
                    }
                }
                if (line.Equals(""))
                {
                    sum += answers.Count;
                    answers.Clear();
                }
            }
            return sum;
        }

        public static Int64 Day06b(string[] input)
        {
            var sum = 0;
            var answers = new SortedSet<char>();
            var first = true;
            foreach (var line in input)
            {
                if (!line.Equals(""))
                {
                    if (first)
                    {
                        first = false;
                        foreach (var c in line)
                        {
                            answers.Add(c);
                        }
                    }
                    else
                    {
                        answers.RemoveWhere(c => !line.Contains(c));
                    }
                }
                if (line.Equals(""))
                {
                    sum += answers.Count;
                    answers.Clear();
                    first = true;
                }
            }
            return sum;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day06.txt");
            Console.WriteLine("Day06a : {0}", Day06a(lines));
            Console.WriteLine("Day06b : {0}", Day06b(lines));
        }
    }
}
