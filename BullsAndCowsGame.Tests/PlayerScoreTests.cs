// <summary>Contains the PlayerScoreTests class.</summary>
namespace BullsAndCows.Tests
{
    using System;
    using BullsAndCows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This class contains all tests related to the PlayerScore class.
    /// </summary>
    [TestClass]
    public class PlayerScoreTests
    {
        /// <summary>
        /// Tests whether PlayerScore throws exception when a null is given for name.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithNullStringForName()
        {
            PlayerScore playerScore = new PlayerScore(null, 3);
        }

        /// <summary>
        /// Tests whether PlayerScore throws exception when an empty string is given for name.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithEmptyStringForName()
        {
            PlayerScore playerScore = new PlayerScore(string.Empty, 3);
        }

        /// <summary>
        /// Tests whether PlayerScore throws exception when a whitespace is given for name.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithWhitespaceForName()
        {
            PlayerScore playerScore = new PlayerScore("  ", 3);
        }

        /// <summary>
        /// Tests whether the PlayerScore correctly sets the nickname and guesses.
        /// </summary>
        [TestMethod]
        public void PlayerScoreShouldBeInitializedCorrectlyWhenProperValuesArePassed()
        {
            PlayerScore playerScore = new PlayerScore("Test", 3);
            string expectedName = "Test";
            int expectedGuesses = 3;

            Assert.AreEqual(expectedName, playerScore.NickName);
            Assert.AreEqual(expectedGuesses, playerScore.Guesses);
        }
    }
}
