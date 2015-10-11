namespace BullsAndCows.Contracts
{
    /// <summary>
    /// Defines the methods a message should have.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// A method used to show the message.
        /// </summary>
        /// <returns>Returns the message as a string.</returns>
        string Show();
    }
}
