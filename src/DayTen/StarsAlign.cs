using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DayTen
{
    public class StarsAlign
    {
        public string[] Lines { get; private set; }
        public Dictionary<int, Star> Stars = new Dictionary<int, Star>();
        public List<int> DistanceSums = new List<int>{ int.MaxValue };

        public StarsAlign() { }

        public StarsAlign(string[] lines)
        {
            Lines = lines;
            SetupStars();
        }

        public StarsAlign(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            SetupStars();
        }

        public string PartOne()
        {
            ProcessSecond();
            int currentIndex = DistanceSums.Count - 1;

            while (DistanceSums[currentIndex] <= DistanceSums[currentIndex - 1])
            {
                ProcessSecond();
                currentIndex++;
            }

            RollBack();

            return GetStarString();
        }

        private string GetStarString()
        {
            int maxX = Stars.Values.Max(s => s.X);
            int minX = Stars.Values.Min(s => s.X);
            int maxY = Stars.Values.Max(s => s.Y);
            int minY = Stars.Values.Min(s => s.Y);
            StringBuilder sb = new StringBuilder();
            string[][] grid = new string[Zeroer(maxX, minX) + 10][];

            for (int i = 0; i < Zeroer(maxX, minX) + 10; i++)
            {
                grid[i] = new string[Zeroer(maxY, minY) + 10];
                
                for (int j = 0; j < Zeroer(maxY, minY) + 10; j++)
                {
                    grid[i][j] = ".";
                }
            }

            foreach(var star in Stars.Values)
            {
                int i = Zeroer(star.X, minX);
                int j = Zeroer(star.Y, minY);

                grid[i][j] = "#";
            }

            for (int i = 0; i < Zeroer(maxX, minX) + 10; i++)
            {
                for (int j = 0; j < Zeroer(maxY, minY) + 10; j++)
                {
                    sb.Append(grid[i][j]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public int PartTwo()
        {
            return DistanceSums.Count - 3;
        }

        public int Zeroer(int i, int definedZero)
        {
            return i + Math.Abs(definedZero);
        }

        private void ProcessSecond()
        {
            foreach(var s in Stars.Values)
            {
                s.Move();
            }

            DistanceSums.Add(GetDistanceSum());
        }

        private void RollBack()
        {
            foreach (var s in Stars.Values)
            {
                s.MoveBack();
            }

            DistanceSums.Add(GetDistanceSum());
        }

        private int GetDistanceSum()
        {
            int maxX = Stars.Values.Max(s => s.X);
            int minX = Stars.Values.Min(s => s.X);
            int maxY = Stars.Values.Max(s => s.Y);
            int minY = Stars.Values.Min(s => s.Y);

            return maxX - minX + maxY - minY;
        }

        private void SetupStars()
        {
            for (int i = 1; i <= Lines.Length - 1; i++)
            {
                Stars.Add(i, new Star(i, Lines[i - 1]));
            }
        }
    }
}
