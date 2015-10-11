using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsGame.Tests
{
    /// <summary>
    /// Tests for BullsAndCowsCounter class
    /// </summary>
    [TestClass]
    public class BullsAndCowsCounterTests
    {
        [TestMethod]
        public void BullsAndCowsCounterShouldReturnCorrectNumberOfBulls()
        {
            var bullsAndCowsCounter = new BullsAndCows.BullsAndCowsCounter("1234");

            BullsAndCowsResult actual = bullsAndCowsCounter.CountBullsAndCows("1529");

            BullsAndCowsResult expected = new BullsAndCowsResult(1, 1);

            Assert.AreEqual(expected.Bulls, actual.Bulls);
        }

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
