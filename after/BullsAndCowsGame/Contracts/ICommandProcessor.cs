// <summary>Contains the ICommandProcessor interface.</summary>
//-----------------------------------------------------------------------
// <copyright file="ICommandProcessor.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.Contracts
{
    /// <summary>
    /// Holds the need properties and methods for a class to be CommandProcessor. Implements chain of responsibility.
    /// </summary>
    public interface ICommandProcessor
    {
        /// <summary>
        /// Gets or sets the next successor in case the current cannot process the command.
        /// </summary>
        /// <param name="successor">The successor to be set.</param>
        void SetSuccessor(ICommandProcessor successor);

        /// <summary>
        /// Used to process a command. Defines the rules for a command to be processed or passes the the next successor.
        /// </summary>
        /// <param name="command">The command to be processed.</param>
        /// <param name="game">The game used to retrieve needed information about the game.</param>
        void ProcessCommand(string command, BullsAndCowsGame game);
    }
}
