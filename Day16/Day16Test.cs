using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day16Test
    {
        string input =
@"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12
";

        [Fact]
        public void Day16a()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(71, Day16.Day16a(lines));
        }


        string input2 =
        @"departure class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
20,1,1
3,9,18
15,1,5
5,14,9
";
        [Fact]
        public void Day16b()
        {
            var lines = input2.Split(Environment.NewLine);

            Assert.Equal(12, Day16.Day16b(lines));
        }

        public Day16Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
