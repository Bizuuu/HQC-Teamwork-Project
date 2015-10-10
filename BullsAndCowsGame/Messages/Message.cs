namespace BullsAndCows.Messages
{
    public abstract class Message
    {
        public string Text { get; private set; }

        public abstract string Show();
    }
}
