namespace BullsAndCows.Tests
{
    using System.Collections.Generic;
    using BullsAndCows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreBoardTests
    {
        #region Additional test attributes
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            int maxPlayers = 5;
            var scoreBoard = new ScoreBoard(maxPlayers);
            var expectedScoreBoard = new List<PlayerScore>();

            expectedScoreBoard.Add(new PlayerScore("Pesho0", 0));
            expectedScoreBoard.Add(new PlayerScore("Pesho1", 1));
            expectedScoreBoard.Add(new PlayerScore("Pesho2", 2));
            expectedScoreBoard.Add(new PlayerScore("Pesho3", 3));
            expectedScoreBoard.Add(new PlayerScore("Pesho4", 4));

            for (int i = 0; i < maxPlayers; i++)
            {
                scoreBoard.AddPlayerScore(new PlayerScore("Pesho" + i, i));
            }

            Assert.AreEqual(expectedScoreBoard, scoreBoard.LeaderBoard, "LeaderBoards is not showing scores properly");
        }
    }
}
