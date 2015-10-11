using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Messages;

namespace BullsAndCowsGame.Tests.MessagesTests
{
    /// <summary>
    /// Summary description for OneParameterMessage
    /// </summary>
    [TestClass]
    public class OneParameterMessageTests
    {
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
