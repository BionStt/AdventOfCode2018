using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DayNine
{
    public class MarbleMania
    {
        public string[] Lines { get; private set; }
        public List<int> Marbles { get; set; }
        public int PlayerCount { get; private set; }
        public int FinalMarble { get; private set; }
        public int CurrentIndex = 0;
        public Dictionary<int, long> PlayerScores = new Dictionary<int, long>();

        public MarbleMania() { }

        public MarbleMania(string[] lines)
        {
            Lines = lines;
        }

        public MarbleMania(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
        }

        public MarbleMania(int players, int lastMarble)
        {
            PlayerCount = players;
            FinalMarble = lastMarble;

            Marbles = new List<int>
            {
                0
            };

            SetupPlayers();
        }

        private void SetupPlayers()
        {
            for (int i = 1; i <= PlayerCount; i++)
            {
                PlayerScores.Add(i, 0);
            }
        }

        private void PlayGame()
        {
            int currentPlayer = 1;

            for (int i = 1; i <= FinalMarble; i++)
            {
                if (i % 23 == 0)
                {
                    HandleDivisibleByTwentyThree(i, currentPlayer);
                }
                else
                {
                    int index = GetNextIndex();
                    Marbles.Insert(index, i);
                    CurrentIndex = index;
                }

                // Can trim the end of the list here if not being used.
                //TrimMarbles();

                currentPlayer = NextPlayer(currentPlayer);
            }
        }

        // Was experimenting with a trim, it's not working currently.
        // It gets the right answer in around 20 minutes without a trim.

        private void TrimMarbles()
        {
            //if (CurrentIndex > 200000)
            //{
            //    Marbles.RemoveRange(0, 50000);
            //    CurrentIndex -= 50000;
            //}

            if (Marbles.Count > 1000000 && CurrentIndex < Marbles.Count - 500000 && CurrentIndex > 50000)
            {
                Marbles.RemoveRange(Marbles.Count - 250000, 250000);
            }
        }

        private int GetNextIndex()
        {
            int index = (CurrentIndex + 2) % Marbles.Count;

            return index == 0 ? Marbles.Count : index;
        }

        private int NextPlayer(int currentPlayer)
        {
            return currentPlayer + 1 > PlayerCount ? 1 : currentPlayer + 1;
        }

        private void HandleDivisibleByTwentyThree(int marble, int currentPlayer)
        {
            int index = CurrentIndex - 7;

            if (index < 0)
            {
                index = Marbles.Count + index;
            }

            if (index == Marbles.Count - 1)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex = index;
            }

            int score = marble + Marbles[index];
            PlayerScores[currentPlayer] += score;
            Marbles.RemoveAt(index);
        }

        public long PartOne()
        {
            PlayGame();

            return PlayerScores.Values.Max();
        }
    }
}
