using System;
using System.Collections.Generic;

namespace BullsAndCows.SortingAlgorithms
{
    interface ISorter
    {
        List<PlayerScore> Sort(List<PlayerScore> leaderBoard);
    }
}
