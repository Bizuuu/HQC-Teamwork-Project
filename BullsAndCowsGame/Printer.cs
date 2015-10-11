namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Common;
    using BullsAndCows.Contracts;
    
    public class Printer : IPrinter
    {
        public Printer()
        {
            this.MessageFactory = new MessageFactory();
        }

        public MessageFactory MessageFactory { get; private set; }

        public void Print(MessageType messageType, int parameter = 0, int secondParameter = 0)
        {
            Console.WriteLine(this.MessageFactory.MakeMessage(messageType, parameter, secondParameter));
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
                this.Print(MessageType.Congratulation, guessAttemptCounter);
            }
            else
            {
                this.Print(MessageType.CheatCongratulation, guessAttemptCounter, cheatAttemptCounter);
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
