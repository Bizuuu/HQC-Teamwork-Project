namespace BullsAndCows.Messages
{
    public class TwoParameterMessage : Message
    {
        private Message message;

        public TwoParameterMessage(Message message, int parameter, int secondParameter)
        {
            this.Parameter = parameter;
            this.SecondParameter = secondParameter;
            this.Message = message;
        }

        public int Parameter { get; private set; }

        public object SecondParameter { get; private set; }

        public Message Message { get; private set; }

        public override string Show()
        {
            return string.Format(this.Message.Show(), this.Parameter, this.SecondParameter);
        }
    }
}
