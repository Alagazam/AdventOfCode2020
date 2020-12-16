using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day15Test
    {
        string input =
@"0,3,6";

        [Fact]
        public void Day15a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(436, Day15.Day15a(lines));
        }
        [Fact]
        public void Day15a_1()
        {
            var lines = "1,3,2".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1, Day15.Day15a(lines));
        }
        [Fact]
        public void Day15a_2()
        {
            var lines = "2,1,3".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(10, Day15.Day15a(lines));
        }
        [Fact]
        public void Day15a_3()
        {
            var lines = "1,2,3".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(27, Day15.Day15a(lines));
        }
        [Fact]
        public void Day15a_4()
        {
            var lines = "2,3,1".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(78, Day15.Day15a(lines));
        }
        [Fact]
        public void Day15a_5()
        {
            var lines = "3,2,1".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(438, Day15.Day15a(lines));
        }
        [Fact]
        public void Day15a_6()
        {
            var lines = "3,1,2".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1836, Day15.Day15a(lines));
        }

        [Fact]
        public void Day15b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(175594, Day15.Day15b(lines));
        }

        public Day15Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
