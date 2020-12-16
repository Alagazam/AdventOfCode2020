using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day11Test
    {
        public Day11Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }


        string input =
@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL
";

        [Fact]
        public void Day11a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(37, Day11.Day11a(lines));
        }


        [Fact]
        public void Day11b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(26, Day11.Day11b(lines));
        }
    }

}
