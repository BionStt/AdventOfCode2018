using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DaySeven;

namespace Tests
{
    public class DaySeven
    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

            var to = new TaskOrdering(lines);
            var answer = to.GetStringOrder();

            Assert.Equal("CABDFE", answer);
        }

        [Fact]
        public void PartOne()
        {
            var to = new TaskOrdering(@"C:\Users\joshu\github\AdventOfCode2018\src\DaySeven\input.txt");
            var answer = to.GetStringOrder();

            Assert.Equal("ADEFKLBVJQWUXCNGORTMYSIHPZ", answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

            var to = new TaskOrdering(lines);
            var answer = to.PartTwo("CABFDE", 2, 0);

            Assert.Equal(15, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var to = new TaskOrdering(@"C:\Users\joshu\github\AdventOfCode2018\src\DaySeven\input.txt");
            var answer = to.PartTwo("ADEFKLBVJQWUXCNGORTMYSIHPZ", 5, 60);

            Assert.Equal(1120, answer);
        }
    }
}