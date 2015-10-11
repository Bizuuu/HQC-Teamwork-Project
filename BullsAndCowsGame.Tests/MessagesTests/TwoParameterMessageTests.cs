// <summary>Contains the tests for TwoParameterMessage class.</summary>
//-----------------------------------------------------------------------
// <copyright file="TwoParameterMessageTests.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCowsGame.Tests.MessagesTests
{
    using BullsAndCows.Messages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// This class contains all test methods for TwoParametersMessage.
    /// </summary>
    [TestClass]
    public class TwoParameterMessageTests
    {
        /// <summary>
        /// Tests whether the two parameter message returns a properly formatted string.
        /// </summary>
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
