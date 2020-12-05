using System;
using Xunit;

namespace AoC2020
{
    public class Day01Test
    {
        string input =
@"1721
979
366
299
675
1456";

        [Fact]
        public void Day01a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(514579, Day01.Day01a(lines));
        }

        [Fact]
        public void Day01b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(241861950, Day01.Day01b(lines));
        }
    }

}
