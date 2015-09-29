using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class ScoreBoard
    {
        private IList<PlayerScore> leaderBoard;
        private int maxPlayers;

        public ScoreBoard(int maxPlayers)
        {
            this.leaderBoard = new List<PlayerScore>();
            this.maxPlayers = maxPlayers;
        }

        public int MaxPlayers 
        { 
            get
            {
                return this.maxPlayers;
            }

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("MaxPlayers should be a number bigger than 0");
                }

                this.maxPlayers = value;
            }
        }

        public void AddPlayerScore(PlayerScore playerScore)
        {
            if (this.leaderBoard.Count < this.MaxPlayers)
            {
                // TODO: extract a method 
                for (int i = 0; i < this.leaderBoard.Count; i++)
                {
                    if (this.leaderBoard[i].Guesses > playerScore.Guesses)
                    {
                        this.leaderBoard.Insert(i, playerScore);
                    }
                }
            }
            else if (this.leaderBoard[this.MaxPlayers - 1].Guesses > playerScore.Guesses)
            {
                for (int i = 0; i < this.MaxPlayers; i++)
                {
                    if (this.leaderBoard[i].Guesses > playerScore.Guesses)
                    {
                        this.leaderBoard.Insert(i, playerScore);
                    }
                }
            }
        }
    }
}
