// <summary>Contains the BullsAndCowsCounter class.</summary>
//-----------------------------------------------------------------------
// <copyright file="BullsAndCowsCounter.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;

    /// <summary>
    /// Used for counting the bulls and cows.
    /// </summary>
    public class BullsAndCowsCounter : IDisposable
    {
        /// <summary>
        /// The length of the number which has to be guessed.
        /// </summary>
        private const byte GuessNumberLength = 4;

        /// <summary>
        /// The different digits which can be used to form a number.
        /// </summary>
        private const byte AllDigitsCount = 10;

        /// <summary>
        /// A helper used to count the number of bulls.
        /// </summary>
        private bool[] areBulls;

        /// <summary>
        /// A helper used to count the number of cows.
        /// </summary>
        private bool[] areCows;

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsCounter class.
        /// </summary>
        /// <param name="numberForGuess">The number which needs to be guessed.</param>
        public BullsAndCowsCounter(string numberForGuess)
        {
            this.NumberForGuess = numberForGuess;
            this.areBulls = new bool[GuessNumberLength];
            this.areCows = new bool[AllDigitsCount];
        }

        /// <summary>
        /// Gets or sets the number which has to be guessed.
        /// </summary>
        private string NumberForGuess { get; set; }

        /// <summary>
        /// Disposes the helpers used for calculating the bulls and cows.
        /// </summary>
        public void Dispose()
        {
            this.areBulls = new bool[GuessNumberLength];
            this.areCows = new bool[AllDigitsCount];
        }

        /// <summary>
        /// Public method used to initiate counting of the bulls and cows.
        /// </summary>
        /// <param name="suggestedNumber">The number with which the user tried.</param>
        /// <returns>Returns the bulls and cows in a BullsAndCowsResult.</returns>
        public BullsAndCowsResult CountBullsAndCows(string suggestedNumber)
        {
            var bulls = this.CountBulls(suggestedNumber);
            var cows = this.CountCows(suggestedNumber);
            return new BullsAndCowsResult(bulls, cows);
        }

        /// <summary>
        /// Counts the number of bulls.
        /// </summary>
        /// <param name="suggestedNumber">The guessed number by the user.</param>
        /// <returns>Returns an integer with the number of bulls.</returns>
        private int CountBulls(string suggestedNumber)
        {
            int bullsCount = 0;
            for (int i = 0; i < GuessNumberLength; i++)
            {
                if (suggestedNumber[i] == this.NumberForGuess[i])
                {
                   this.areBulls[i] = true;
                    bullsCount++;
                }
            }

            return bullsCount;
        }

        /// <summary>
        /// Counts the number of cows.
        /// </summary>
        /// <param name="suggestedNumber">The guessed by the user number.</param>
        /// <returns>Returns the number of cows.</returns>
        private int CountCows(string suggestedNumber)
        {
            int cowsCount = 0;
            for (int i = 0; i < GuessNumberLength; i++)
            {
                int suggestedDigit = int.Parse(suggestedNumber[i].ToString());
                if (!this.areBulls[i] && !this.areCows[suggestedDigit])
                {
                    this.areCows[suggestedDigit] = true;
                    for (int j = 0; j < suggestedNumber.Length; j++)
                    {
                        if (suggestedNumber[i] == this.NumberForGuess[j])
                        {
                            if (!this.areBulls[j])
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
