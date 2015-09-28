namespace BullsAndCows.CommandProcessors
{
    using System;

    internal class ExitCommandProcessor : CommandProcessor, ICommandProcessor
    {
        public override void ProcessCommand(string command)
        {
            if (command == "exit")
            {
                throw new NotImplementedException();
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessCommand(command);
            }
            else
            {
                throw new ArgumentNullException("There is no successor for ExitCommandProcessor.");
            }
        }
    }
}
