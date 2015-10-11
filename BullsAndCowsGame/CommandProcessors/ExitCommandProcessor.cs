namespace BullsAndCows.CommandProcessors
{
    using System;
    using Contracts;
    using Common;

    internal class ExitCommandProcessor : CommandProcessor, ICommandProcessor
    {
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
