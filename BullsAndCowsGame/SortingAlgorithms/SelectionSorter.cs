namespace BullsAndCows.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sorting strategy using the selection sort algorithm.
    /// </summary>
    public class SelectionSorter : ISorter
    {
        /// <summary>
        /// Sorts the leaderboard using selection sort.
        /// </summary>
        /// <param name="leaderBoard">The leaderboard which is going to be sorted.</param>
        /// <returns>Returns the sorted leaderboard.</returns>
        public List<PlayerScore> Sort(List<PlayerScore> leaderBoard)
        {
            int minPosition;
            PlayerScore scoreTemporaryHolder;

            for (int i = 0; i < leaderBoard.Count - 1; i++)
            {
                minPosition = i;

                for (int j = i + 1; j < leaderBoard.Count; j++)
                {
                    if (leaderBoard[j].Guesses < leaderBoard[minPosition].Guesses)
                    {
                        // minPosition will keep track of the index that min is in, this is needed when a swap happens
                        minPosition = j;
                    }
                }

                // if minPosition no longer equals i then a smaller value must have been found, so a swap must occur
                if (minPosition != i)
                {
                    scoreTemporaryHolder = leaderBoard[i];
                    leaderBoard[i] = leaderBoard[minPosition];
                    leaderBoard[minPosition] = scoreTemporaryHolder;
                }
            }

            return leaderBoard;
        }
    }
}
