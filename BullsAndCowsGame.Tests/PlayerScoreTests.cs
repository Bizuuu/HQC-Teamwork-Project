namespace BullsAndCowsGame.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerScoreTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithNullStringForName()
        {
            PlayerScore playerScore = new PlayerScore(null, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithEmptyStringForName()
        {
            PlayerScore playerScore = new PlayerScore(string.Empty, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerScoreShouldThrowArgumentExceptionWhenInitializedWithWhitespaceForName()
        {
            PlayerScore playerScore = new PlayerScore("  ", 3);
        }
    }
}
