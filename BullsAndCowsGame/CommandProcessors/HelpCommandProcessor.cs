namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    internal class HelpCommandProcessor : CommandProcessor, ICommandProcessor
    {
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (command == "help")
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
                throw new ArgumentNullException("There is no successor for HelpCommandProcessor.");
            }
        }
    }
}
