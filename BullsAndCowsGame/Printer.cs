namespace BullsAndCows
{
    using BullsAndCows.Common;
    using BullsAndCows.Contracts;
    using System;

    public class Printer : IPrinter
    {
        public void Print(MessageType message)
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
                    Console.WriteLine(new Message().WrongNumber);
                    break;
                default:
                    throw new ArgumentNullException("No message type.");
            }
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintScoreBoard(ScoreBoard scoreBoard)
        {

        }
    }
}
