using System;
using Xunit;
using AdventOfCode2018.DayOne;

namespace Tests
{
    public class DayOne
    {
        [Fact]
        public void SimpleInput()
        {
            var lines = new string[]
            {
                "2",
                "-2",
                "4"
            };

            var fpm = new FindPlusMinus(lines, 0);
            var frequency = fpm.GetModifiedFrequency();

            Assert.Equal(4, frequency);
        }

        [Fact]
        public void NoInput()
        {
            var lines = new string[]
            {

            };

            var fpm = new FindPlusMinus(lines, 0);
            var frequency = fpm.GetModifiedFrequency();

            Assert.Equal(0, frequency);
        }

        [Fact]
        public void TheActualInput()
        {
            var fpm = new FindPlusMinus(@"C:\Users\joshu\source\repos\AdventOfCode2018\AdventOfCode2018\DayOne\input.txt", 0);
            var frequency = fpm.GetModifiedFrequency();

            Assert.Equal(525, frequency);
        }

        [Fact]
        public void ExampleInputPartTwo()
        {
            var lines = new string[]
            {
                "+1",
                "+1",
                "-1"
            };

            var fpm = new FindPlusMinus(lines, 0);
            var frequency = fpm.GetModifiedFrequencyWithMultiple();

            Assert.Equal(1, frequency);
        }

        [Fact]
        public void RepeatFrequency()
        {
            var fpm = new FindPlusMinus(@"C:\Users\joshu\source\repos\AdventOfCode2018\AdventOfCode2018\DayOne\input.txt", 0);
            var frequency = fpm.GetModifiedFrequencyWithMultiple();

            Assert.Equal(75749, frequency);
        }
    }
}
