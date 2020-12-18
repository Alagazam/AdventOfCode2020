using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day17
    {
        public static Int64 Day17a(string[] input)
        {
            var inputSize = input[0].Length;
            var size = input[0].Length + 2 * 6;
            var grid = new bool[size, size, size];

            var x = (size - inputSize) / 2;
            var y = (size - inputSize) / 2;
            var z = size / 2;
            foreach (var line in input)
            {
                if (line == "") break;
                x = (size - inputSize) / 2;
                foreach (var c in line)
                {
                    grid[x, y, z] = (c == '#');
                    ++x;
                }
                ++y;
            }
            //for (z = 0; z != size; ++z)
            //{
            //    Console.WriteLine("z={0}", z);
            //    for (y = 0; y != size; ++y)
            //    {
            //        for (x = 0; x != size; ++x)
            //        {
            //            Console.Write((grid[x, y, z] ? '#' : '.'));
            //        }
            //        Console.WriteLine("");
            //    }
            //}

            var setCount = 0;
            for (var round = 0; round != 6; ++round)
            {
                setCount = 0;
                var newGrid = new bool[size, size, size];
                for (z = 0; z != size; ++z)
                {
                    //Console.WriteLine("z={0}", z);
                    for (y = 0; y != size; ++y)
                    {
                        for (x = 0; x != size; ++x)
                        {
                            var neightbours = 0;
                            for (var dx = -1; dx != 2; ++dx)
                            {
                                if (x + dx < 0) continue;
                                if (x + dx >= size) continue;
                                for (var dy = -1; dy != 2; ++dy)
                                {
                                    if (y + dy < 0) continue;
                                    if (y + dy >= size) continue;
                                    for (var dz = -1; dz != 2; ++dz)
                                    {
                                        if (z + dz < 0) continue;
                                        if (z + dz >= size) continue;
                                        if (dx == 0 && dy == 0 && dz == 0) continue;
                                        if (grid[x + dx, y + dy, z + dz]) ++neightbours;
                                    }
                                }
                            }
                            if (grid[x, y, z])
                                newGrid[x, y, z] = (neightbours == 2 || neightbours == 3);
                            else
                                newGrid[x, y, z] = (neightbours == 3);
                            if (newGrid[x, y, z]) ++setCount;
                            //Console.Write((newGrid[x, y, z] ? '#' : '.'));
                        }
                        //Console.WriteLine("");
                    }
                }
                grid = newGrid;
            }
            return setCount;
        }

        public static Int64 Day17b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day17.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day17a : {0}   Time: {1}", Day17a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day17b : {0}   Time: {1}", Day17b(lines), sw.ElapsedMilliseconds);
        }
    }
}
