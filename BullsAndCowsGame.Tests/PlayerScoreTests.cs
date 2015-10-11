namespace BullsAndCowsGame.Tests
{
    using System;
    using BullsAndCows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerScoreTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithNullStringForName()
        {
            PlayerScore playerScore = new PlayerScore(null, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithEmptyStringForName()
        {
            PlayerScore playerScore = new PlayerScore(string.Empty, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithWhitespaceForName()
        {
            PlayerScore playerScore = new PlayerScore("  ", 3);
        }

        [TestMethod]
        public void CompareToShouldReturnCorrectNumber()
        {
            PlayerScore score1 = new PlayerScore("Score1", 5);
            PlayerScore score2 = new PlayerScore("Score2", 2);

            int actual = score1.CompareTo(score2);
            int expected = 1;

            Assert.AreEqual(expected, actual, "CompareTo doesn't return correct integer when comparing two PlayerScores");
        }

        [TestMethod]
        public void CompareToShouldReturnCorrectNumberWhenComparingPlayerScoresWithEqualGuesses()
        {
            PlayerScore score1 = new PlayerScore("Score1", 2);
            PlayerScore score2 = new PlayerScore("Score2", 2);

            int actual = score1.CompareTo(score2);
            int expected = -1;

            Assert.AreEqual(expected, actual, "CompareTo doesn't return correct integer when comparing two PlayerScores with equal guesses");
        }

        [TestMethod]
        public void ToStringShouldReturnCorrectFormatMessage()
        {
            PlayerScore score = new PlayerScore("Player", 2);

            string actual = score.ToString();
            string expected = string.Format("{0,3}    | {1}", score.Guesses, score.NickName);

            Assert.AreEqual(expected, actual, "StringTo doesn't return proper formatted string");
        }
    }
}
