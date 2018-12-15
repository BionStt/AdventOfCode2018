using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DayFourteen
{
    public class ChocolateCharts
    {
        public List<int> Scores { get; set; }

        public ChocolateCharts(int score)
        {
            Scores = new List<int>() { 3, 7 };
        }

        public string PartOne(int n)
        {
            int e1 = 0, e2 = 1;
            string answer = "";

            while (Scores.Count < n + 10)
            {
                int score = Scores[e1] + Scores[e2];

                //AddScore(score);
                Scores.AddRange(score.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray());

                e1 = (e1 + Scores[e1] + 1) % Scores.Count;
                e2 = (e2 + Scores[e2] + 1) % Scores.Count;
            }

            foreach (int score in Scores.Skip(n).Take(10))
            {
                answer += score;
            }

            return answer;
        }

        public string GetScoreString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in Scores)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }

        public int PartTwo(int n)
        {
            int e1 = 0, e2 = 1;
            string s = GetScoreString();

            while (!s.Contains(n.ToString()))
            {
                int score = Scores[e1] + Scores[e2];

                //AddScore(score);
                Scores.AddRange(score.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray());

                e1 = (e1 + Scores[e1] + 1) % Scores.Count;
                e2 = (e2 + Scores[e2] + 1) % Scores.Count;
                s = GetScoreString();
            }

            return s.IndexOf(n.ToString());

            
        }

        private void AddScore(int score)
        {
            int currentIndex = Scores.Count;
            while (score > 0)
            {
                int digit = score % 10;
                Scores.Insert(currentIndex, digit);
                score /= 10;
            }
        }
    }
}
