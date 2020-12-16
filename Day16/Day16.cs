using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace AoC2020
{
    using FieldRange = Tuple<int, int>;
    using TwoRanges = Tuple<Tuple<int, int>, Tuple<int, int>>;
    using Fields = Dictionary<string, Tuple<Tuple<int, int>, Tuple<int, int>>>;
    using Tickets = List<int[]>;

    public class Day16
    {
        public static Fields GetFields(string[] input)
        {
            var fields = new Fields();
            var index = 0;
            while (!input[index].StartsWith("your ticket"))
            {
                var line = input[index];
                if (line.Length==0) { ++index; continue; }
                var split = line.Split(':');
                var fieldname = split[0];
                var ranges = split[1].Split(' ');
                var r1 = ranges[1].Split('-');
                var r2 = ranges[3].Split('-');
                var range1 = new FieldRange(int.Parse(r1[0]), int.Parse(r1[1]));
                var range2 = new FieldRange(int.Parse(r2[0]), int.Parse(r2[1]));
                fields[fieldname] = new TwoRanges(range1, range2);
                ++index;
            }
            return fields;
        }
        public static Tickets GetTickets(string[] input)
        {
            var tickets = new Tickets();
            var index = 0;
            while (!input[index].StartsWith("nearby tickets")) ++index;
            ++index;
            while (index != input.Length)
            {
                var line = input[index];
                if (line.Length == 0) { ++index; continue; }
                var ticket = line.Split(',');
                var intTicket = Array.ConvertAll(ticket, s => int.Parse(s));
                tickets.Add(intTicket);
                ++index;
            }
            return tickets;
        }

        public static Int64 Day16a(string[] input)
        {
            var fields = GetFields(input);
            var tickets = GetTickets(input);
            var sumInvalidFields = 0L;
            foreach (var ticket in tickets)
            {
                foreach (var value in ticket)
                {
                    bool match = false;
                    foreach (var field in fields)
                    {
                        if (value >= field.Value.Item1.Item1 &&
                            value <= field.Value.Item1.Item2 ||
                            value >= field.Value.Item2.Item1 &&
                            value <= field.Value.Item2.Item2)
                        {
                            match = true;
                            break;
                        }
                    }
                    if (!match)
                        sumInvalidFields += value;
                }
            }
            return sumInvalidFields;
        }

        public static Int64 Day16b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day16.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day16a : {0}   Time: {1}", Day16a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day16b : {0}   Time: {1}", Day16b(lines), sw.ElapsedMilliseconds);
        }
    }
}
