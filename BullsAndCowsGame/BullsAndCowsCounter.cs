using System;

namespace BullsAndCows
{
    public class BullsAndCowsCounter : IDisposable
    {
        private const byte GuessNumberLength = 4;
        private const byte AllDigitsCount = 10;
        private bool[] areBulls;
        private bool[] areCows;

        public BullsAndCowsCounter(string numberForGuess)
        {
            this.NumberForGuess = numberForGuess;
            this.areBulls = new bool[GuessNumberLength];
            this.areCows = new bool[AllDigitsCount];
        }

        private string NumberForGuess { get; set; }

        public BullsAndCowsResult CountBullsAndCows(string suggestedNumber)
        {
            var bulls = this.CountBulls(suggestedNumber);
            var cows = this.CountCows(suggestedNumber);
            return new BullsAndCowsResult(bulls, cows);
        }

        private int CountBulls(string suggestedNumber)
        {
            int bullsCount = 0;
            for (int i = 0; i < GuessNumberLength; i++)
            {
                if (suggestedNumber[i] == this.NumberForGuess[i])
                {
                    areBulls[i] = true;
                    bullsCount++;
                }
            }
            return bullsCount;
        }

        private int CountCows(string suggestedNumber)
        {
            int cowsCount = 0;
            for (int i = 0; i < GuessNumberLength; i++)
            {
                int suggestedDigit = int.Parse(suggestedNumber[i].ToString());
                if (!areBulls[i] && !areCows[suggestedDigit])
                {
                    areCows[suggestedDigit] = true;
                    for (int j = 0; j < suggestedNumber.Length; j++)
                    {
                        if (suggestedNumber[i] == this.NumberForGuess[j])
                        {
                            if (!areBulls[j])
                            {
                                cowsCount++;
                                break;
                            }
                        }
                    }
                }
            }

            return cowsCount;
        }

        public void Dispose()
        {
            this.areBulls = new bool[GuessNumberLength];
            this.areCows = new bool[AllDigitsCount];
        }
    }
}
