using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class ScoreBoard
    {
        private List<PlayerScore> leaderBoard;
        private int maxPlayers;

        public ScoreBoard(int maxPlayers)
        {
            this.leaderBoard = new List<PlayerScore>();
            this.MaxPlayers = maxPlayers;
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

        public IList<PlayerScore> LeaderBoard
        {
            get
            {
                this.leaderBoard.Sort();
                this.leaderBoard = this.leaderBoard.Take(this.MaxPlayers).ToList();
                return this.leaderBoard;
            }
        }

        public void AddPlayerScore(PlayerScore playerScore)
        {
            this.leaderBoard.Add(playerScore);
        }
    }
}
