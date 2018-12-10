using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayTen;

namespace Tests
{
    public class DayTen
    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var mm = new Starter(lines);
            var answer = 1; // mm.PartOne();

            Assert.Equal(138, answer);
        }

        [Fact]
        public void PartOne()
        {
            var mm = new Starter(@"C:\Users\joshu\github\AdventOfCode2018\src\DayTen\input.txt");
            var answer = 1; // mm.PartOne();

            Assert.Equal(44893, answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var mm = new Starter(lines);
            var answer = 1; //mm.PartTwo();

            Assert.Equal(66, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var mm = new Starter(@"C:\Users\joshu\github\AdventOfCode2018\src\DayTen\input.txt");
            var answer = 1; // mm.PartTwo();

            Assert.Equal(27433, answer);
        }
    }
}