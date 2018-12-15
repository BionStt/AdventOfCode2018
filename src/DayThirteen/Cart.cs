using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayThirteen
{
    public class Cart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
        public bool IsActive { get; set; }

        public Cart() { }

        public Cart(int x, int y, int dx, int dy)
        {
            X = x;
            Y = y;
            DirectionX = dx;
            DirectionY = dy;
        }
    }
}
