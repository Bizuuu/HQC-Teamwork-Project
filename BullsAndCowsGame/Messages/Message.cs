namespace BullsAndCows.Messages
{
    public abstract class Message
    {
        protected string Text { get; set; }

        public abstract string Show();
    }
}
