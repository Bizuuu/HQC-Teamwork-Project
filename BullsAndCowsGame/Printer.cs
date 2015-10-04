namespace BullsAndCows
{
    using BullsAndCows.Common;
    using BullsAndCows.Contracts;
    using System;
    using System.Collections.Generic;

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

        public void PrintLeaderBoard(IList<PlayerScore> leaderBoard)
        {
            Console.WriteLine();
            if (leaderBoard.Count > 0)
            {
                Console.WriteLine("Scoreboard:");
                int currentPosition = 1;
                Console.WriteLine("  {0,7} | {1}", "Guesses", "Name");
                DashedLine(40);

                foreach (var currentPlayerInfo in leaderBoard)
                {
                    Console.WriteLine("{0}| {1}", currentPosition, currentPlayerInfo);
                    DashedLine(40);
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
                Print(MessageType.Congratulation, guessAttemptCounter);
                //Console.WriteLine(
                //    "Congratulations! You guessed" +
                //    " the secret number in {0} attempts.",
                //    guessAttemptCounter);
            }
            else
            {
                Print(MessageType.CheatCongratulation, guessAttemptCounter, cheatAttemptCounter);
                //Console.WriteLine("Congratulations! You guessed the" + " secret number in {0}" + " attempts and {1} cheats.", guessAttemptCounter, cheatAttemptCounter);
            }

            Console.WriteLine();
        }

        private void DashedLine(int dashesForPrint)
        {
            for (int i = 0; i < dashesForPrint; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}
