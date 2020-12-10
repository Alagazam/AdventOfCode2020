using System;
using Xunit;

namespace AoC2020
{
    public class Day10Test
    {
        string input =
@"16
10
15
5
1
11
7
19
6
12
4";
        string input2 =
@"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

        [Fact]
        public void Day10a()
        {
            var lines = input.Split(new[] {"\r\n","\r", "\n"}, StringSplitOptions.None);

            Assert.Equal(7 * 5, Day10.Day10a(lines));
        }

        [Fact]
        public void Day10a_2()
        {
            var lines = input2.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            Assert.Equal(22 * 10, Day10.Day10a(lines));
        }


        [Fact]
        public void Day10b()
        {
            var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            Assert.Equal(8, Day10.Day10b(lines));
        }

        [Fact]
        public void Day10b_2()
        {
            var lines = input2.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            Assert.Equal(19208, Day10.Day10b(lines));
        }
    }

}
