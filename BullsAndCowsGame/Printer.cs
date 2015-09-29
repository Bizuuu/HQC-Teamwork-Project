namespace BullsAndCows
{
    using BullsAndCows.Common;
    using BullsAndCows.Contracts;
    using System;

    public class Printer : IPrinter
    {
        public void Print(MessageType message, int item = 0, int secondItem = 0)
        {
            switch (message)
            {
                case MessageType.Welcome:
                    Console.WriteLine(new Message().Welcome);
                    break;
                case MessageType.GameRules:
                    Console.WriteLine(new Message().GameRules);
                    break;
                case MessageType.Command:
                    Console.WriteLine(new Message().Command);
                    break;
                case MessageType.WrongNumber:
                    Console.WriteLine(new ParametersMessage(item,secondItem).WrongNumber);
                    break;
                case MessageType.Congratulation:
                    Console.WriteLine(new ParametersMessage(item).Congratulations);
                    break;
                case MessageType.CheatCongratulation:
                    Console.WriteLine(new ParametersMessage(item,secondItem).CheatCongratulations);
                    break;
                default:
                    throw new ArgumentNullException("No message type.");
            }
        }
    }
}
