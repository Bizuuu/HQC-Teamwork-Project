// <summary>Contains the RandomNumberProviderTests class.</summary>
namespace BullsAndCows.Tests
{
    using BullsAndCows;
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains all the tests related to the RandomNumberProvider.
    /// </summary>
    [TestClass]
    public class RandomNumberProviderTests
    {
        /// <summary>
        /// Tests whether the generated numbers are different.
        /// </summary>
        [TestMethod]
        public void RandomNumberProviderShouldReturnRandomNumberWhenGenerateNumberIsCalled()
        {
            IRandomNumberProvider randomProvider = RandomNumberProvider.Instance;
            int firstNumber = randomProvider.GenerateNumber(1000, 9999);
            int secondNumber = randomProvider.GenerateNumber(1000, 9999);
            Assert.AreNotEqual(firstNumber, secondNumber);
        }

        /// <summary>
        /// Tests whether the number generated is a four digit number.
        /// </summary>
        [TestMethod]
        public void RandomNumberProviderShouldReturnFourDigitNumberWhenGenerateNumberIsCalled()
        {
            IRandomNumberProvider randomProvider = RandomNumberProvider.Instance;
            string number = randomProvider.GenerateNumber(1000, 9999).ToString();
            int actualNumberOfDigits = number.Length;
            int expectedNumberOfDigits = 4;
            Assert.AreEqual(actualNumberOfDigits, expectedNumberOfDigits);
        }
    }
}
