// <summary>Contains the MessageType enumeration.</summary>
//-----------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.Common
{
    /// <summary>
    /// Holds the different types of messages that can be displayed.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Welcome message.
        /// </summary>
        Welcome,

        /// <summary>
        /// Game rules.
        /// </summary>
        GameRules,

        /// <summary>
        /// Command message.
        /// </summary>
        Command,

        /// <summary>
        /// Wrong number.
        /// </summary>
        WrongNumber,

        /// <summary>
        /// Congratulation message.
        /// </summary>
        Congratulation,

        /// <summary>
        /// Congratulation with cheats message.
        /// </summary>
        CheatCongratulation,

        /// <summary>
        /// Enter name.
        /// </summary>
        EnterName,

        /// <summary>
        /// Exit message.
        /// </summary>
        Exit,

        /// <summary>
        /// Invalid command.
        /// </summary>
        InvalidCommand,

        /// <summary>
        /// Invalid number length.
        /// </summary>
        InvalidNumberLength
    }
}
