namespace BullsAndCows.Messages
{
    public class SimpleMessage : Message
    {
        public SimpleMessage(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }

        public override string Show()
        {
           return this.Text;
        }
    }
}
