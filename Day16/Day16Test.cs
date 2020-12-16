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


        [Fact]
        public void Day16b()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(0, Day16.Day16b(lines));
        }

        public Day16Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
