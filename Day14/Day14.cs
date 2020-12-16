using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day14
    {
        public static Int64 Day14a(string[] input)
        {
            UInt64 andMask = UInt64.MaxValue;
            UInt64 orMask = 0;
            var memory = new Dictionary<UInt64, UInt64>();
            foreach (var line in input)
            {
                var loc = 0;
                UInt64 value = 0;
                if (line[..4] == "mask")
                {
                    andMask = UInt64.MaxValue;
                    orMask = 0;
                    var mask = line[7..];
                    foreach (var c in mask)
                    {
                        orMask <<= 1;
                        andMask <<= 1;
                        if (c == '1') orMask |= 1;
                        if (c != '0') andMask |= 1;
                    }
                }
                else if (line[..3] == "mem")
                {
                    var endBracket = line.IndexOf(']');
                    var index = UInt64.Parse(line[4..endBracket]);
                    var equalSign = line.IndexOf('=');
                    var val = UInt64.Parse(line[(equalSign + 2)..]);
                    memory[index] = val & andMask | orMask;
                }
            }
            UInt64 sum = 0;
            foreach (var mem in memory) sum += mem.Value;
            return (Int64)sum;
        }

        static void SetMem(UInt64 address, string mask, UInt64 value, ref Dictionary<UInt64, UInt64> memory)
        {
            Console.WriteLine("SetMem(address={0}  mask={1}  value={2}", address, mask, value);

            bool containsX = false;
            for (var i = 0; i != mask.Length; ++i)
            {
                if (mask[i]=='X')
                {
                    containsX = true;
                    var zeroMask = mask[0..i] + '0' + mask[(i + 1)..];
                    SetMem(address, zeroMask, value, ref memory);
                    var oneMask = mask[0..i] + '1' + mask[(i + 1)..];
                    SetMem(address, oneMask, value, ref memory);
                }
            }
            if (!containsX )
            {
                var m = Convert.ToUInt64(mask, 2);
                var addr = address | m;
                Console.WriteLine("Value={0}  mask={1}  address={2}  arrd={3}", value, mask, address, addr);
                memory[addr] = value;
            }
        }

        public static Int64 Day14b(string[] input)
        {
            var memory = new Dictionary<UInt64, UInt64>();
            var mask = "";
            foreach (var line in input)
            {
                if (line[..4] == "mask")
                {
                    mask = line[7..];
                }
                else if (line[..3] == "mem")
                {
                    var endBracket = line.IndexOf(']');
                    var address = UInt64.Parse(line[4..endBracket]);
                    var equalSign = line.IndexOf('=');
                    var value = UInt64.Parse(line[(equalSign + 2)..]);
                    Console.WriteLine("SetMem(address={0}  mask={1}  value={2}", address, mask, value);

                    SetMem(address, mask, value, ref memory);
                }
            }
            UInt64 sum = 0;
            foreach (var mem in memory) sum += mem.Value;
            return (Int64)sum;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day14.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day14a : {0}   Time: {1}", Day14a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day14b : {0}   Time: {1}", Day14b(lines), sw.ElapsedMilliseconds);
        }
    }
}
