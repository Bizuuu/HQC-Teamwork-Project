namespace BullsAndCows.Messages
{
    using Contracts;

    public class TwoParameterMessage : Message, IMessage
    {
        public TwoParameterMessage(Message message, int parameter, int secondParameter)
        {
            this.Parameter = parameter;
            this.SecondParameter = secondParameter;
            this.Message = message;
        }

        public int Parameter { get; private set; }

        public int SecondParameter { get; private set; }

        public Message Message { get; private set; }

        public override string Show()
        {
            return string.Format(this.Message.Show(), this.Parameter, this.SecondParameter);
        }
    }
}
