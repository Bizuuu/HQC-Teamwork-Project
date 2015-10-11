// <summary>Contains the RandomNumberProviderTests class.</summary>  
// <copyright file="RandomNumberProviderTests.cs" company="Bulls-And-Cows-1">  
//     Everything is copyrighted.  
// </copyright>  
namespace BullsAndCowsGame.Tests
{
    using System;
    using BullsAndCows;
    using BullsAndCows.Contracts;
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
        public void RandomNumberProviderShouldReturnRandomNumberWhenGenerateNumberAsStringIsCalled()
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
