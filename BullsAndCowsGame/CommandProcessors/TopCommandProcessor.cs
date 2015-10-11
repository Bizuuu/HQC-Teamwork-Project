namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    internal class TopCommandProcessor : CommandProcessor, ICommandProcessor
    {
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
