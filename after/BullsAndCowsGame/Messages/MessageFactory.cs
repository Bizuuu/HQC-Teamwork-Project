// <summary>Contains the MessageFactory class.</summary>
//-----------------------------------------------------------------------
// <copyright file="MessageFactory.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.Messages
{
    using System;
    using Common;

    /// <summary>
    /// Message factory class.
    /// </summary>
    public class MessageFactory
    {
        /// <summary>
        /// Welcome text.
        /// </summary>
        private const string WelcomeText = "Welcome to “Bulls and Cows” game.";

        /// <summary>
        /// Game rules text.
        /// </summary>
        private const string GameRulesText = "Please try to guess my secret 4-digit number. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        
        /// <summary>
        /// Command text.
        /// </summary>
        private const string CommandText = "Enter your guess or command: ";

        /// <summary>
        /// Wrong number text.
        /// </summary>
        private const string WrongNumberText = "Wrong number! Bulls: {0}, Cows: {1}!";

        /// <summary>
        /// Congratulation text.
        /// </summary>
        private const string CongratulationText = "Congratulations! You guessed the secret number in {0} attempts.";

        /// <summary>
        /// Cheat congratulation text.
        /// </summary>
        private const string CheatCongratulationText = "Congratulations! You guessed the secret number in {0} attempts and {1} cheats.";

        /// <summary>
        /// Enter name text.
        /// </summary>
        private const string EnterNameText = "Please enter your name: ";

        /// <summary>
        /// Exit text.
        /// </summary>
        private const string ExitText = "Good bye!";

        /// <summary>
        /// Invalid command text.
        /// </summary>
        private const string InvalidCommandText = "Invalid command!";

        /// <summary>
        /// Number length text.
        /// </summary>
        private const string InvalidNumberLengthText = "Number is too long or too short - must be 4 digits!";

        /// <summary>
        /// Null exception text.
        /// </summary>
        private const string NullExceptionText = "No message type.";

        /// <summary>
        /// Produces Message.
        /// </summary>
        /// <param name="message">Message type.</param>
        /// <param name="parameter">Integer number.</param>
        /// <param name="secondParameter">Second Number.</param>
        /// <returns>Returns new message.</returns>
        public string MakeMessage(MessageType message, int parameter = 0, int secondParameter = 0)
        {
            switch (message)
            {
                case MessageType.Welcome:
                    return new SimpleMessage(WelcomeText).Show();
                case MessageType.GameRules:
                    return new SimpleMessage(GameRulesText).Show();
                case MessageType.Command:
                    return new SimpleMessage(CommandText).Show();
                case MessageType.WrongNumber:
                    return new TwoParameterMessage(new SimpleMessage(WrongNumberText), parameter, secondParameter).Show();
                case MessageType.Congratulation:
                    return new OneParameterMessage(new SimpleMessage(CongratulationText), parameter).Show();
                case MessageType.CheatCongratulation:
                    return new TwoParameterMessage(new SimpleMessage(CheatCongratulationText), parameter, secondParameter).Show();
                case MessageType.EnterName:
                    return new SimpleMessage(EnterNameText).Show();
                case MessageType.Exit:
                    return new SimpleMessage(ExitText).Show();
                case MessageType.InvalidCommand:
                    return new SimpleMessage(InvalidCommandText).Show();
                case MessageType.InvalidNumberLength:
                    return new SimpleMessage(InvalidNumberLengthText).Show();
                default:
                    throw new ArgumentNullException(NullExceptionText);
            }
        }
    }
}
