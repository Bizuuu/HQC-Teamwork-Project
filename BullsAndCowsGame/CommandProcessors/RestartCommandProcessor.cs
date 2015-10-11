namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    internal class RestartCommandProcessor : CommandProcessor, ICommandProcessor
    {
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (command == "restart")
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
                throw new ArgumentNullException("There is no successor for RestartCommandProcessor.");
            }
        }
    }
}
