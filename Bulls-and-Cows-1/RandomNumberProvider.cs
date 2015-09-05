namespace BullsAndCows
{
    using System;
    using BullsAndCows.Contracts;

    public class RandomNumberProvider : IRandomNumberProvider
    {
        private static RandomNumberProvider randomNumberProvider;

        private RandomNumberProvider() { }

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

        public int GenerateNumber()
        {
            throw new NotImplementedException();
        }
    }
}
