using System;
using Xunit;

namespace AoC2020
{
    public class Day05Test
    {
        string input =
@"BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL";

        [Fact]
        public void Day05a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(820, Day05.Day05a(lines));
        }

        string input2 =
@"BFFFBBFRRR
BFFFBBFRLR
BFFFBBFRLL";
        [Fact]
        public void Day05b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(566, Day05.Day05b(lines));
        }
    }

}
