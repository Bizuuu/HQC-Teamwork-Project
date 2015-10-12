// <summary>Contains the HelpCommandProcessor class.</summary>
//-----------------------------------------------------------------------
// <copyright file="HelpCommandProcessor.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    /// <summary>
    /// Processes the "help" command.
    /// </summary>
    internal class HelpCommandProcessor : CommandProcessor, ICommandProcessor
    {
        /// <summary>
        /// Help command.
        /// </summary>
        private const string HelpCommand = "help";

        /// <summary>
        /// No successor.
        /// </summary>
        private const string NullExceptionText = "There is no successor for HelpCommandProcessor.";

        /// <summary>
        /// Calls the RevealDigit method on the game or passes to the next Successor.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="game">The game on which the RevealDigit method is called.</param>
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (command == HelpCommand)
            {
                game.RevealDigit();
                game.CheatAttemptCounter++;
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessCommand(command, game);
            }
            else
            {
                throw new ArgumentNullException(NullExceptionText);
            }
        }
    }
}
