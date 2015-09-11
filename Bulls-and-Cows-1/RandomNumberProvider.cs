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

        public IRandomNumberProvider Instance
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

        public string GenerateNumberAsString()
        {
            int numberToGuess = this.random.Next(1000, 10000);
            string numberToGuessAsString = numberToGuess.ToString();
            return numberToGuessAsString;
        }
    }
}
