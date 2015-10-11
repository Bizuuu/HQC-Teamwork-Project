namespace BullsAndCows
{
    public class BullsAndCowsResult
    {
        public BullsAndCowsResult(int bulls, int cows)
        {
            this.Bulls = bulls;
            this.Cows = cows;
        }

        public int Bulls { get; private set; }

        public int Cows { get; private set; }
    }
}
