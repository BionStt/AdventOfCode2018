using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayNine;

namespace Tests
{
    public class DayNine
    {
        [Fact]
        public void ExamplePartOne()
        {   var mm = new MarbleMania(10, 1618);
            var answer = mm.PartOne();

            Assert.Equal(8317, answer);
        }

        [Fact]
        public void SimpleExample()
        {
            var mm = new MarbleMania(7, 25);
            var answer = mm.PartOne();

            Assert.Equal(32, answer);
        }

        [Fact]
        public void Ex2()
        {
            var mm = new MarbleMania(13, 7999);
            var answer = mm.PartOne();

            Assert.Equal(146373, answer);
        }

        [Fact]
        public void PartOne()
        {
            var mm = new MarbleMania(465, 71498);
            var answer = mm.PartOne();

            Assert.Equal(383475, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var mm = new MarbleMania(465, 100 * 71498);
            var answer = mm.PartOne();

            Assert.Equal(3148209772, answer);
        }
    }
}