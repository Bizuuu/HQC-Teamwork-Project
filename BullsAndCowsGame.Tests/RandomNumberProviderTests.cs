namespace BullsAndCowsGame.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows;
    using BullsAndCows.Contracts;

    [TestClass]
    public class RandomNumberProviderTests
    {
        [TestMethod]
        public void RandomNumberProviderShouldReturnRandomNumberWhenGenerateNumberAsStringIsCalled()
        {
            IRandomNumberProvider randomProvider = RandomNumberProvider.Instance;
            string firstNumber = randomProvider.GenerateNumberAsString();
            string secondNumber = randomProvider.GenerateNumberAsString();
            Assert.AreNotEqual(firstNumber, secondNumber);
        }

        [TestMethod]
        public void RandomNumberProviderShouldReturnFourDigitNumberWhenGenerateNumberAsStringIsCalled()
        {
            IRandomNumberProvider randomProvider = RandomNumberProvider.Instance;
            string number = randomProvider.GenerateNumberAsString();
            int actualNumberOfDigits = number.Length;
            int expectedNumberOfDigits = 4;
            Assert.AreEqual(actualNumberOfDigits, expectedNumberOfDigits);
        }
    }
}
