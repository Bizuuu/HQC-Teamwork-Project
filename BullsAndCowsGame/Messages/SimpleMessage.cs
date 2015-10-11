namespace BullsAndCows.Messages
{
    using BullsAndCows.Contracts;

    public class SimpleMessage : Message,IMessage
    {
        public SimpleMessage(string text)
        {
            this.Text = text;
        }

        public override string Show()
        {
           return this.Text;
        }
    }
}
