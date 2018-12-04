using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AdventOfCode2018.DayFour;

namespace Tests
{
    public class DayFour
    {
        [Fact]
        public void ExampleText()
        {
            var lines = new string[]
            {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up"
            };
            GuardSleepingTimes gst = new GuardSleepingTimes(lines);
            int answer = gst.GetAnswer();

            Assert.Equal(240, answer);
        }

        [Fact]
        public void ActualPartOne()
        {
            GuardSleepingTimes gst = new GuardSleepingTimes(@"C:\Users\joshu\github\AdventOfCode2018\src\DayFour\Input.txt");
            int answer = gst.GetAnswer();

            Assert.Equal(38813, answer);
        }

        [Fact]
        public void ExamplePartTwo()
        {
            var lines = new string[]
            {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up"
            };
            GuardSleepingTimes gst = new GuardSleepingTimes(lines);
            int answer = gst.GetMaxMinuteAndGuard();

            Assert.Equal(4455, answer);
        }

        [Fact]
        public void ActualPartTwo()
        {
            GuardSleepingTimes gst = new GuardSleepingTimes(@"C:\Users\joshu\github\AdventOfCode2018\src\DayFour\Input.txt");
            int answer = gst.GetMaxMinuteAndGuard();

            Assert.Equal(141071, answer);
        }
    }
}
