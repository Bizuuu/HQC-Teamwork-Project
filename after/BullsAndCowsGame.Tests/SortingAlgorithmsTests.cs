// <summary>Contains the SortingAlgorithmsTests class.</summary>  
// <copyright file="SortingAlgorithmsTests.cs" company="Bulls-And-Cows-1">  
//     Everything is copyrighted.  
// </copyright>  
namespace BullsAndCowsGame.Tests
{
    using System.Collections.Generic;
    using BullsAndCows;
    using BullsAndCows.SortingAlgorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Sorting Algorithms tests.
    /// </summary>
    [TestClass]
    public class SortingAlgorithmsTests
    {
        /// <summary>
        /// Tests whether the selection sort algorithm works correctly.
        /// </summary>
        [TestMethod]
        public void SelectionSortingAlgorithmShouldSortListProperly()
        {
            var selectionSorter = new SelectionSorter();

            var actualScoreBoard = new List<PlayerScore>();
           
            actualScoreBoard.Add(new PlayerScore("Pesho1", 1));
            actualScoreBoard.Add(new PlayerScore("Pesho5", 5));
            actualScoreBoard.Add(new PlayerScore("Pesho3", 3));
            actualScoreBoard.Add(new PlayerScore("Pesho4", 4));
            actualScoreBoard.Add(new PlayerScore("Pesho2", 2));

            var sortedScoreBoard = selectionSorter.Sort(actualScoreBoard);

            var expectedScoreBoard = new List<PlayerScore>();

            expectedScoreBoard.Add(new PlayerScore("Pesho1", 1));
            expectedScoreBoard.Add(new PlayerScore("Pesho2", 2));
            expectedScoreBoard.Add(new PlayerScore("Pesho3", 3));
            expectedScoreBoard.Add(new PlayerScore("Pesho4", 4));
            expectedScoreBoard.Add(new PlayerScore("Pesho5", 5));

            // Assert.AreEqual(sortedScoreBoard[i].Guesses, expectedScoreBoard[i].Guesses);
            CollectionAssert.Equals(sortedScoreBoard, expectedScoreBoard);
        }

        /// <summary>
        /// Tests whether the built in comparer sort sorts the PlayerScores correctly.
        /// </summary>
        [TestMethod]
        public void SortingUsingBuiltInPlayerScoreComparerShouldSortListProperly()
        {
            var selectionSorter = new ComparerSorter();

            var actualScoreBoard = new List<PlayerScore>();

            actualScoreBoard.Add(new PlayerScore("Pesho1", 1));
            actualScoreBoard.Add(new PlayerScore("Pesho5", 5));
            actualScoreBoard.Add(new PlayerScore("Pesho3", 3));
            actualScoreBoard.Add(new PlayerScore("Pesho4", 4));
            actualScoreBoard.Add(new PlayerScore("Pesho2", 2));

            var sortedScoreBoard = selectionSorter.Sort(actualScoreBoard);

            var expectedScoreBoard = new List<PlayerScore>();

            expectedScoreBoard.Add(new PlayerScore("Pesho1", 1));
            expectedScoreBoard.Add(new PlayerScore("Pesho2", 2));
            expectedScoreBoard.Add(new PlayerScore("Pesho3", 3));
            expectedScoreBoard.Add(new PlayerScore("Pesho4", 4));
            expectedScoreBoard.Add(new PlayerScore("Pesho5", 5));

            CollectionAssert.Equals(sortedScoreBoard, expectedScoreBoard);
        }
    }
}
