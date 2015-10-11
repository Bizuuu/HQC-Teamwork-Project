// <summary>Contains the TopCommandProcessor class.</summary>
namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    /// <summary>
    /// Handles the top command.
    /// </summary>
    internal class TopCommandProcessor : CommandProcessor, ICommandProcessor
    {
        /// <summary>
        /// Tells the printer to print the scoreboard.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="game">The game which is used to access the printer.</param>
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (command == "top")
            {
                game.Printer.PrintLeaderBoard(game.ScoreBoard.LeaderBoard);
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessCommand(command, game);
            }
            else
            {
                throw new ArgumentNullException("There is no successor for TopCommandProcessor.");
            }
        }
    }
}
