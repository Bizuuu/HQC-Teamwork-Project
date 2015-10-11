// <summary>Contains the OneParameterMessage class.</summary>
namespace BullsAndCows.Messages
{
    using Contracts;

    /// <summary>
    /// One parameter message.
    /// </summary>
    public class OneParameterMessage : Message, IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneParameterMessage" /> class.
        /// </summary>
        /// <param name="message">Abstract Message.</param>
        /// <param name="parameter">Integer Number.</param>
        public OneParameterMessage(Message message, int parameter)
        {
            this.Parameter = parameter;
            this.Message = message;
        }

        /// <summary>
        /// Gets Integer parameter.
        /// </summary>
        /// <value>Integer number.</value>
        public int Parameter { get; private set; }

        /// <summary>
        /// Gets Message new.
        /// </summary>
        /// <value>Message abstract.</value>
        public Message Message { get; private set; }

        /// <summary>
        /// Shows message.
        /// </summary>
        /// <returns>String value.</returns>
        public override string Show()
        {
            return string.Format(this.Message.Show(), this.Parameter);
        }
    }
}
