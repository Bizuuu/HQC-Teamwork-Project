using System;

namespace BullsAndCows
{
    public class BullsAndCowsCounter
    {
        private const byte GuessNumberLength = 4;
        private const byte AllDigitsCount = 10;
        private bool[] areBulls;
        private bool[] areCows;

        public BullsAndCowsCounter(string suggestedNumber, string numberForGuess)
        {
            this.SuggestedNumber = suggestedNumber;
            this.NumberForGuess = numberForGuess;
            this.areBulls = new bool[GuessNumberLength];
            this.areCows = new bool[AllDigitsCount];
        }

        private string NumberForGuess { get; set; }

        private string SuggestedNumber { get; set; }

        public BullsAndCowsResult CountBullsAndCows()
        {
            var bulls = this.CountBulls();
            var cows = this.CountCows();
            return new BullsAndCowsResult(bulls, cows);
        }

        private int CountBulls()
        {
            int bullsCount = 0;
            for (int i = 0; i < GuessNumberLength; i++)
            {
                if (this.SuggestedNumber[i] == this.NumberForGuess[i])
                {
                    areBulls[i] = true;
                    bullsCount++;
                }
            }
            return bullsCount;
        }

        private int CountCows()
        {
            int cowsCount = 0;
            for (int i = 0; i < GuessNumberLength; i++)
            {
                int suggestedDigit = int.Parse(this.SuggestedNumber[i].ToString());
                if (!areBulls[i] && !areCows[suggestedDigit])
                {
                    areCows[suggestedDigit] = true;
                    for (int j = 0; j < this.SuggestedNumber.Length; j++)
                    {
                        if (this.SuggestedNumber[i] == this.NumberForGuess[j])
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
    }
}
