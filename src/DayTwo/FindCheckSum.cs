using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayTwo
{
    public class FindCheckSum
    {
        public int PairCount { get; set; }
        public int TripletCount { get; set; }
        public string[] Lines { get; private set; }
        public string FilePath { get; set; }

        public FindCheckSum() { }
        
        public FindCheckSum(string[] lines)
        {
            Lines = lines;
            PairCount = 0;
            TripletCount = 0;
            CalculateCheckSumCounts();
        }

        public FindCheckSum(string filePath)
        {
            FilePath = filePath;
            PairCount = 0;
            TripletCount = 0;
            Lines = System.IO.File.ReadAllLines(FilePath);
            CalculateCheckSumCounts();
        }

        public int GetCheckSum()
        {
            return PairCount * TripletCount;
        }

        public string MatchesFromNearMatch()
        {
            foreach (var line in Lines)
            {
                foreach (var line2 in Lines)
                {
                    int differenceCount = GetStringDistance(line, line2);

                    if (differenceCount == 1)
                    {
                        return GetCommonString(line, line2);
                    }
                }
            }

            return "";
        }

        public int GetStringDistance(string s1, string s2)
        {
            // Assumes the strings are equal length.
            int differenceCount = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i]) differenceCount++;
            }

            return differenceCount;
        }

        public string GetCommonString(string s1, string s2)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    sb.Append(s1[i]);
                }
            }

            return sb.ToString();
        }

        private void CalculateCheckSumCounts()
        {
            foreach (var line in Lines)
            {
                Dictionary<char, int> charCounts = new Dictionary<char, int>();

                foreach (var c in line)
                {
                    if (charCounts.ContainsKey(c))
                    {
                        charCounts[c]++;
                    }
                    else
                    {
                        charCounts.Add(c, 1);
                    }
                }

                bool hasPair = charCounts.ContainsValue(2);
                bool hasTriplet = charCounts.ContainsValue(3);

                PairCount = hasPair ? PairCount + 1 : PairCount;
                TripletCount = hasTriplet ? TripletCount + 1 : TripletCount;
            }
        }
    }
}
