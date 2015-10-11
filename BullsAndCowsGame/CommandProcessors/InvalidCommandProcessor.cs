// <summary>Contains the InvalidCommandProcessor class.</summary>
namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    /// <summary>
    /// Handles when the given command is invalid and cannot be processed.
    /// </summary>
    internal class InvalidCommandProcessor : CommandProcessor, ICommandProcessor
    {
        /// <summary>
        /// Prints an invalid command message.
        /// </summary>
        /// <param name="command">The received invalid command.</param>
        /// <param name="game">The game used to access the printer.</param>
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            game.Printer.PrintMessage(MessageType.InvalidCommand);
        }
    }
}
