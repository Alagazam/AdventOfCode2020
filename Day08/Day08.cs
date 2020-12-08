using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day08
    {
        public static Int64 Compute(string[] input, ref bool termOk, int swapErrorInstr = -1)
        {
            var pc = 0;
            var executed = new bool[input.Length];
            var acc = 0;
            while (pc < input.Length && !executed[pc])
            {
                executed[pc] = true;
                var inst = input[pc][..3];
                var operand = int.Parse(input[pc][4..]);

                if (pc == swapErrorInstr)
                {
                    if (inst == "jmp") inst = "nop";
                    else if (inst == "nop") inst = "jmp";
                }

                switch (inst)
                {
                    case "acc":
                        acc += operand;
                        pc++;
                        break;
                    case "jmp":
                        pc += operand;
                        break;
                    case "nop":
                        pc++;
                        break;
                }
            }
            termOk = (pc == input.Length);
            return acc;
        }

        public static Int64 Day08a(string[] input)
        {
            bool ok = false;
            return Compute(input, ref ok);
        }

        public static Int64 Day08b(string[] input)
        {
            Int64 res = 0;
            for (var i=0; i!= input.Length; ++i)
            {
                bool ok = false;
                res = Compute(input, ref ok, i);
                if (ok) return res;
            }
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day08.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day08a : {0}   Time: {1}", Day08a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day08b : {0}   Time: {1}", Day08b(lines), sw.ElapsedMilliseconds);
        }
    }
}
