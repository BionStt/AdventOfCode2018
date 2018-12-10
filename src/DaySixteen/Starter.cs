using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DaySixteen
{
    public class Starter
    {
        public string[] Lines { get; private set; }

        public Starter() { }

        public Starter(string[] lines)
        {
            Lines = lines;
        }

        public Starter(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
        }
    }
}
