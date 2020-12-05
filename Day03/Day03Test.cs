using System;
using Xunit;

namespace AoC2020
{
    public class Day03Test
    {
        string input =
@"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

        [Fact]
        public void Day03a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(7, Day03.Day03a(lines));
        }

        [Fact]
        public void Day03b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(336, Day03.Day03b(lines));
        }
    }

}
