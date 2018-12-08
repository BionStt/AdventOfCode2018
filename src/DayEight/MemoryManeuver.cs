using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayEight
{
    public class MemoryManeuver
    {
        public string[] Lines { get; private set; }
        public BuildTree Tree { get; private set; }

        public MemoryManeuver() { }

        public MemoryManeuver(string[] lines)
        {
            Lines = lines;
            Tree = new BuildTree(Lines[0]);
        }

        public MemoryManeuver(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            Tree = new BuildTree(Lines[0]);
        }

        public int PartOne()
        {
            return Tree.GetTotal();
        }

        public int PartTwo()
        {
            return Tree.GetRootNodeValue();
        }
    }
}
