namespace BullsAndCows.Messages
{
    public class SimpleMessage : Message
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
