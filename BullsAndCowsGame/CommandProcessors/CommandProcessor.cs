namespace BullsAndCows.CommandProcessors
{
    using Contracts;

    internal abstract class CommandProcessor : ICommandProcessor
    {
        protected ICommandProcessor Successor { get; set; }

        public void SetSuccessor(ICommandProcessor successor)
        {
            this.Successor = successor;
        }

        public abstract void ProcessCommand(string command);
    }
}
