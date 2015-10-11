namespace BullsAndCows
{
    using System;
    using BullsAndCows.Contracts;

    public class RandomNumberProvider : IRandomNumberProvider
    {
        private static RandomNumberProvider randomNumberProvider;
        private Random random;

        private RandomNumberProvider()
        {
            this.random = new Random();
        }

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

        public int GenerateNumber(int from, int to)
        {
            int numberToGuess = this.random.Next(from, to + 1);
            return numberToGuess;
        }
    }
}
