using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayFour
{
    public class GuardSleepingTimes
    {
        public string[] Lines { get; private set; }
        public List<Message> Messages { get; set; }

        public Dictionary<int, Guard> Guards = new Dictionary<int, Guard>();

        public GuardSleepingTimes() { }

        public GuardSleepingTimes(string[] lines)
        {
            Lines = lines;
            ProcessMessages();
        }

        public GuardSleepingTimes(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            ProcessMessages();
        }

        public int GetAnswer()
        {
            int maxSleep = 0;
            int guardWithMostSleep = 0;
            int mostSleptMinute = 0;

            foreach (var guard in Guards.Values)
            {
                if (guard.TimeSlept > maxSleep)
                {
                    maxSleep = guard.TimeSlept;
                    guardWithMostSleep = guard.Id;
                    mostSleptMinute = guard.GetMostSleptMinute();
                }
            }

            return guardWithMostSleep * mostSleptMinute;
        }

        // Part 2.
        public int GetMaxMinuteAndGuard()
        {
            int maxMinuteCount = 0;
            int maxMinute = 0;
            int maxGuard = 0;

            foreach (var guard in Guards.Values)
            {
                var mostTuple = guard.GetMostSleptMinuteTuple();

                if (maxMinuteCount < mostTuple.Count)
                {
                    maxGuard = guard.Id;
                    maxMinuteCount = mostTuple.Count;
                    maxMinute = mostTuple.Minute;
                }
            }

            return maxGuard * maxMinute;
        }

        private void ProcessMessages()
        {
            Messages = new List<Message>();
            foreach (var line in Lines)
            {
                Messages.Add(new Message(line));
            }

            // Sort the messages by time.
            Messages.Sort((m1, m2) => m1.Time.CompareTo(m2.Time));

            // Setup state for handling the messages.
            int guardId = 0;
            DateTime startSleep = DateTime.Now, endSleep = DateTime.Now;

            foreach (var message in Messages)
            {
                // Shift change.
                if (!message.IsFallAsleep && !message.IsWakeUp)
                {
                    guardId = message.GuardId;

                    if (!Guards.ContainsKey(guardId))
                    {
                        Guards.Add(guardId, new Guard(guardId));
                    }
                }
                // Start sleep.
                else if (message.IsFallAsleep)
                {
                    startSleep = message.Time;
                }
                // End Sleep
                else if (message.IsWakeUp)
                {
                    endSleep = message.Time;
                    Guards[guardId].AddMinutesSlept(startSleep, endSleep);
                }
            }
        }
    }
}
