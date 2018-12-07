using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DaySix
{
    public class Coordinate
    {
        public int Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsInfinite { get; set; }
        public int ClosestCount { get; set; }

        public Coordinate() { }

        public Coordinate(int id, string line)
        {
            Id = id;
            IsInfinite = false;
            ProcessLine(line);
        }

        public void ProcessLine(string line)
        {
            string[] values = line.Split(',');
            X = int.Parse(values[0]);
            Y = int.Parse(values[1]);
        }

        public int Distance(int x, int y)
        {
            int distanceX = Math.Abs(X - x);
            int distanceY = Math.Abs(Y - y);

            return distanceX + distanceY;
        }

        public void AddClosest()
        {
            ClosestCount++;
        }

        public override string ToString()
        {
            return $"{X}, {Y} {IsInfinite} {ClosestCount}";
        }
    }
}
