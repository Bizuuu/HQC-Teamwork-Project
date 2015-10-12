// <summary>Contains the tests for OneParameterMessage class.</summary>
//-----------------------------------------------------------------------
// <copyright file="OneParameterMessageTests.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCowsGame.Tests.MessagesTests
{
    using System;
    using BullsAndCows.Messages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains the tests for OneParameterMessage.
    /// </summary>
    [TestClass]
    public class OneParameterMessageTests
    {
        /// <summary>
        /// Tests whether the OneParameterMessage shows the correct text.
        /// </summary>
        [TestMethod]
        public void OneParameterMessageShouldShowCorrectText()
        {
            string message = "Parameter message";
            int parameter = 1;

            var simpleMessage = new SimpleMessage(message);
            var oneParameterMessage = new OneParameterMessage(simpleMessage, parameter);

            string actual = string.Format(simpleMessage.Show(), parameter);
            string expected = oneParameterMessage.Show();

            Assert.AreEqual(expected, actual, "OneParameterMessage Show() doesn't return string in proper format.");
        }
    }
}
