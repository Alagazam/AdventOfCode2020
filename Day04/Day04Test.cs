using System;
using Xunit;

namespace AoC2020
{
    public class Day04Test
    {
        string input =
@"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in
";

        [Fact]
        public void Day04a()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(2, Day04.Day04a(lines));
        }

        [Fact]
        public void Day04aOneLine()
        {
            var lines = @"hgt:173cm byr:1925 pid:070222017 iyr:2013 hcl:#ceb3a1 ecl:gry eyr:2024".Split(Environment.NewLine);

            Assert.Equal(1, Day04.Day04a(lines));
        }

        //[Fact]
        //public void Day04b()
        //{
        //    var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        //    Assert.Equal(336, Day04.Day04b(lines));
        //}
    }

}
