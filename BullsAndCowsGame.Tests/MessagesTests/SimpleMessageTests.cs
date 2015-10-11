// <summary>Contains the tests for SimpleMessage class.</summary>
//-----------------------------------------------------------------------
// <copyright file="SimpleMessageTests.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCowsGame.Tests.MessagesTests
{
    using BullsAndCows.Messages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This class contains tests for SimpleMessage.
    /// </summary>
    [TestClass]
    public class SimpleMessageTests
    {
        /// <summary>
        /// Tests whether the simple message returns a correct string.
        /// </summary>
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
