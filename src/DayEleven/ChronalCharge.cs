using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DayEleven
{
    public class ChronalCharge
    {
        public string[] Lines { get; private set; }
        public int SerialNumber { get; private set; }
        public int[][] PowerLevels = new int[300][];
        public Dictionary<(int, int), int> ThreeByThreePower = new Dictionary<(int, int), int>();
        public Dictionary<(int, int, int), int> MaxPowerForCell = new Dictionary<(int, int, int), int>();

        public ChronalCharge() { }

        public ChronalCharge(int serialNumber)
        {
            SerialNumber = serialNumber;
            SetupPowerLevels();
        }

        public ChronalCharge(string[] lines)
        {
            Lines = lines;
        }

        public ChronalCharge(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
        }

        public int GetPowerLevel(int x, int y)
        {
            int rackId = x + 10;
            int powerLevel = rackId * y;
            powerLevel += SerialNumber;
            powerLevel *= rackId;
            int hundreds = powerLevel / 100 % 10;
            return hundreds - 5;
        }

        private void SetupPowerLevels()
        {
            for (int i = 0; i < 300; i++)
            {
                PowerLevels[i] = new int[300];

                for (int j = 0; j < 300; j++)
                {
                    PowerLevels[i][j] = GetPowerLevel(i + 1, j + 1);
                }
            }

            for (int i = 0; i < 297; i++)
            {
                for (int j = 0; j < 297; j++)
                {
                    ThreeByThreePower.Add((i + 1, j + 1), GetThreeByThreePowerLevel(i, j));
                }
            }
        }

        public (int, int, int) PartTwo()
        {
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    GetSquarePower(i, j);
                }
            }

            var value = MaxPowerForCell.Values.Max(p => p);
            return MaxPowerForCell.First(p => p.Value == value).Key;
        }

        public string PrintPowers()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    sb.Append($"{PowerLevels[i][j]} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public (int, int) PartOne()
        {
            var value = ThreeByThreePower.Values.Max(p => p);
            return ThreeByThreePower.First(p => p.Value == value).Key;
        }

        // Cache takes it from ~4 minutes to 4 seconds. Memoization is your friend.
        private int GetSquarePower(int x, int y)
        {
            int maxPower = int.MinValue;
            (int, int, int) locSizeTup = (x + 1, y + 1, 0);
            Dictionary<int, int> diameterCache = new Dictionary<int, int>();

            for (int diameter = 1; diameter < 300 - x && diameter < 300 - y; diameter++)
            {
                int curSum = diameterCache.ContainsKey(diameter - 1) ? diameterCache[diameter - 1] : 0;

                for (int i = x; i < x + diameter; i++)
                {
                    curSum += PowerLevels[i][y + diameter - 1];
                }

                for (int j = y; j < y + diameter - 1; j++)
                {
                    curSum += PowerLevels[x + diameter - 1][j];
                }

                diameterCache.Add(diameter, curSum);

                if (curSum > maxPower)
                {
                    maxPower = curSum;
                    locSizeTup = (x + 1, y + 1, diameter);
                }
            }

            MaxPowerForCell.Add(locSizeTup, maxPower);
            return maxPower;
        }

        private int GetThreeByThreePowerLevel(int x, int y)
        {
            int powerLevel = 0;

            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    powerLevel += PowerLevels[i][j];
                }
            }

            return powerLevel;
        }
    }
}
