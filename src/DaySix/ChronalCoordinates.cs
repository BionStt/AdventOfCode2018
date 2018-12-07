using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DaySix
{
    public class ChronalCoordinates
    {
        private readonly int BUFFER_SIZE = 2;
        public int MaxSafetySize { get; private set; }

        public string[] Lines { get; private set; }
        public Dictionary<int, Coordinate> Coordinates { get; }
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        int[][] closestCoordinates;
        int countForPartTwo = 0;

        public ChronalCoordinates() { }

        public ChronalCoordinates(string[] lines, int safetySize = 10000)
        {
            Lines = lines;
            MaxSafetySize = safetySize;
            Coordinates = new Dictionary<int, Coordinate>();
            SetupCoordinates();
        }

        public ChronalCoordinates(string filePath, int safetySize = 10000)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            MaxSafetySize = safetySize;
            Coordinates = new Dictionary<int, Coordinate>();
            SetupCoordinates();
        }

        private void SetupCoordinates()
        {
            for (int i = 1; i <= Lines.Length; i++)
            {
                var coordinate = new Coordinate(i, Lines[i - 1]);
                Coordinates.Add(i, coordinate);

                MaxX = coordinate.X > MaxX ? coordinate.X : MaxX;
                MaxY = coordinate.Y > MaxY ? coordinate.Y : MaxY;
            }

            // EvaluateInfiniteCoordinates();
            SetNearestCoordinatesForMap();
        }

        private void EvaluateInfiniteCoordinates()
        {
            List<Coordinate> infiniteCoordinates = new List<Coordinate>();
            infiniteCoordinates.AddRange(Coordinates.Values.Where(c => c.X == Coordinates.Values.Min(co => co.X)));
            infiniteCoordinates.AddRange(Coordinates.Values.Where(c => c.X == MaxX));
            infiniteCoordinates.AddRange(Coordinates.Values.Where(c => c.Y == Coordinates.Values.Min(co => co.Y)));
            infiniteCoordinates.AddRange(Coordinates.Values.Where(c => c.Y == MaxY));

            foreach (var coordinate in infiniteCoordinates)
            {
                Coordinates[coordinate.Id].IsInfinite = true;
            }
        }

        private void SetNearestCoordinatesForMap()
        {
            closestCoordinates = new int[MaxX + BUFFER_SIZE][];

            for (int x = 0; x < MaxX + BUFFER_SIZE; x++)
            {
                closestCoordinates[x] = new int[MaxY + BUFFER_SIZE];

                for (int y = 0; y < MaxY + BUFFER_SIZE; y++)
                {
                    closestCoordinates[x][y] = GetNearestCoordinatesForSpot(x, y);
                    if (closestCoordinates[x][y] != 0 && (x == 0 || x == MaxX + BUFFER_SIZE - 1 ||
                    y == 0 || y == MaxY + BUFFER_SIZE - 1))
                    {
                        Coordinates[closestCoordinates[x][y]].IsInfinite = true;
                    }
                }

                
            }
        }

        public int PartTwo()
        {
            return countForPartTwo;
        }

        private int GetNearestCoordinatesForSpot(int x, int y)
        {
            int totalDistance = 0;
            int minDistance = 1000;
            int minCount = 0;
            int coordId = 0;

            foreach (var coordinate in Coordinates.Values)
            {
                var currentDistance = coordinate.Distance(x, y);
                totalDistance += currentDistance;

                if (currentDistance < minDistance)
                {
                    coordId = coordinate.Id;
                    minDistance = currentDistance;
                    minCount = 1;
                }
                else if (currentDistance == minDistance)
                {
                    minCount++;
                }
            }

            if (totalDistance < MaxSafetySize)
            {
                countForPartTwo++;
            }

            if (minCount > 1)
            {
                return 0;
            }
            else
            {
                Coordinates[coordId].AddClosest();
                return coordId;
            }
        }

        // Answer to Part One.
        public int GetMaxArea()
        {
            return Coordinates.Values.Where(c => !c.IsInfinite).Max(c => c.ClosestCount);
        }

        public string GetMap()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < MaxX + BUFFER_SIZE; i++)
            {
                sb.Append("| ");

                for (int y = 0; y < MaxY + BUFFER_SIZE; y++)
                {
                    sb.Append(closestCoordinates[i][y]).Append(" ");
                }

                sb.Append("|").AppendLine();
            }

            return sb.ToString();
        }
    }
}
