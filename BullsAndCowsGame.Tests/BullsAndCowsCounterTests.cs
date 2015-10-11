// <summary>Contains the tests for BullsAndCowsCounter class.</summary>
//-----------------------------------------------------------------------
// <copyright file="BullsAndCowsCounterTests.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCowsGame.Tests
{
    using System;
    using BullsAndCows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for BullsAndCowsCounter class.
    /// </summary>
    [TestClass]
    public class BullsAndCowsCounterTests
    {
        /// <summary>
        /// Tests whether the counter returns the correct number of bulls.
        /// </summary>
        [TestMethod]
        public void BullsAndCowsCounterShouldReturnCorrectNumberOfBulls()
        {
            var bullsAndCowsCounter = new BullsAndCows.BullsAndCowsCounter("1234");

            BullsAndCowsResult actual = bullsAndCowsCounter.CountBullsAndCows("1529");

            BullsAndCowsResult expected = new BullsAndCowsResult(1, 1);

            Assert.AreEqual(expected.Bulls, actual.Bulls);
        }

        /// <summary>
        /// Tests whether the counter returns the correct number of cows.
        /// </summary>
        [TestMethod]
        public void BullsAndCowsCounterShouldReturnCorrectNumberOfCows()
        {
            var bullsAndCowsCounter = new BullsAndCows.BullsAndCowsCounter("1234");

            BullsAndCowsResult actual = bullsAndCowsCounter.CountBullsAndCows("1529");

            BullsAndCowsResult expected = new BullsAndCowsResult(1, 1);

            Assert.AreEqual(expected.Cows, actual.Cows);
        }
    }
}
