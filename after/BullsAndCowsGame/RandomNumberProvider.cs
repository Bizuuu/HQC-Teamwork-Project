// <summary>Contains the RandomNumberProvider class.</summary>
//-----------------------------------------------------------------------
// <copyright file="RandomNumberProvider.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;
    using Contracts;

    /// <summary>
    /// Random Provider.
    /// </summary>
    public class RandomNumberProvider : IRandomNumberProvider
    {
        /// <summary>
        /// Random provider.
        /// </summary>
        private static RandomNumberProvider randomNumberProvider;

        /// <summary>
        /// Random new.
        /// </summary>
        private Random random;

        /// <summary>
        /// Prevents a default instance of the <see cref="RandomNumberProvider" /> class from being created.
        /// </summary>
        private RandomNumberProvider()
        {
            this.random = new Random();
        }

        /// <summary>
        /// Gets Static Random instance.
        /// </summary>
        /// <value>I Random provider.</value>
        public static IRandomNumberProvider Instance
        {
            get
            {
                if (randomNumberProvider == null)
                {
                    randomNumberProvider = new RandomNumberProvider();
                }

                return randomNumberProvider;
            }
        }

        /// <summary>
        /// Generates Number.
        /// </summary>
        /// <param name="from">Integer number.</param>
        /// <param name="to">Other integer number.</param>
        /// <returns>Generated number.</returns>
        public int GenerateNumber(int from, int to)
        {
            int numberToGuess = this.random.Next(from, to + 1);
            return numberToGuess;
        }
    }
}
