using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayTwelve;

namespace Tests
{
    public class DayTwelve
    {
        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "initial state: #..#.#..##......###...###",
                "",
                "...## => #",
                "..#.. => #",
                ".#... => #",
                ".#.#. => #",
                ".#.## => #",
                ".##.. => #",
                ".#### => #",
                "#.#.# => #",
                "#.### => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #"
            };

            var ss = new SubterraneanSustainability(lines);
            var answer = ss.PartOne();

            Assert.Equal(325, answer);
        }

        [Fact]
        public void ExamplePartOneT2()
        {
            var lines = new string[]
            {
                "initial state: #..#.#..##......###...###",
                "",
                "...## => #",
                "..#.. => #",
                ".#... => #",
                ".#.#. => #",
                ".#.## => #",
                ".##.. => #",
                ".#### => #",
                "#.#.# => #",
                "#.### => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #"
            };

            var ss = new TryTwo(lines);
            var answer = ss.PartOne();

            Assert.Equal(325, answer);
        }

        [Fact]
        public void PartOneT2()
        {
            var lines = new string[]
            {
                "initial state: ###....#..#..#......####.#..##..#..###......##.##..#...#.##.###.##.###.....#.###..#.#.##.#..#.#",
                "",
                "..### => #",
                "...## => #",
                "#.#.# => #",
                "##.## => #",
                "#..#. => #",
                ".#### => #",
                ".#..# => #",
                "##... => #",
                ".#.#. => #",
                "###.# => #",
                "##### => #",
                "#.##. => #",
                ".#... => #",
                ".#.## => #",
                "###.. => #",
                "#.#.. => #",
            };

            var ss = new TryTwo(lines);
            var answer = ss.PartOne();

            Assert.Equal(2040, answer);
        }

        [Fact]
        public void PartTwoT2()
        {
            var lines = new string[]
            {
                "initial state: ###....#..#..#......####.#..##..#..###......##.##..#...#.##.###.##.###.....#.###..#.#.##.#..#.#",
                "",
                "..### => #",
                "...## => #",
                "#.#.# => #",
                "##.## => #",
                "#..#. => #",
                ".#### => #",
                ".#..# => #",
                "##... => #",
                ".#.#. => #",
                "###.# => #",
                "##### => #",
                "#.##. => #",
                ".#... => #",
                ".#.## => #",
                "###.. => #",
                "#.#.. => #",
            };

            var ss = new TryTwo(lines);
            var answer = ss.PartTwo();

            Assert.Equal(1700000000011, answer);
        }

        [Fact]
        public void PartOne()
        {
            var mm = new SubterraneanSustainability(@"C:\Users\joshu\github\AdventOfCode2018\src\DayTwelve\input.txt");
            var answer = mm.PartOne();

            Assert.Equal(2040, answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
            };

            var mm = new SubterraneanSustainability(lines);
            var answer = 1; //mm.PartTwo();

            Assert.Equal(66, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var ss = new SubterraneanSustainability(@"C:\Users\joshu\github\AdventOfCode2018\src\DayTwelve\input.txt", 50000);
            var answer = ss.PartOne();

            Assert.Equal(27433, answer);
        }
    }
}