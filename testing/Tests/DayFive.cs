using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayFive;

namespace Tests
{
    public class DayFive
    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "dabAcCaCBAcCcaDA"
            };

            var pr = new PairReduce(lines);
            string answer = pr.Reduce();

            Assert.Equal(10, answer.Length);
        }

        [Fact]
        public void PartOne()
        {
            var pr = new PairReduce(@"C:\Users\joshu\github\AdventOfCode2018\src\DayFive\input.txt");
            string answer = pr.Reduce();

            Assert.Equal(10368, answer.Length);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "dabAcCaCBAcCcaDA"
            };

            var pr = new PairReduce(lines);
            int answer = pr.PartTwo();

            Assert.Equal(4, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var pr = new PairReduce(@"C:\Users\joshu\github\AdventOfCode2018\src\DayFive\input.txt");
            int answer = pr.PartTwo();

            Assert.Equal(4122, answer);
        }
    }
}
