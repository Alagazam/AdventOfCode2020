using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day17Test
    {
        string input =
@".#.
..#
###
";

        [Fact]
        public void Day17a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(112, Day17.Day17a(lines));
        }


        [Fact]
        public void Day17b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(0, Day17.Day17b(lines));
        }

        public Day17Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
