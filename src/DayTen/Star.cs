using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayTen
{
    public class Star
    {
        public int Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int OriginalX { get; private set; }
        public int OriginalY { get; private set; }
        public int VelocityX { get; private set; }
        public int VelocityY { get; private set; }

        public Star() { }

        public Star(int i, string line)
        {
            Id = i;
            ParseLine(line);
        }

        public void Move()
        {
            X += VelocityX;
            Y += VelocityY;
        }

        public void MoveBack()
        {
            X -= VelocityX;
            Y -= VelocityY;
        }

        private void ParseLine(string line)
        {
            int i = line.IndexOf(",");
            int px = int.Parse(line.Substring(10, i - 10));
            int py = int.Parse(line.Substring(i + 1, line.IndexOf(">") - i - 1));
            i = line.LastIndexOf(",");
            int j = line.LastIndexOf("<");
            int k = line.LastIndexOf(">");
            int vx = int.Parse(line.Substring(j + 1, i - j - 1));
            int vy = int.Parse(line.Substring(i + 1, k - i - 1));

            X = px;
            Y = py;
            OriginalX = px;
            OriginalY = py;
            VelocityX = vx;
            VelocityY = vy;
        }
    }
}
