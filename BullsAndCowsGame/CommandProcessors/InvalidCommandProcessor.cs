namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    internal class InvalidCommandProcessor : CommandProcessor, ICommandProcessor
    {
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            game.Printer.PrintMessage(MessageType.InvalidCommand);
        }
    }
}
