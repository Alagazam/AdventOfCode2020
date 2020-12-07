using System;
using Xunit;

namespace AoC2020
{
    public class Day07Test
    {
        string input =
@"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.
";

        string input2 =
@"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.
";

        [Fact]
        public void Day07a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(4, Day07.Day07a(lines));
        }


        [Fact]
        public void Day07b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(32, Day07.Day07b(lines));
        }

        [Fact]
        public void Day07b_2()
        {
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(126, Day07.Day07b(lines));
        }


        [Fact]
        public void TestBag()
        {
            var bag = new Day07.Bag("light red bags contain 1 bright white bag, 2 muted yellow bags.");
            Assert.Equal("light red", bag.color);
            Assert.Equal(2, bag.canContain.Count);
            Assert.Equal(1, bag.canContain["bright white"]);
            Assert.Equal(2, bag.canContain["muted yellow"]);

            var bag2 = new Day07.Bag("faded blue bags contain no other bags.");
            Assert.Equal("faded blue", bag2.color);
            Assert.Empty(bag2.canContain);
        }

    }
}
