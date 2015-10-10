namespace BullsAndCows.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class ComparerSorter : ISorter
    {
        public List<PlayerScore> Sort(List<PlayerScore> leaderBoard)
        {
            leaderBoard.Sort();

            return leaderBoard;
        }
    }
}
