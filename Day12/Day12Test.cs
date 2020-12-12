using System;
using Xunit;

namespace AoC2020
{
    public class Day12Test
    {
        string input =
@"F10
N3
F7
R90
F11
";

        [Fact]
        public void Day12a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(25, Day12.Day12a(lines));
        }

        string input2 =
@"F10
N3
F7
L90
F11
";

        [Fact]
        public void Day12b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(286, Day12.Day12b(lines));

            var lines2 = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(274, Day12.Day12b(lines2));
        }
    }

}
