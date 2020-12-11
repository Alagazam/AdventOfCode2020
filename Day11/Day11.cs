using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2020
{
    public class Day11
    {
        private static long Calculate(string[] input, int maxLength, int maxNeightbours)
        {
            bool change = true;
            var occupied = 0;
            var seats = new StringBuilder[input.Length];
            for (int row = 0; row != input.Length; ++row) { seats[row] = new StringBuilder(input[row]); };
            var updatedSeats = new StringBuilder[input.Length];
            while (change)
            {
                change = false;
                occupied = 0;

                for (int row = 0; row != seats.Length; ++row)
                {
                    updatedSeats[row] = new StringBuilder();
                    for (int seat = 0; seat != seats[row].Length; ++seat)
                    {
                        var count = CountSeen(seats, row, seat, maxLength);
                        if (seats[row][seat] == 'L' && count == 0)
                        {
                            updatedSeats[row].Append('#');
                            change = true;
                            occupied++;
                        }
                        else if (seats[row][seat] == '#' && count >= maxNeightbours)
                        {
                            updatedSeats[row].Append('L');
                            change = true;
                        }
                        else
                        {
                            updatedSeats[row].Append(seats[row][seat]);
                            if (seats[row][seat] == '#') occupied++;
                        }

                    }
                }
                updatedSeats.CopyTo(seats, 0);

                //foreach(var line in seats)
                //{
                //    Console.WriteLine(line);
                //}
                //Console.WriteLine(" ");
            }

            return occupied;
        }

        private static bool CheckDirection(StringBuilder[] seats, int row, int seat, int xDir, int yDir, int maxLength)
        {
            while (maxLength != 0)
            {
                --maxLength;
                row += yDir;
                seat += xDir;
                if (row >= 0 && row < seats.Length &&
                    seat >= 0 && seat < seats[row].Length)
                {
                    if (seats[row][seat] == '#') return true;
                    if (seats[row][seat] == 'L') return false;
                }
                else return false;
            }
            return false;
        }
        private static int CountSeen(StringBuilder[] seats, int row, int seat, int maxLength)
        {
            var count = 0;
            if (CheckDirection(seats, row, seat, -1, -1, maxLength)) ++count;
            if (CheckDirection(seats, row, seat, -1, 0, maxLength)) ++count;
            if (CheckDirection(seats, row, seat, -1, 1, maxLength)) ++count;
            if (CheckDirection(seats, row, seat, 0, -1, maxLength)) ++count;
            if (CheckDirection(seats, row, seat, 0, 1, maxLength)) ++count;
            if (CheckDirection(seats, row, seat, 1, -1, maxLength)) ++count;
            if (CheckDirection(seats, row, seat, 1, 0, maxLength)) ++count;
            if (CheckDirection(seats, row, seat, 1, 1, maxLength)) ++count;
            return count;
        }


        public static Int64 Day11a(string[] input)
        {
            return Calculate(input, 1, 4);
        }

        public static Int64 Day11b(string[] input)
        {
            return Calculate(input, int.MaxValue, 5);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day11.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day11a : {0}   Time: {1}", Day11a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day11b : {0}   Time: {1}", Day11b(lines), sw.ElapsedMilliseconds);
        }
    }
}
