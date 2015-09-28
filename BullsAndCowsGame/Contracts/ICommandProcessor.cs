namespace BullsAndCows.CommandProcessors
{
    internal interface ICommandProcessor
    {
        void SetSuccessor(ICommandProcessor successor);

        void ProcessCommand(string command);
    }
}
