using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day18Test
    {
        string input =
@"1 + 2 * 3 + 4 * 5 + 6
1 + (2 * 3) + (4 * (5 + 6))
2 * 3 + (4 * 5)
5 + (8 * 3 + 9 + 3 * 4 * 3)
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2
";

        [Fact]
        public void Day18a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(71, Day18.Day18a(new string[] { lines[0] }));
            Assert.Equal(51, Day18.Day18a(new string[] { lines[1] }));
            Assert.Equal(26, Day18.Day18a(new string[] { lines[2] }));
            Assert.Equal(437, Day18.Day18a(new string[] { lines[3] }));
            Assert.Equal(12240, Day18.Day18a(new string[] { lines[4] }));
            Assert.Equal(13632, Day18.Day18a(new string[] { lines[5] }));
            Assert.Equal(71 + 51 + 26 + 437 + 12240 + 13632, Day18.Day18a(lines));
        }


        [Fact]
        public void Day18b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(0, Day18.Day18b(lines));
        }

        public Day18Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
