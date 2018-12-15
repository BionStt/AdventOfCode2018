using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayFourteen;

namespace Tests
{
    public class DayFourteen
    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var cc = new ChocolateCharts(37);
            var answer = cc.PartOne(9);

            Assert.Equal("5158916779", answer);
        }

        [Fact]
        public void ExamplePartOne2()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var cc = new ChocolateCharts(37);
            var answer = cc.PartOne(2018);

            Assert.Equal("5941429882", answer);
        }

        [Fact]
        public void PartOne()
        {
            var cc = new ChocolateCharts(380621);
            var answer = cc.PartOne(380621);

            Assert.Equal("6985103122", answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var cc = new ChocolateCharts(380621);
            cc.PartOne(380621);
            int answer = cc.PartTwo(380621);

            Assert.Equal(6985103122, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var cc = new ChocolateCharts(380621);
            var answer = cc.PartTwo(51589);

            Assert.Equal(9, answer);
        }
    }
}