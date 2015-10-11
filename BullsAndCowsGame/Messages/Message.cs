namespace BullsAndCows.Messages
{
    using Contracts;

    /// <summary>
    /// Abstract Message.
    /// </summary>
    public abstract class Message : IMessage
    {
        /// <summary>
        /// Gets or sets string.
        /// </summary>
        /// <value>String value.</value>
        protected string Text { get; set; }

        /// <summary>
        /// Shows Message.
        /// </summary>
        /// <returns>String value.</returns>
        public abstract string Show();
    }
}
