namespace BullsAndCows.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public interface ISorter
    {
        List<PlayerScore> Sort(List<PlayerScore> leaderBoard);
    }
}
