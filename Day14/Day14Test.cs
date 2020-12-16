using System;
using Xunit;
using Xunit.Abstractions;


namespace AoC2020
{
    public class Day14Test
    {
        string input =
@"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0
";

        [Fact]
        public void Day14a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(165, Day14.Day14a(lines));
        }

        string input2 =
@"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1
";
        [Fact]
        public void Day14b()
        {
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(208, Day14.Day14b(lines));
        }


        public Day14Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }


    }

}
