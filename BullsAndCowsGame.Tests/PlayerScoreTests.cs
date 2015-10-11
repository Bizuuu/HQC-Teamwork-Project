namespace BullsAndCows.Tests
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
    }
}
