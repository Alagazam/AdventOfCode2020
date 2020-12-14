using System;
using Xunit;

namespace AoC2020
{
    public class Day13Test
    {
        string input =
@"939
7,13,x,x,59,x,31,19
";

        [Fact]
        public void Day13a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(295, Day13.Day13a(lines));
        }

        [Fact]
        public void Day13b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1068781, Day13.Day13b(lines));
        }

        string input2 =
@"939
17,x,13,19
";      // is 3417.
        [Fact]
        public void Day13b_2()
        {
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(3417, Day13.Day13b(lines));
        }

        string input3 =
@"939
67,7,59,61
";      //  first occurs at timestamp 754018.
        [Fact]
        public void Day13b_3()
        {
            var lines = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(754018, Day13.Day13b(lines));
        }

        string input4 =
@"939
67,x,7,59,61
";      // first occurs at timestamp 779210.

        [Fact]
        public void Day13b_4()
        {
            var lines = input4.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(779210, Day13.Day13b(lines));
        }

        string input5 =
@"939
67,7,x,59,61
";      // first occurs at timestamp 1261476.

        [Fact]
        public void Day13b_5()
        {
            var lines = input5.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1261476, Day13.Day13b(lines));
        }

        string input6 =
@"939
1789,37,47,1889
";      // first occurs at timestamp 1202161486.
        [Fact]
        public void Day13b_6()
        {
            var lines = input6.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1202161486, Day13.Day13b(lines));
        }
    }

}
