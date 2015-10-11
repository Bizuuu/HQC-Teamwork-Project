// <summary>Contains the ISorter interface.</summary>
namespace BullsAndCows.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the needed methods a sorter should have.
    /// </summary>
    public interface ISorter
    {
        /// <summary>
        /// Sort method used to sort a leaderboard using a specific algorithm.
        /// </summary>
        /// <param name="leaderBoard">The leaderboard which is going to be sorted.</param>
        /// <returns>Returns the sorted leaderboard.</returns>
        List<PlayerScore> Sort(List<PlayerScore> leaderBoard);
    }
}
