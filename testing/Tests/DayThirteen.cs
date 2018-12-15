using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayThirteen;

namespace Tests
{
    public class DayThirteen
    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                @"/->-\        ",
                @"|   |  /----\",
                @"| /-+--+-\  |",
                @"| | |  | v  |",
                @"\-+-/  \-+--/",
                @"  \------/   "
            };

            var mm = new MineCartMadness(lines);
            var answer = 1; // mm.PartOne();

            Assert.Equal(138, answer);
        }

        [Fact]
        public void PartOne()
        {
            var mm = new MineCartMadness(@"C:\Users\joshu\github\AdventOfCode2018\src\DayThirteen\input.txt");
            var answer = 1; // mm.PartOne();

            Assert.Equal(44893, answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                @"/->-\        ",
                @"|   |  /----\",
                @"| /-+--+-\  |",
                @"| | |  | v  |",
                @"\-+-/  \-+--/",
                @"  \------/   "
            };

            var mm = new MineCartMadness(lines);
            var answer = 1; //mm.PartTwo();

            Assert.Equal(66, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var mm = new MineCartMadness(@"C:\Users\joshu\github\AdventOfCode2018\src\DayThirteen\input.txt");
            var answer = 1; // mm.PartTwo();

            Assert.Equal(27433, answer);
        }
    }
}