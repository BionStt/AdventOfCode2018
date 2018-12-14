using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayTwelve
{
    public class TryTwo
    {
        public int PointsAddedToStart = 0;
        public Dictionary<string, string> Recipes = new Dictionary<string, string>();
        public List<string> Generations = new List<string>();
        public List<int> Sums = new List<int>();
        public string CurrentString = "";
        public string[] Lines { get; private set; }

        public TryTwo() { }

        public TryTwo(string[] lines)
        {
            Lines = lines;
            SetupScenario();
        }

        private void SetupScenario()
        {
            for (int i = 0; i < Lines.Count(); i++)
            {
                if (i == 0)
                {
                    CurrentString = Lines[i].Substring(15);
                    Generations.Add(CurrentString);
                }
                else if (i > 1)
                {
                    var hint = Lines[i].Substring(0, 5);
                    var outcome = Lines[i][9];

                    Recipes.Add(hint, outcome.ToString());
                }
            }

            Sums.Add(GetScore(CurrentString));
        }

        public int PartOne()
        {
            for (int i = 0; i < 20; i++)
            {
                CurrentString = ProcessCurrentString();
            }

            return GetScore(CurrentString);
        }

        public long PartTwo()
        {
            for (int i = 0; i < 2000; i++)
            {
                CurrentString = ProcessCurrentString();
            }

            return Sums[Sums.Count - 1] + (50000000000 - 2000) * (Sums[2000] - Sums[1999]);
        }

        private string ProcessCurrentString()
        {
            StringBuilder sb = new StringBuilder();
            string stringToProcess = string.Concat("....", CurrentString, "....");
            bool frontAdded = false;

            for (int i = 2; i < stringToProcess.Length - 2; i++)
            {
                string thisSpot = string.Concat(stringToProcess.Substring(i - 2, 5));

                if (Recipes.ContainsKey(thisSpot))
                {
                    sb.Append("#");

                    if (i == 2) 
                    {
                        PointsAddedToStart += 2;
                        frontAdded = true;
                    } 
                    if (i == 3 && !frontAdded) PointsAddedToStart++;
                }
                else if (i > 3 || frontAdded && i == 3)
                {
                    sb.Append(".");
                }
            }

            string currentGen = sb.ToString();
            Sums.Add(GetScore(currentGen));
            Generations.Add(currentGen);

            return currentGen;
        }

        public int GetScore(string s)
        {
            int sum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    sum += i - PointsAddedToStart;
                }
            }

            return sum;
        }
    }
}
