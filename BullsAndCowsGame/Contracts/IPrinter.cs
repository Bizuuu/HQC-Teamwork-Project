namespace BullsAndCows.Contracts
{
    using BullsAndCows.Common;

    public interface IPrinter
    {
        void Print(MessageType message, int item, int secondItem);
    }
}
