using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DayTwelve
{
    public class SubterraneanSustainability
    {
        readonly long PadCount = 10000;
        private long GenerationCount;
        private int addedToStart = 0;
        public Dictionary<string, string> NoteInOut = new Dictionary<string, string>();
        public List<string> Generations = new List<string>();
        public List<string> WorkBench = new List<string>();
        public List<long> Sums = new List<long>();
        public string[] Lines { get; private set; }

        public SubterraneanSustainability() { }

        public SubterraneanSustainability(string[] lines, long generationCount = 20)
        {
            GenerationCount = generationCount;
            Lines = lines;
            SetupScenario();
        }

        public SubterraneanSustainability(string filePath, long generationCount = 20)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            GenerationCount = generationCount;
            SetupScenario();            
        }

        private void SetupScenario()
        {
            for (int i = 0; i < Lines.Count(); i++)
            {
                if (i == 0)
                {
                    Generations.Add(Lines[i].Substring(15));
                }
                else if (i > 1)
                {
                    var hint = Lines[i].Substring(0, 5);
                    var outcome = Lines[i][9];

                    NoteInOut.Add(hint, outcome.ToString());
                }
            }

            BuildWorkBench();
        }

        private void BuildWorkBench()
        {
            for (int i = 0; i < PadCount; i++)
            {
                //WorkBench[i] = ".";
                WorkBench.Add(".");
            }

            for (int i = 0; i < Generations[0].Length; i++)
            {
                WorkBench.Add(Generations[0][i].ToString());
            }

            for (long i = Generations[0].Length + PadCount; i < Generations[0].Length + PadCount * 2; i++)
            {
                //WorkBench[i] = ".";
                WorkBench.Add(".");
            }
        }

        public long PartOne()
        {
            long sum = 0;
            int gen = 0;

            while (gen < GenerationCount)
            {
                PerformGeneration();
                gen++;
            }

            sum = Sums[19];

            //foreach (var g in Generations)
            //{
            //    for (int i = 0; i < g.Length; i++)
            //    {
            //        if (g[i] == '#')
            //        {
            //            sum += i - PadCount;
            //        }
            //    }
            //}

            return sum;
        }

        public string PadLeft(string current)
        {
            while (current.Length < 5)
            {
                current = "." + current;
            }

            return current;
        }

        public string PadRight(string current)
        {
            while (current.Length < 5)
            {
                current += ".";
            }

            return current;
        }

        public long GetSum(List<string> gen)
        {
            long sum = 0;

            for (int i = 0; i < gen.Count(); i++)
            {
                if (gen[i] == "#")
                    sum += i - PadCount;
            }

            return sum;
        }


        private void PerformGeneration()
        {
            List<string> newGen = new List<string>();
            newGen.Add(".");
            newGen.Add(".");

            for (int i = 2; i < WorkBench.Count() - 2; i++)
            {
                var s = string.Concat(WorkBench[i - 2], WorkBench[i - 1], WorkBench[i], WorkBench[i + 1], WorkBench[i + 2]);

                if (NoteInOut.ContainsKey(s))
                {
                    newGen.Add(NoteInOut[s]);
                }
                else
                {
                    newGen.Add(".");
                }
            }

            newGen.Add(".");
            newGen.Add(".");

            Sums.Add(GetSum(newGen));
            Generations.Add(ListToString(newGen));
            WorkBench = newGen;
        }

        private string ListToString(List<string> l)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in l)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
    }
}
