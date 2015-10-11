namespace BullsAndCows.Messages
{
    using Contracts;

    /// <summary>
    /// Abstract Message.
    /// </summary>
    public abstract class Message : IMessage
    {
        /// <summary>
        /// Gets string.
        /// </summary>
        protected string Text { get; set; }

        /// <summary>
        /// Shows Message
        /// </summary>
        /// <returns>String value.</returns>
        public abstract string Show();
    }
}
