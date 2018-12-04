using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayThree;

namespace Tests
{
    public class DayThree
    {
        [Fact]
        public void ExampleText()
        {
            var lines = new string[]
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };

            FabricDistribution fd = new FabricDistribution(lines);
            int count = fd.GetMultipleUseCount();

            Assert.Equal(4, count);
        }

        [Fact]
        public void ActualPartOne()
        {
            FabricDistribution fd = new FabricDistribution(@"C:\Users\joshu\source\repos\AdventOfCode2018\AdventOfCode2018\DayThree\Input.txt");
            int count = fd.GetMultipleUseCount();

            Assert.Equal(103806, count);
        }

        [Fact]
        public void ActualPartTwo()
        {
            FabricDistribution fd = new FabricDistribution(@"C:\Users\joshu\source\repos\AdventOfCode2018\AdventOfCode2018\DayThree\Input.txt");
            int count = fd.GetValidClaim();

            Assert.Equal(625, count);
        }
    }
}
