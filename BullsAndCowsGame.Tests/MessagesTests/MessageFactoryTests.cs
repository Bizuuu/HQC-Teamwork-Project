using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Messages;
using BullsAndCows.Common;

namespace BullsAndCowsGame.Tests.MessagesTests
{
    /// <summary>
    /// This class containts all tests for MessageFactory class
    /// </summary>
    [TestClass]
    public class MessageFactoryTests
    {
        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.Welcome as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeWelcome()
        {
            var messageFactory = new MessageFactory();

            string actual = "Welcome to “Bulls and Cows” game.";
            string expected = messageFactory.MakeMessage(MessageType.Welcome);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType Welcome.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.GameRules as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeGameRules()
        {
            var messageFactory = new MessageFactory();
           
            string actual = "Please try to guess my secret 4-digit number. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
            string expected = messageFactory.MakeMessage(MessageType.GameRules);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType GameRules.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.Command as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeCommand()
        {
            var messageFactory = new MessageFactory();

            string actual = "Enter your guess or command: ";
            string expected = messageFactory.MakeMessage(MessageType.Command);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType Command.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.EnterName as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeEnterName()
        {
            var messageFactory = new MessageFactory();

            string actual = "Please enter your name: ";
            string expected = messageFactory.MakeMessage(MessageType.EnterName);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType EnterName.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.Exit as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeExit()
        {
            var messageFactory = new MessageFactory();

            string actual = "Good bye!";
            string expected = messageFactory.MakeMessage(MessageType.Exit);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType Exit.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.InvalidCommand as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeInvalidCommand()
        {
            var messageFactory = new MessageFactory();

            string actual = "Invalid command!";
            string expected = messageFactory.MakeMessage(MessageType.InvalidCommand);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType InvalidCommand.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.InvalidNumberLength as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeInvalidNumberLength()
        {
            var messageFactory = new MessageFactory();

            string actual = "Number is too long or too short - must be 4 digits!";
            string expected = messageFactory.MakeMessage(MessageType.InvalidNumberLength);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType InvalidNumberLength.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.Command as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeWrongNumber()
        {
            var messageFactory = new MessageFactory();
            int bulls = 1;
            int cows = 1;

            string actual = string.Format("Wrong number! Bulls: {0}, Cows: {1}!", bulls, cows);
            string expected = messageFactory.MakeMessage(MessageType.WrongNumber, bulls, cows);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType WrongNumber.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.Congratulation as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeCongratulation()
        {
            var messageFactory = new MessageFactory();
            int attempts = 3;

            string actual = string.Format("Congratulations! You guessed the secret number in {0} attempts.", attempts);
            string expected = messageFactory.MakeMessage(MessageType.Congratulation, attempts);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType Congratulation.");
        }

        /// <summary>
        /// Tests if MakeMessage returns proper string when given MessageType.CheatCongratulation as parameter.
        /// </summary>
        [TestMethod]
        public void MakeMessageShouldReturnProperMessageWhenGivenMessageTypeCheatCongratulation()
        {
            var messageFactory = new MessageFactory();
            int attempts = 3;
            int cheats = 2;

            string actual = string.Format("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", attempts, cheats);
            string expected = messageFactory.MakeMessage(MessageType.CheatCongratulation, attempts, cheats);

            Assert.AreEqual(expected, actual, "MakeMessage doesn't return proper message when given MessageType CheatCongratulation.");
        }
    }
}
