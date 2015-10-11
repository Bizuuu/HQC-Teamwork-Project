// <summary>Contains the ExitCommandProcessor class.</summary>
//-----------------------------------------------------------------------
// <copyright file="ExitCommandProcessor.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    /// <summary>
    /// Class responsible for handling the "exit" command.
    /// </summary>
    internal class ExitCommandProcessor : CommandProcessor, ICommandProcessor
    {
        /// <summary>
        /// Decides whether it can process the command or passes it to the next Successor.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="game">Used to access the printer.</param>
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (command == "exit")
            {
                game.Printer.PrintMessage(MessageType.Exit);
                Environment.Exit(1);
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessCommand(command, game);
            }
            else
            {
                throw new ArgumentNullException("There is no successor for ExitCommandProcessor.");
            }
        }
    }
}
