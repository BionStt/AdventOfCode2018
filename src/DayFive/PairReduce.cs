using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.DayFive
{
    public class PairReduce
    {
        public string[] Lines { get; set; }
        public string Polymer { get; set; }

        public PairReduce() { }

        public PairReduce(string[] lines)
        {
            Lines = lines;
            Polymer = Lines[0];
        }

        public PairReduce(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            Polymer = Lines[0];
        }

        public string Reduce()
        {
            bool canReduce = true;

            while (canReduce)
            {
                bool anyChanges = false;

                for (int i = 0; i < Polymer.Length - 1; i++)
                {
                    if (string.Compare(Polymer[i].ToString(), Polymer[i + 1].ToString(), false) != 0
                        && string.Compare(Polymer[i].ToString(), Polymer[i + 1].ToString(), true) == 0)
                    {
                        anyChanges = true;
                        Polymer = Polymer.Replace((Polymer[i].ToString() + Polymer[i + 1].ToString()), "");
                        break;
                    }
                }

                if (!anyChanges || Polymer.Length < 1)
                {
                    canReduce = false;
                }
            }

            return Polymer;
        }

        public int PartTwo()
        {
            var characters = Polymer.ToLower()
                .ToCharArray().Distinct();
            int min = int.MaxValue;

            foreach (var c in characters)
            {
                string trimmed = StripPolymer(c.ToString());
                string reduced = Reduce(trimmed);

                if (reduced.Length < min)
                {
                    min = reduced.Length;
                }
            }

            return min;
        }

        public string StripPolymer(string letter)
        {
            return Polymer.Replace(letter, "", true, System.Globalization.CultureInfo.CurrentCulture);
        }

        public string Reduce(string polymer)
        {
            bool canReduce = true;

            while (canReduce)
            {
                bool anyChanges = false;

                for (int i = 0; i < polymer.Length - 1; i++)
                {
                    if (string.Compare(polymer[i].ToString(), polymer[i + 1].ToString(), false) != 0
                        && string.Compare(polymer[i].ToString(), polymer[i + 1].ToString(), true) == 0)
                    {
                        anyChanges = true;
                        polymer = polymer.Replace((polymer[i].ToString() + polymer[i + 1].ToString()), "");
                        break;
                    }
                }

                if (!anyChanges || polymer.Length < 1)
                {
                    canReduce = false;
                }
            }

            return polymer;
        }
    }
}
