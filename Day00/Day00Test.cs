using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day00Test
    {
        string input =
@"";

        [Fact]
        public void Day00a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(0, Day00.Day00a(lines));
        }


        [Fact]
        public void Day00b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(0, Day00.Day00b(lines));
        }

        public Day00Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
