namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Common;
    using BullsAndCows.Contracts;
    
    public class Printer : IPrinter
    {
        public Printer(MessageFactory messageFactory)
        {
            this.MessageFactory = messageFactory;
        }

        public MessageFactory MessageFactory { get; private set; }

        public void PrintMessage(MessageType messageType, int parameter = 0, int secondParameter = 0)
        {
            var message = this.MessageFactory.MakeMessage(messageType, parameter, secondParameter);
            Console.WriteLine(message);
        }

        public void PrintMessage(MessageType messageType)
        {
            var message = this.MessageFactory.MakeMessage(messageType);
            Console.WriteLine(message);
        }

        public void PrintMessage(MessageType messageType, int parameter) 
        {
            var message = this.MessageFactory.MakeMessage(messageType, parameter);
            Console.WriteLine(message);
        }

        public void PrintLeaderBoard(IList<PlayerScore> leaderBoard)
        {
            Console.WriteLine();
            if (leaderBoard.Count > 0)
            {
                Console.WriteLine("Scoreboard:");
                int currentPosition = 1;
                Console.WriteLine("  {0,7} | {1}", "Guesses", "Name");
                this.PrintDashedLine(40);

                foreach (var currentPlayerInfo in leaderBoard)
                {
                    Console.WriteLine("{0}| {1}", currentPosition, currentPlayerInfo);
                    this.PrintDashedLine(40);
                    currentPosition++;
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Scoreboard is empty!");
            }
        }

        public void PrintHelpingNumber(char[] helpingNumber)
        {
            Console.Write("The number looks like ");

            foreach (char ch in helpingNumber)
            {
                Console.Write(ch);
            }

            Console.Write(".");
            Console.WriteLine();
        }

        public void PrintCongratulationMessage(int cheatAttemptCounter, int guessAttemptCounter)
        {
            if (cheatAttemptCounter == 0)
            {
                this.PrintMessage(MessageType.Congratulation, guessAttemptCounter);
            }
            else
            {
                this.PrintMessage(MessageType.CheatCongratulation, guessAttemptCounter, cheatAttemptCounter);
            }

            Console.WriteLine();
        }

        private void PrintDashedLine(int dashesForPrint)
        {
            for (int i = 0; i < dashesForPrint; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}
