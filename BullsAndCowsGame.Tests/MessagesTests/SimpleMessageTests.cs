using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Messages;

namespace BullsAndCowsGame.Tests.MessagesTests
{
    /// <summary>
    /// This class containts tests for SimpleMessage.
    /// </summary>
    [TestClass]
    public class SimpleMessageTests
    {
        [TestMethod]
        public void SimpleMessageShowShouldReturnCorrectString()
        {
            var simpleMessage = new SimpleMessage("Simple message");

            string actual = "Simple message";
            string expected = simpleMessage.Show();

            Assert.AreEqual(expected, actual, "Show() function from Simple Message doesn't return correct string");
        }
    }
}
