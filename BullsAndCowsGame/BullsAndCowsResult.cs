// <summary>Contains the BullsAndCowsResult class.</summary>
//-----------------------------------------------------------------------
// <copyright file="BullsAndCowsResult.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    /// <summary>
    /// Bulls-cows results.
    /// </summary>
    public class BullsAndCowsResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BullsAndCowsResult" /> class.
        /// </summary>
        /// <param name="bulls">Integer number.</param>
        /// <param name="cows">Cows number.</param>
        public BullsAndCowsResult(int bulls, int cows)
        {
            this.Bulls = bulls;
            this.Cows = cows;
        }

        /// <summary>
        /// Gets Bulls.
        /// </summary>
        /// <value>Integer number.</value>
        public int Bulls { get; private set; }

        /// <summary>
        /// Gets cows.
        /// </summary>
        /// <value>Integer number.</value>
        public int Cows { get; private set; }
    }
}
