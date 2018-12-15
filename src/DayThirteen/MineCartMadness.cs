using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DayThirteen
{
    public class MineCartMadness
    {
        public string[] Lines { get; private set; }
        public List<Cart> Carts = new List<Cart>();
        public char[][] Grid;

        public MineCartMadness() { }

        public MineCartMadness(string[] lines)
        {
            Lines = lines;
            ProcessLines();
        }

        public MineCartMadness(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            ProcessLines();
        }

        public (int, int) PartOne()
        {
            bool hasCrash = false;

            while (!hasCrash)
            {
                hasCrash = Carts.Any(c => !c.IsActive);
            }

            var crashedCart = Carts.FirstOrDefault(c => !c.IsActive);

            return (crashedCart.X, crashedCart.Y);
        }

        private void ProcessLines()
        {
            Grid = new char[Lines.Length][];
            for (int i = 0; i < Lines.Length; i++)
            {
                Grid[i] = new char[Lines[0].Length];

                for (int j = 0; j < Lines[i].Length; j++)
                {
                    if (Lines[i][j] == '<')
                    {
                        Carts.Add(new Cart(i, j, -1, 0));
                    }
                    else if (Lines[i][j] == '>')
                    {
                        Carts.Add(new Cart(i, j, 1, 0));
                    }
                    else if (Lines[i][j] == '^')
                    {
                        Carts.Add(new Cart(i, j, 0, -1));
                    }
                    else if (Lines[i][j] == 'v')
                    {
                        Carts.Add(new Cart(i, j, 0, 1));
                    }

                    Grid[i][j] = Lines[i][j];
                }
            }
        }
    }
}
