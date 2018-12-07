using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DaySix;

namespace Tests
{
    public class DaySix
    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
            };

            var cc = new ChronalCoordinates(lines);
            int answer = cc.GetMaxArea();
            var s = cc.GetMap();

            Assert.Equal(17, answer);
        }

        [Fact]
        public void PartOne()
        {
            var cc = new ChronalCoordinates(@"C:\Users\joshu\github\AdventOfCode2018\src\DaySix\input.txt");
            int answer = cc.GetMaxArea();
            var s = cc.GetMap();

            Assert.Equal(3687, answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
            };

            var cc = new ChronalCoordinates(lines, 32);
            cc.GetMaxArea();
            int answer = cc.PartTwo();

            Assert.Equal(16, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var cc = new ChronalCoordinates(@"C:\Users\joshu\github\AdventOfCode2018\src\DaySix\input.txt");
            cc.GetMaxArea();
            int answer = cc.PartTwo();

            Assert.Equal(40134, answer);
        }
    }
}