using System;
using Xunit;

namespace AoC2020
{
    public class Day06Test
    {
        string input =
@"abc

a
b
c

ab
ac

a
a
a
a

b
";

        [Fact]
        public void Day06a()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(11, Day06.Day06a(lines));
        }


        [Fact]
        public void Day06b()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(6, Day06.Day06b(lines));
        }
    }

}
