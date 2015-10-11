// <summary>Contains the TwoParameterMessage class.</summary>
//-----------------------------------------------------------------------
// <copyright file="TwoParameterMessage.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.Messages
{
    using Contracts;

    /// <summary>
    /// Message class that takes two parameters.
    /// </summary>
    public class TwoParameterMessage : Message, IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwoParameterMessage" /> class.
        /// </summary>
        /// <param name="message">Abstract Message.</param>
        /// <param name="parameter">Integer number, depends on purpose.</param>
        /// <param name="secondParameter">Second parameter integer, depends on purpose.</param>
        public TwoParameterMessage(Message message, int parameter, int secondParameter)
        {
            this.Parameter = parameter;
            this.SecondParameter = secondParameter;
            this.Message = message;
        }

        /// <summary>
        /// Gets integer number.
        /// </summary>
        /// <value>Integer number.</value>
        public int Parameter { get; private set; }

        /// <summary>
        /// Gets Second Integer.
        /// </summary>
        /// <value>Integer number.</value>
        public int SecondParameter { get; private set; }

        /// <summary>
        /// Gets Abstract Message.
        /// </summary>
        /// <value>Abstract Message.</value>
        public Message Message { get; private set; }

        /// <summary>
        /// Shows the message with parameters.
        /// </summary>
        /// <returns>String message.</returns>
        public override string Show()
        {
            return string.Format(this.Message.Show(), this.Parameter, this.SecondParameter);
        }
    }
}
