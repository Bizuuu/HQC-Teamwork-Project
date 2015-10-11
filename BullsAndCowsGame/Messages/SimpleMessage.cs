// <summary>Contains the SimpleMessage class.</summary>
namespace BullsAndCows.Messages
{
    using Contracts;

    /// <summary>
    /// Message class that takes no parameters.
    /// </summary>
    public class SimpleMessage : Message, IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMessage" /> class.
        /// </summary>
        /// <param name="text">String value.</param>
        public SimpleMessage(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Shows the Message.
        /// </summary>
        /// <returns>String value.</returns>
        public override string Show()
        {
            return this.Text;
        }
    }
}
