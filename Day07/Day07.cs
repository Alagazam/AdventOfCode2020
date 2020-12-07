using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day07
    {
        public class Bag : IComparable
        {
            // light red bags contain 1 bright white bag, 2 muted yellow bags.
            public Bag(string text)
            {
                canContain = new Dictionary<string, int>();
                var cursor = text.IndexOf("bags");
                color = text.Substring(0, cursor-1);
                cursor = text.IndexOf("contain") + "contain".Length;
                while (cursor >= 0  && cursor < text.Length)
                {
                    var next = text.IndexOf("bag", cursor);
                    var number = text.Substring(cursor+1, 2);
                    if (number != "no")
                    {
                        var count = int.Parse(number);
                        cursor += 3;
                        var col = text.Substring(cursor, next - cursor - 1);
                        canContain.Add(col, count);
                        cursor = text.IndexOf(" ", next + 4);
                    }
                    else 
                        break;
                }
            }

            public string color;
            public Dictionary<string, int> canContain;

            public int CompareTo(object obj)
            {
                var bag = obj as Bag;
                return color.CompareTo(bag.color);
            }
        }

        public static Int64 Day07a(string[] input)
        {
            var bags = new SortedSet<Bag>();
            var withShinyGold = new SortedSet<Bag>();

            foreach (var line in input)
            {
                var bag = new Bag(line);
                bags.Add(bag);
            }
            withShinyGold.Add(bags.First(x => x.color.Equals("shiny gold")));
            bool added = true;
            while (added)
            {
                var newBags = new SortedSet<Bag>();
                added = false;
                foreach (var bag in bags)
                {
                    foreach (var shinyBag in withShinyGold)
                    {
                        if (bag.canContain.ContainsKey(shinyBag.color)
                            && !withShinyGold.Contains(bag))
                        {
                            newBags.Add(bag);
                            added = true;
                        }
                    }
                }
                foreach (var bag in newBags)
                {
                    withShinyGold.Add(bag);
                }
            }
            return withShinyGold.Count -1;
        }


        public static int BagCount(SortedSet<Bag> bags, string bagColor)
        {
            var bag = bags.First(x => x.color.Equals(bagColor));
            var count = 0;
            foreach (var innerBag in bag.canContain)
            {
                count += innerBag.Value;
                count += innerBag.Value * BagCount(bags, innerBag.Key);
            }
            return count;

        }

        public static Int64 Day07b(string[] input)
        {
            var bags = new SortedSet<Bag>();
            var withShinyGold = new SortedSet<Bag>();

            foreach (var line in input)
            {
                var bag = new Bag(line);
                bags.Add(bag);
            }

            return BagCount(bags, "shiny gold");
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day07.txt");
            Console.WriteLine("Day07a : {0}", Day07a(lines));
            Console.WriteLine("Day07b : {0}", Day07b(lines));
        }
    }
}
