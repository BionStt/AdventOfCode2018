using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayEight
{
    public class BuildTree
    {
        string input;
        List<int> values = new List<int>();
        public List<Node> Nodes { get; set; }
        public Node node { get; set; }

        public BuildTree(string line)
        {
            input = line;
            ProcessInput();
        }

        public int GetTotal()
        {
            return node.GetNodeTotal();
        }

        public int GetRootNodeValue()
        {
            return node.GetRootNodeValue();
        }

        private void ProcessInput()
        {
            GetValues();
            node = new Node(values);
        }

        private void GetValues()
        {
            string[] tokens = input.Split();

            foreach (var t in tokens)
            {
                values.Add(int.Parse(t));
            }
        }
    }
}
