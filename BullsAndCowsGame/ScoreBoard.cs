namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using BullsAndCows.SortingAlgorithms;

    public class ScoreBoard
    {
        public const string FilePath = "../../Common/scores.txt";

        private List<PlayerScore> leaderBoard;
        private int maxPlayers;
        private ISorter sorter;

        public ScoreBoard(int maxPlayers)
        {
            this.sorter = new ComparerSorter();
            this.leaderBoard = this.ReadScores();
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("MaxPlayers should be a number bigger than 0");
                }

                this.maxPlayers = value;
            }
        }

        // Use this only when trying to access leaderBoard from outside this class
        public IList<PlayerScore> LeaderBoard
        {
            get
            {
                this.leaderBoard = this.sorter.Sort(this.leaderBoard);
                this.leaderBoard = this.leaderBoard.Take(this.MaxPlayers).ToList();

                return this.leaderBoard;
            }
        }

        public void AddPlayerScore(PlayerScore playerScore)
        {
            StreamWriter scoresWriter = new StreamWriter(FilePath, true);

            using (scoresWriter)
            {
                scoresWriter.WriteLine("{0} {1}", playerScore.NickName, playerScore.Guesses);
            }

            this.leaderBoard.Add(playerScore);
        }

        private List<PlayerScore> ReadScores()
        {
            StreamReader scoresReader = new StreamReader(FilePath);
            List<PlayerScore> result = new List<PlayerScore>();
            string currLine = string.Empty;

            using (scoresReader)
            {
                while ((currLine = scoresReader.ReadLine()) != null)
                {
                    string[] data = currLine.Split(' ');
                    string name = string.Empty;
                    int score;

                    if (data.Length == 2)
                    {
                        name = data[0];
                        score = int.Parse(data[1]);
                    }
                    else
                    {
                        for (int i = 0; i < data.Length - 1; i++)
                        {
                            if (i == data.Length - 2)
                            {
                                name += data[i];
                            }
                            else
                            {
                                name += data[i] + " ";
                            }
                        }

                        score = int.Parse(data[data.Length - 1]);
                    }

                    result.Add(new PlayerScore(name, score));
                }
            }

            return result;
        }
    }
}
