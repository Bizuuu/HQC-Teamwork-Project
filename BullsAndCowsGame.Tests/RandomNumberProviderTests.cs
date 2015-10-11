namespace BullsAndCows.Tests
{
    using BullsAndCows;
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RandomNumberProviderTests
    {
        [TestMethod]
        public void RandomNumberProviderShouldReturnRandomNumberWhenGenerateNumberAsStringIsCalled()
        {
            IRandomNumberProvider randomProvider = RandomNumberProvider.Instance;
            int firstNumber = randomProvider.GenerateNumber(1000, 9999);
            int secondNumber = randomProvider.GenerateNumber(1000, 9999);
            Assert.AreNotEqual(firstNumber, secondNumber);
        }

        [TestMethod]
        public void RandomNumberProviderShouldReturnFourDigitNumberWhenGenerateNumberAsStringIsCalled()
        {
            IRandomNumberProvider randomProvider = RandomNumberProvider.Instance;
            string number = randomProvider.GenerateNumber(1000, 9999).ToString();
            int actualNumberOfDigits = number.Length;
            int expectedNumberOfDigits = 4;
            Assert.AreEqual(actualNumberOfDigits, expectedNumberOfDigits);
        }
    }
}
