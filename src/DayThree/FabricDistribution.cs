using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayThree
{
    public class FabricDistribution
    {
        public int[][] Box { get; set; }
        public string[] Lines { get; private set; }

        public FabricDistribution() { }

        public FabricDistribution(string filePath)
        {
            InitializeBox(1000, 1000);
            Lines = System.IO.File.ReadAllLines(filePath);
            EvaluateElfPlans();
        }

        public FabricDistribution(string[] lines)
        {
            InitializeBox(1000, 1000);
            Lines = lines;
            EvaluateElfPlans();
        }

        public int GetMultipleUseCount()
        {
            int count = 0;

            for (int i = 0; i < Box.Length; i++)
            {
                for (int j = 0; j < Box[i].Length; j++)
                {
                    if (Box[i][j] > 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int GetValidClaim()
        {
            foreach (var line in Lines)
            {
                FabricPlan fp = new FabricPlan(line);

                if (IsClaimValid(fp))
                {
                    return fp.Index;
                }
            }

            return 1;
        }

        private bool IsClaimValid(FabricPlan fp)
        {
            for (int i = fp.StartX; i < fp.StartX + fp.LengthX; i++)
            {
                for (int j = fp.StartY; j < fp.StartY + fp.LengthY; j++)
                {
                    if (Box[i][j] > 1) return false;
                }
            }

            return true;
        }

        private void InitializeBox(int sizeX, int sizeY)
        {
            Box = new int[sizeX][];

            for (int x = 0; x < sizeX; x++)
            {
                Box[x] = new int[sizeY];

                for (int y = 0; y < sizeY; y++)
                {
                    Box[x][y] = 0;
                }
            }
        }

        private void EvaluateElfPlans()
        {
            foreach (var line in Lines)
            {
                EvaluateLine(line);
            }
        }

        private void EvaluateLine(string line)
        {
            FabricPlan fp = new FabricPlan(line);

            for (int i = fp.StartX; i < fp.StartX + fp.LengthX; i++)
            {
                for (int j = fp.StartY; j < fp.StartY + fp.LengthY; j++)
                {
                    Box[i][j]++;
                }
            }
        }
    }
}
