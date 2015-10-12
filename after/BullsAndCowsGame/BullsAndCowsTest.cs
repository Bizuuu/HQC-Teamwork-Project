// <summary>Contains the BullsAndCowsTest class.</summary>
//-----------------------------------------------------------------------
// <copyright file="BullsAndCowsTest.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    /// <summary>
    /// Bulls and cows test.
    /// </summary>
    public class BullsAndCowsTest
    {
        /// <summary>
        /// Main Method of program.
        /// </summary>
        /// <param name="args">String arguments.</param>
        private static void Main(string[] args)
        {
            BullsAndCowsArcade arcade = new BullsAndCowsArcade();
            arcade.StartGame();
        }
    }
}
