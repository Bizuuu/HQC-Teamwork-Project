// <summary>Contains the IPrinter interface.</summary>
//-----------------------------------------------------------------------
// <copyright file="IPrinter.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.Contracts
{
    using System.Collections.Generic;
    using Common;

    /// <summary>
    /// Holds the needed methods for a printer.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Prints a message which requires 2 parameters.
        /// </summary>
        /// <param name="messageType">The type of the message.</param>
        /// <param name="parametere">First parameter.</param>
        /// <param name="secondParameter">Second parameter.</param>
        void PrintMessage(MessageType messageType, int parametere, int secondParameter);

        /// <summary>
        /// Prints a message which needs no parameters.
        /// </summary>
        /// <param name="messageType">The type of the message to be printed.</param>
        void PrintMessage(MessageType messageType);

        /// <summary>
        /// Prints a message with 1 parameter.
        /// </summary>
        /// <param name="messageType">The type of the message to be printer.</param>
        /// <param name="parameter">The parameter.</param>
        void PrintMessage(MessageType messageType, int parameter);

        /// <summary>
        /// Prints the leaderboard.
        /// </summary>
        /// <param name="leaderBoard">The leaderboard to be printed.</param>
        void PrintLeaderBoard(IList<PlayerScore> leaderBoard);

        /// <summary>
        /// Prints a helping number.
        /// </summary>
        /// <param name="helpingNumber">The helping number.</param>
        void PrintHelpingNumber(char[] helpingNumber);

        /// <summary>
        /// Prints a congratulation message for winning the game.
        /// </summary>
        /// <param name="cheatAttemptCounter">The number of times the played used "help" command.</param>
        /// <param name="guessAttemptCounter">The number of guesses it took the player to win the game.</param>
        void PrintCongratulationMessage(int cheatAttemptCounter, int guessAttemptCounter);
    }
}
