using System;
using Xunit;

namespace AoC2020
{
    public class Day09Test
    {
        string input =
@"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

        [Fact]
        public void Day09a()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(127, Day09.Day09a(lines, 5));
        }


        [Fact]
        public void Day09b()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(62, Day09.Day09b(lines, Day09.Day09a(lines, 5)));
        }
    }

}
