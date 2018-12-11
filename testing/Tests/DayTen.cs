using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using AdventOfCode2018.DayTen;

namespace Tests
{
    public class DayTen
    {
        ITestOutputHelper output;

        public DayTen(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ExamplePartOne()
        {
            var lines = new string[]
            {
                "position=< 9,  1> velocity=< 0,  2>",
                "position=< 7,  0> velocity=<-1,  0>",
                "position=< 3, -2> velocity=<-1,  1>",
                "position=< 6, 10> velocity=<-2, -1>",
                "position=< 2, -4> velocity=< 2,  2>",
                "position=<-6, 10> velocity=< 2, -2>",
                "position=< 1,  8> velocity=< 1, -1>",
                "position=< 1,  7> velocity=< 1,  0>",
                "position=<-3, 11> velocity=< 1, -2>",
                "position=< 7,  6> velocity=<-1, -1>",
                "position=<-2,  3> velocity=< 1,  0>",
                "position=<-4,  3> velocity=< 2,  0>",
                "position=<10, -3> velocity=<-1,  1>",
                "position=< 5, 11> velocity=< 1, -2>",
                "position=< 4,  7> velocity=< 0, -1>",
                "position=< 8, -2> velocity=< 0,  1>",
                "position=<15,  0> velocity=<-2,  0>",
                "position=< 1,  6> velocity=< 1,  0>",
                "position=< 8,  9> velocity=< 0, -1>",
                "position=< 3,  3> velocity=<-1,  1>",
                "position=< 0,  5> velocity=< 0, -1>",
                "position=<-2,  2> velocity=< 2,  0>",
                "position=< 5, -2> velocity=< 1,  2>",
                "position=< 1,  4> velocity=< 2,  1>",
                "position=<-2,  7> velocity=< 2, -2>",
                "position=< 3,  6> velocity=<-1, -1>",
                "position=< 5,  0> velocity=< 1,  0>",
                "position=<-6,  0> velocity=< 2,  0>",
                "position=< 5,  9> velocity=< 1, -2>",
                "position=<14,  7> velocity=<-2,  0>",
                "position=<-3,  6> velocity=< 2, -1>"
            };

            var ss = new StarsAlign(lines);
            var answer = ss.PartOne();

            Assert.Equal("", "");
            output.WriteLine(answer);
        }

        [Fact]
        public void PartOne()
        {
            var ss = new StarsAlign(@"C:\Users\joshu\github\AdventOfCode2018\src\DayTen\input.txt");
            var answer = ss.PartOne();

            Assert.Equal("", "");
            
            output.WriteLine(answer);
        }

        [Fact]
        public void ParseLine()
        {
            var line = @"position=<-3,  6> velocity=< 2, -1>";
            int i = line.IndexOf(",");
            int px = int.Parse(line.Substring(10, i - 10));
            int py = int.Parse(line.Substring(i + 1, line.IndexOf(">") - i - 1));
            i = line.LastIndexOf(",");
            int j = line.LastIndexOf("<");
            int k = line.LastIndexOf(">");
            int vx = int.Parse(line.Substring(j + 1, i - j - 1));
            int vy = int.Parse(line.Substring(i + 1, k - i - 1));

            Assert.Equal(-3, px);
            Assert.Equal(6, py);
            Assert.Equal(2, vx);
            Assert.Equal(-1, vy);
        }

        [Fact]
        public void ParseLine2()
        {
            var line = "position=< 11032,  -54286> velocity=<-1, -1>";
            int i = line.IndexOf(",");
            int px = int.Parse(line.Substring(10, i - 10));
            int py = int.Parse(line.Substring(i + 1, line.IndexOf(">") - i - 1));
            i = line.LastIndexOf(",");
            int j = line.LastIndexOf("<");
            int k = line.LastIndexOf(">");
            int vx = int.Parse(line.Substring(j + 1, i - j - 1));
            int vy = int.Parse(line.Substring(i + 1, k - i - 1));

            Assert.Equal(11032, px);
            Assert.Equal(-54286, py);
            Assert.Equal(-1, vx);
            Assert.Equal(-1, vy);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "position=< 9,  1> velocity=< 0,  2>",
                "position=< 7,  0> velocity=<-1,  0>",
                "position=< 3, -2> velocity=<-1,  1>",
                "position=< 6, 10> velocity=<-2, -1>",
                "position=< 2, -4> velocity=< 2,  2>",
                "position=<-6, 10> velocity=< 2, -2>",
                "position=< 1,  8> velocity=< 1, -1>",
                "position=< 1,  7> velocity=< 1,  0>",
                "position=<-3, 11> velocity=< 1, -2>",
                "position=< 7,  6> velocity=<-1, -1>",
                "position=<-2,  3> velocity=< 1,  0>",
                "position=<-4,  3> velocity=< 2,  0>",
                "position=<10, -3> velocity=<-1,  1>",
                "position=< 5, 11> velocity=< 1, -2>",
                "position=< 4,  7> velocity=< 0, -1>",
                "position=< 8, -2> velocity=< 0,  1>",
                "position=<15,  0> velocity=<-2,  0>",
                "position=< 1,  6> velocity=< 1,  0>",
                "position=< 8,  9> velocity=< 0, -1>",
                "position=< 3,  3> velocity=<-1,  1>",
                "position=< 0,  5> velocity=< 0, -1>",
                "position=<-2,  2> velocity=< 2,  0>",
                "position=< 5, -2> velocity=< 1,  2>",
                "position=< 1,  4> velocity=< 2,  1>",
                "position=<-2,  7> velocity=< 2, -2>",
                "position=< 3,  6> velocity=<-1, -1>",
                "position=< 5,  0> velocity=< 1,  0>",
                "position=<-6,  0> velocity=< 2,  0>",
                "position=< 5,  9> velocity=< 1, -2>",
                "position=<14,  7> velocity=<-2,  0>",
                "position=<-3,  6> velocity=< 2, -1>"
            };

            var sa = new StarsAlign(lines);
            sa.PartOne();
            var answer = sa.PartTwo();

            Assert.Equal(3, answer);
        }

        [Fact]
        public void PartTwo()
        {
            var sa = new StarsAlign(@"C:\Users\joshu\github\AdventOfCode2018\src\DayTen\input.txt");
            sa.PartOne();
            var answer = sa.PartTwo();

            Assert.Equal(10831, answer);
        }
    }
}