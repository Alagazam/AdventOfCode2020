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

        public static int[] GetMyTicket(string[] input)
        {
            var index = 0;
            while (!input[index].StartsWith("your ticket")) ++index;
            ++index;
            var line = input[index];
            var ticketStrings = line.Split(',');
            var ticket = new int[ticketStrings.Length];
            ticket = Array.ConvertAll(ticketStrings, s => int.Parse(s));
            ++index;

            return ticket;
        }

        static bool IsValidInField(int value, TwoRanges fieldRanges)
        {
            return (value >= fieldRanges.Item1.Item1 &&
                value <= fieldRanges.Item1.Item2 ||
                value >= fieldRanges.Item2.Item1 &&
                value <= fieldRanges.Item2.Item2);
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
                        if (IsValidInField(value, field.Value))
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
            var fields = GetFields(input);
            var tickets = GetTickets(input);
            var validTickets = new Tickets();
            foreach (var ticket in tickets)
            {
                bool valid = true;
                foreach (var value in ticket)
                {
                    bool match = false;
                    foreach (var field in fields)
                    {
                        if (IsValidInField(value, field.Value))
                        {
                            match = true;
                            break;
                        }
                    }
                    if (!match)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    validTickets.Add(ticket);
            }

            var myTicketProduct = 1L;
            var myTicket = GetMyTicket(input);

            var remainingFields = fields.ToDictionary(f => f.Key, f => f.Value);
            var remainingPositions = new SortedSet<int>();
            for (var position = 0; position != tickets[0].Length; ++position) 
                remainingPositions.Add(position);

            while (remainingPositions.Count > 0)
            {
                var matchPos = -1;
                foreach (var pos in remainingPositions)
                {
                    var matchField = "";
                    foreach (var field in remainingFields)
                    {
                        var match = true;
                        foreach (var ticket in validTickets)
                        {
                            if (!IsValidInField(ticket[pos], field.Value))
                            {
                                match = false;
                                break;
                            }
                        }
                        if (match)
                        {
                            if (matchField.Length == 0)
                                matchField = field.Key;
                            else // multiple match
                            {
                                matchField = "";
                                break;
                            }
                        }
                    }
                    if (matchField != "")
                    {
                        if (matchField.StartsWith("departure"))
                            myTicketProduct *= myTicket[pos];
                        matchPos = pos;
                        remainingFields.Remove(matchField);
                        break;
                    }
                }
                remainingPositions.Remove(matchPos);
            }
            return myTicketProduct;
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
