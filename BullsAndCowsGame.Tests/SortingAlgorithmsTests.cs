using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.SortingAlgorithms;
using BullsAndCows;

namespace BullsAndCowsGame.Tests
{
    /// <summary>
    /// Sorting Algorthims tests.
    /// </summary>
    [TestClass]
    public class SortingAlgorithmsTests
    {
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

            //Assert.AreEqual(sortedScoreBoard[i].Guesses, expectedScoreBoard[i].Guesses);
            CollectionAssert.Equals(sortedScoreBoard, expectedScoreBoard);
        }

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
