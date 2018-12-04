using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayTwo;

namespace Tests
{
    public class DayTwo
    {
        [Fact]
        public void SimpleInput()
        {
            var lines = new string[]
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };

            var fcs = new FindCheckSum(lines);
            var checksum = fcs.GetCheckSum();

            Assert.Equal(12, checksum);
        }

        [Fact]
        public void TheActualInput()
        {
            var fcs = new FindCheckSum(@"C:\Users\joshu\source\repos\AdventOfCode2018\AdventOfCode2018\DayTwo\input.txt");
            var checksum = fcs.GetCheckSum();

            Assert.Equal(6370, checksum);
        }

        [Fact]
        public void PartTwoTest()
        {
            var lines = new string[]
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };

            var fcs = new FindCheckSum(lines);
            var matchString = fcs.MatchesFromNearMatch();

            Assert.Equal("fgij", matchString);
        }

        [Fact]
        public void PartTwoActual()
        {
            var fcs = new FindCheckSum(@"C:\Users\joshu\source\repos\AdventOfCode2018\AdventOfCode2018\DayTwo\input.txt");
            var matchString = fcs.MatchesFromNearMatch();

            Assert.Equal("rmyxgdlihczskunpfijqcebtv", matchString);
        }
    }
}
