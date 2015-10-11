using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Messages;

namespace BullsAndCowsGame.Tests.MessagesTests
{
    /// <summary>
    /// This class contains all test methods for TwoParametersMessage.
    /// </summary>
    [TestClass]
    public class TwoParameterMessageTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string message = "Parameter message";
            int parameter1 = 1;
            int parameter2 = 2;

            var simpleMessage = new SimpleMessage(message);
            var twoParametersMessage = new TwoParameterMessage(simpleMessage, parameter1, parameter2);

            string actual = string.Format(simpleMessage.Show(), parameter1, parameter2);
            string expected = twoParametersMessage.Show();

            Assert.AreEqual(expected, actual, "TwoParameterMessage Show() doesn't return string in proper format.");
        }
    }
}
