using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode2018.DayEleven;

namespace Tests
{
    public class DayEleven
    {
        ITestOutputHelper output;

        public DayEleven (ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ExamplePartOne()
        {
            var cc = new ChronalCharge(18);
            var answer = cc.PartOne();

            Assert.Equal((33, 45), answer);
        }

        [Fact]
        public void PartOne()
        {
            var cc = new ChronalCharge(6878);
            var answer = cc.PartOne();

            Assert.Equal((20, 34), answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var cc = new ChronalCharge(18);
            var answer = cc.PartTwo();

            Assert.Equal((90, 269, 16), answer);
        }

        [Fact]
        public void PartTwo()
        {
            var cc = new ChronalCharge(6878);
            var answer = cc.PartTwo();

            Assert.Equal((90, 57, 15), answer);
        }
    }
}