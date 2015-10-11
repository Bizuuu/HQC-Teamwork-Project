namespace BullsAndCows.CommandProcessors
{
    using System;
    using Contracts;

    internal class NumberCommandProcessor : CommandProcessor, ICommandProcessor
    {
        public override void ProcessCommand(string command)
        {
            int commandAsNumber;

            if (int.TryParse(command, out commandAsNumber))
            {
                throw new NotImplementedException();
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessCommand(command);
            }
            else
            {
                throw new ArgumentNullException("There is no successor for NumberCommandProcessor.");
            }
        }
    }
}
