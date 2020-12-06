using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day05
    {
        static int Boarding2Seat(string bp)
        {
            int seatID = 0;
            foreach(var c in bp)
            {
                seatID *= 2;
                if (c == 'B' || c == 'R') seatID++;
            }
            return seatID;
        }

        public static Int64 Day05a(string[] input)
        {
            var maxSeat = 0;
            foreach (var boardingPass in input)
            {
                var seatID = Boarding2Seat(boardingPass);
                if (seatID > maxSeat) maxSeat = seatID;
            }
            return maxSeat;
        }

        public static Int64 Day05b(string[] input)
        {
            var seats = new SortedSet<int>();
            foreach (var boardingPass in input)
            {
                var seatID = Boarding2Seat(boardingPass);
                seats.Add(seatID);
            }
            int prev = 9999;
            foreach (var seat in seats)
            {
                if (seat > prev + 1) return seat - 1;
                prev = seat;
            }
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day05.txt");
            Console.WriteLine("Day05a : {0}", Day05a(lines));
            Console.WriteLine("Day05b : {0}", Day05b(lines));
        }
    }
}
