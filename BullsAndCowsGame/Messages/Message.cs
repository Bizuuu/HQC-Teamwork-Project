namespace BullsAndCows.Messages
{
    using BullsAndCows.Contracts;

    public abstract class Message : IMessage
    {
        protected string Text { get; set; }

        public abstract string Show();
    }
}
