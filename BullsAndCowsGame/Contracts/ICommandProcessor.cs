namespace BullsAndCows.Contracts
{
    public interface ICommandProcessor
    {
        void SetSuccessor(ICommandProcessor successor);

        void ProcessCommand(string command);
    }
}
