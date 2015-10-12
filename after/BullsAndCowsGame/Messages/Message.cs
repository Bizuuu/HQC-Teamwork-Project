// <summary>Contains the abstract Message class.</summary>
//-----------------------------------------------------------------------
// <copyright file="Message.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.Messages
{
    using Contracts;

    /// <summary>
    /// Abstract Message.
    /// </summary>
    public abstract class Message : IMessage
    {
        /// <summary>
        /// Gets or sets the text of the message.
        /// </summary>
        /// <value>Holds the text of the message.</value>
        protected string Text { get; set; }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <returns>String value.</returns>
        public abstract string Show();
    }
}
