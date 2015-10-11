// <summary>Contains the ScoreBoard class.</summary>
//-----------------------------------------------------------------------
// <copyright file="ScoreBoard.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using SortingAlgorithms;

    /// <summary>
    /// Score board class.
    /// </summary>
    public class ScoreBoard
    {
        /// <summary>
        /// File path.
        /// </summary>
        public const string FilePath = "../../Common/scores.txt";

        private const string MaxPlayerExeptionText = "MaxPlayers should be a number bigger than 0";

        private const string ScoreWriterFormatText = "{0} {1}";

        private const char SpaceChar = ' ';

        private const string SpaceString = " ";


        /// <summary>
        /// List of scores.
        /// </summary>
        private List<PlayerScore> leaderBoard;

        /// <summary>
        /// Integer Number.
        /// </summary>
        private int maxPlayers;

        /// <summary>
        /// Sorter interface.
        /// </summary>
        private ISorter sorter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreBoard" /> class.
        /// </summary>
        /// <param name="maxPlayers">Integer number.</param>
        public ScoreBoard(int maxPlayers)
        {
            this.sorter = new ComparerSorter();
            this.leaderBoard = this.ReadScores();
            this.MaxPlayers = maxPlayers;
        }

        /// <summary>
        /// Gets or sets maximum players.
        /// </summary>
        /// <value>Integer number.</value>
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
                    throw new ArgumentOutOfRangeException(MaxPlayerExeptionText);
                }

                this.maxPlayers = value;
            }
        }

        // Use this only when trying to access leaderBoard from outside this class

        /// <summary>
        /// Gets IList of scores.
        /// </summary>
        /// <value>Scores List.</value>
        public IList<PlayerScore> LeaderBoard
        {
            get
            {
                this.leaderBoard = this.sorter.Sort(this.leaderBoard);
                this.leaderBoard = this.leaderBoard.Take(this.MaxPlayers).ToList();

                return this.leaderBoard;
            }
        }

        /// <summary>
        /// Adds player score.
        /// </summary>
        /// <param name="playerScore">Player score.</param>
        public void AddPlayerScore(PlayerScore playerScore)
        {
            StreamWriter scoresWriter = new StreamWriter(FilePath, true);

            using (scoresWriter)
            {
                scoresWriter.WriteLine(ScoreWriterFormatText, playerScore.NickName, playerScore.Guesses);
            }

            this.leaderBoard.Add(playerScore);
        }

        /// <summary>
        /// Reads score.        
        /// </summary>
        /// <returns>List of scores.</returns>
        private List<PlayerScore> ReadScores()
        {
            StreamReader scoresReader = new StreamReader(FilePath);
            List<PlayerScore> result = new List<PlayerScore>();
            string currLine = string.Empty;

            using (scoresReader)
            {
                while ((currLine = scoresReader.ReadLine()) != null)
                {
                    string[] data = currLine.Split(SpaceChar);
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
                                name += data[i] + SpaceString;
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
