using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.DayEight
{
    public class Node
    {
        public int ChildCount { get; private set; }
        public int MetaCount { get; private set; }
        public List<Node> Children { get; private set; }
        public int MetaTotal { get; private set; }
        public List<int> Values { get; set; }
        public int EndIndex { get; set; }
        public List<int> MetaEntries = new List<int>();

        public Node(List<int> values, int startIndex = 0)
        {
            Values = values;
            ChildCount = values[startIndex];
            MetaCount = values[startIndex + 1];
            Children = new List<Node>();
            int currentChildStartIndex = startIndex + 2;

            if (ChildCount > 0)
            {
                // Process Children
                int processed = 0;

                while (processed < ChildCount)
                {
                    currentChildStartIndex = ProcessChild(currentChildStartIndex);
                    processed++;
                }
            }

            int metasProcessed = 0;
            for (int i = currentChildStartIndex; metasProcessed < MetaCount; i++, metasProcessed++)
            {
                MetaEntries.Add(values[i]);
                MetaTotal += values[i];
                EndIndex = i;
            }
        }

        public int GetNodeTotal()
        {
            int total = 0;

            foreach (var node in Children)
            {
                total += node.GetNodeTotal();
            }

            return total + MetaTotal;
        }

        public int GetRootNodeValue()
        {
            int sum = 0;

            foreach (var i in MetaEntries)
            {
                if (Children.Count > i - 1)
                {
                    if (Children[i - 1].ChildCount == 0)
                    {
                        sum += Children[i - 1].MetaTotal;
                    }
                    else
                    {
                        sum += Children[i - 1].GetRootNodeValue();
                    }
                }
            }

            return sum;
        }

        private int ProcessChild(int currentChildStartIndex)
        {
            Node n = new Node(Values, currentChildStartIndex);
            Children.Add(n);
            return n.EndIndex + 1;
        }

        public Node(int childCount, int metaCount)
        {
            ChildCount = childCount;
            MetaCount = MetaCount;
        }
    }
}
