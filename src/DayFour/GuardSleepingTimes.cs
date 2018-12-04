using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayFour
{
    public class GuardSleepingTimes
    {
        public string[] Lines { get; private set; }

        public GuardSleepingTimes() { }

        public GuardSleepingTimes(string[] lines)
        {
            Lines = lines;
        }

        public GuardSleepingTimes(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
        }
    }
}
