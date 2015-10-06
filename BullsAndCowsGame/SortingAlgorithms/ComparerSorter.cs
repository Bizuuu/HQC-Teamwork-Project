using System;
using System.Collections.Generic;

namespace BullsAndCows.SortingAlgorithms
{
    public class ComparerSorter : ISorter
    {
        public List<PlayerScore> Sort(List<PlayerScore> leaderBoard)
        {
            leaderBoard.Sort();

            return leaderBoard;
        }
    }
}
