using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayFour
{
    public class Message
    {
        public DateTime Time { get; private set; }
        public int GuardId { get; set; }
        public bool IsWakeUp { get; private set; }
        public bool IsFallAsleep { get; private set; }


        public Message() { }

        public Message(string line)
        {
            if (line.Contains("Guard"))
            {
                ProcessGuard(line);
            }
            else
            {
                ProcessSleepState(line);
            }
        }

        public override string ToString()
        {
            if (IsWakeUp)
            {
                return $"[{Time.ToString()}] wakes up";
            }
            else if (IsFallAsleep)
            {
                return $"[{Time.ToString()}] falls asleep";
            }

            return $"[{Time.ToString()}] Guard #{GuardId} begins shift";
        }

        private void ProcessGuard(string line)
        {
            IsWakeUp = false;
            IsFallAsleep = false;
            string[] tokens = line.Split(' ');

            Time = DateTime.Parse(tokens[0].Substring(1, tokens[0].Length - 1) + " " + tokens[1].Substring(0, 5));
            GuardId = int.Parse(tokens[3].Substring(1));
        }

        private void ProcessSleepState(string line)
        {
            GuardId = 0;
            if (line.Contains("wake"))
            {
                IsWakeUp = true;
                IsFallAsleep = false;
            }
            else if (line.Contains("fall"))
            {
                IsFallAsleep = true;
                IsWakeUp = false;
            }

            string[] tokens = line.Split(' ');
            Time = DateTime.Parse(tokens[0].Substring(1, tokens[0].Length - 1) + " " + tokens[1].Substring(0, 5));
        }
    }
}
