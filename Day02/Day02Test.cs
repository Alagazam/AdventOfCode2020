using System;
using Xunit;

namespace AoC2020
{
    public class Day02Test
    {
        string input =
@"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

        [Fact]
        public void Day02a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(2, Day02.Day02a(lines));
        }

        [Fact]
        public void Day02b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(1, Day02.Day02b(lines));
        }
    }

}
