using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.SortingAlgorithms
{
    interface ISorter
    {
        List<PlayerScore> Sort(IEnumerable<PlayerScore> leaderBoard);
    }
}
