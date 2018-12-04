using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayOne
{
    public class FindPlusMinus
    {
        public string FilePath { get; set; }
        public int Frequency { get; set; }
        private HashSet<int> Frequencies = new HashSet<int>();
        public string[] Lines { get; private set; }

        public FindPlusMinus() { }

        public FindPlusMinus(string filePath, int startingFrequency = 0)
        {
            FilePath = filePath;
            Frequency = startingFrequency;
            Lines = System.IO.File.ReadAllLines(FilePath);
        }

        public FindPlusMinus(string[] lines, int startingFrequency = 0)
        {
            Lines = lines;
            Frequency = startingFrequency;
        }

        public int GetModifiedFrequency()
        {
            foreach (var line in Lines)
            {
                int a = int.Parse(line);
                Frequency += a;
            }

            return Frequency;
        }

        public int GetModifiedFrequencyWithMultiple()
        {
            int i = 0;

            while (Lines.Length > i && !Frequencies.Contains(Frequency))
            {
                Frequencies.Add(Frequency);
                int a = int.Parse(Lines[i]);
                Frequency += a;
                i++;

                if (Lines.Length == i)
                {
                    i = 0;
                }
            }

            return Frequency;
        }
    }
}
