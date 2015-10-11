namespace BullsAndCows.Messages
{
    using System;
    using Common;

    public class MessageFactory
    {
        public string MakeMessage(MessageType message, int parameter = 0, int secondParameter = 0)
        {
            switch (message)
            {
                case MessageType.Welcome:
                    return new SimpleMessage("Welcome to “Bulls and Cows” game.").Show();
                case MessageType.GameRules:
                    return new SimpleMessage("Please try to guess my secret 4-digit number. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.").Show();
                case MessageType.Command:
                    return new SimpleMessage("Enter your guess or command: ").Show();
                case MessageType.WrongNumber:
                    return new TwoParameterMessage(new SimpleMessage("Wrong number! Bulls: {0}, Cows: {1}!"), parameter, secondParameter).Show();
                case MessageType.Congratulation:
                    return new OneParameterMessage(new SimpleMessage("Congratulations! You guessed the secret number in {0} attempts."), parameter).Show();
                case MessageType.CheatCongratulation:
                    return new TwoParameterMessage(new SimpleMessage("Congratulations! You guessed the secret number in {0} attempts and {1} cheats."), parameter, secondParameter).Show();
                case MessageType.EnterName:
                    return new SimpleMessage("Please enter your name: ").Show();
                case MessageType.Exit:
                    return new SimpleMessage("Good bye!").Show();
                case MessageType.InvalidCommand:
                    return new SimpleMessage("Invalid command!").Show();
                case MessageType.InvalidNumberLength:
                    return new SimpleMessage("Number is too long or too short - must be 4 digits!").Show();
                default:
                    throw new ArgumentNullException("No message type.");
            }
        }
    }
}
