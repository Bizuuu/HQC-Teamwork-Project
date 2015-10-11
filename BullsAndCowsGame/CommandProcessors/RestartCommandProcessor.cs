// <summary>Contains the RestartCommandProcessor class.</summary>
//-----------------------------------------------------------------------
// <copyright file="RestartCommandProcessor.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    /// <summary>
    /// Handles the restart command.
    /// </summary>
    internal class RestartCommandProcessor : CommandProcessor, ICommandProcessor
    {
        /// <summary>
        /// Restart command constant.
        /// </summary>
        private const string RestartCommand = "restart";

        /// <summary>
        /// Null Exception text.
        /// </summary>
        private const string NullExceptionText = "There is no successor for RestartCommandProcessor.";

        /// <summary>
        /// Disposes the game settings and starts a new game.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="game">The game, whose methods Dispose and Play are used.</param>
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (command == RestartCommand)
            {
                game.Dispose();
                game.Play();
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
