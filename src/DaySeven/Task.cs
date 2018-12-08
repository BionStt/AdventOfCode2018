using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DaySeven
{
    public class Task
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int TimeRemaining { get; set; }
        public int? WorkerIndex { get; set; }

        public Task() { }

        public Task(string name, int timeRemaining)
        {
            IsComplete = false;
            Name = name;
            TimeRemaining = timeRemaining;
        }

        public void DropTime()
        {
            TimeRemaining--;

            if (TimeRemaining == 0)
            {
                IsComplete = true;
            }
        }
    }
}
