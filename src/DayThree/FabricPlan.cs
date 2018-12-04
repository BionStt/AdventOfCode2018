using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayThree
{
    public class FabricPlan
    {
        public int Index { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int LengthX { get; set; }
        public int LengthY { get; set; }

        public FabricPlan() { }

        public FabricPlan(string plan)
        {
            var tokens = plan.Split(' ');
            Index = int.Parse(tokens[0].Substring(1));
            StartX = int.Parse(tokens[2].Substring(0, tokens[2].IndexOf(',')));
            StartY = int.Parse(tokens[2].Replace(":","").Substring(tokens[2].IndexOf(',') + 1));
            LengthX = int.Parse(tokens[3].Substring(0, tokens[3].IndexOf('x')));
            LengthY = int.Parse(tokens[3].Substring(tokens[3].IndexOf('x') + 1));
        }
    }
}
