using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayEight;

namespace Tests
{
    public class DayEight    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var mm = new MemoryManeuver(lines);
            var answer = mm.PartOne();

            Assert.Equal(138, answer);
        }

        [Fact]
        public void PartOne()
        {
            var mm = new MemoryManeuver(@"C:\Users\joshu\github\AdventOfCode2018\src\DayEight\input.txt");
            var answer = mm.PartOne();

            Assert.Equal(44893, answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var mm = new MemoryManeuver(lines);
            var answer = mm.PartTwo();

            Assert.Equal(66, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var mm = new MemoryManeuver(@"C:\Users\joshu\github\AdventOfCode2018\src\DayEight\input.txt");
            var answer = mm.PartTwo();

            Assert.Equal(27433, answer);
        }
    }
}