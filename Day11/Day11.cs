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
        public static Int64 Day11a(string[] input)
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

                for (int row= 0; row != seats.Length; ++row)
                {
                    updatedSeats[row] = new StringBuilder();
                    for (int seat = 0; seat != seats[row].Length; ++seat)
                    {
                        var count = 0;
                        if (row-1 >= 0 && seat-1 >= 0                   && seats[row-1][seat-1] == '#') ++count;
                        if (row-1 >= 0                                  && seats[row-1][seat  ] == '#') ++count;
                        if (row-1 >= 0 && seat+1 < seats[row].Length    && seats[row-1][seat+1] == '#') ++count;

                        if (seat-1 >= 0                  && seats[row][seat-1] == '#') ++count;
                        if (seat+1 < seats[row].Length   && seats[row][seat+1] == '#') ++count;

                        if (row+1 < seats.Length && seat-1 >= 0                 && seats[row + 1][seat - 1] == '#') ++count;
                        if (row+1 < seats.Length                                && seats[row + 1][seat] == '#') ++count;
                        if (row+1 < seats.Length && seat+1 < seats[row].Length  && seats[row + 1][seat + 1] == '#') ++count;

                        if (seats[row][seat] == 'L' && count == 0)
                        {
                            updatedSeats[row].Append('#');
                            change = true;
                            occupied++;
                        }
                        else if (seats[row][seat] == '#' && count >= 4)
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

        public static Int64 Day11b(string[] input)
        {
            return 0;
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
