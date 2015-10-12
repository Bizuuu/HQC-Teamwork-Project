// <summary>Contains the ComparerSorter class.</summary>
//-----------------------------------------------------------------------
// <copyright file="ComparerSorter.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Strategy classed used for sorting using ComparerSort.
    /// </summary>
    public class ComparerSorter : ISorter
    {
        /// <summary>
        /// Sorts a leaderboard using ComparerSort.
        /// </summary>
        /// <param name="leaderBoard">The leaderboard which is going to be sorted.</param>
        /// <returns>Returns the sorted leaderboard.</returns>
        public List<PlayerScore> Sort(List<PlayerScore> leaderBoard)
        {
            leaderBoard.Sort();

            return leaderBoard;
        }
    }
}
