using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayFour
{
    public class Guard
    {
        public int Id { get; private set; }
        public int TimeSlept { get; set; }
        public int[] MinutesSleptAtMinute { get; set; }

        public Guard()
        {
            TimeSlept = 0;
            SetupMinutesArray();
        }

        public Guard(int id) : this()
        {
            Id = id;
        }

        public void AddMinutesSlept(DateTime from, DateTime to)
        {
            TimeSlept += (to.Minute) - from.Minute;

            for (int i = from.Minute; i < to.Minute; i++)
            {
                MinutesSleptAtMinute[i]++;
            }
        }

        public int GetMostSleptMinute()
        {
            int mostSleptMinute = 0;

            for (int i = 0; i < MinutesSleptAtMinute.Length; i++)
            {
                if (MinutesSleptAtMinute[i] > MinutesSleptAtMinute[mostSleptMinute])
                {
                    mostSleptMinute = i;
                }
            }

            return mostSleptMinute;
        }

        public (int Minute, int Count) GetMostSleptMinuteTuple()
        {
            int mostSleptMinute = 0;

            for (int i = 0; i < MinutesSleptAtMinute.Length; i++)
            {
                if (MinutesSleptAtMinute[i] > MinutesSleptAtMinute[mostSleptMinute])
                {
                    mostSleptMinute = i;
                }
            }

            return (mostSleptMinute, MinutesSleptAtMinute[mostSleptMinute]);
        }

        private void SetupMinutesArray()
        {
            MinutesSleptAtMinute = new int[60];

            for (int i = 0; i < 60; i++)
            {
                MinutesSleptAtMinute[i] = 0;
            }
        }
    }
}
