using System;
using Xunit;

namespace AoC2020
{
    public class Day08Test
    {
        string input =
@"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

        [Fact]
        public void Day08a()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(5, Day08.Day08a(lines));
        }


        [Fact]
        public void Day08b()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(8, Day08.Day08b(lines));
        }
    }

}
