namespace BullsAndCows
{
    using BullsAndCows.Contracts;
    using System;

    public class Printer : IPrinter
    {
        public Printer()
        {
        }


        public string WelcomeMessage
        {
            get
            {
                return "Welcome to “Bulls and Cows” game.";
            }
        }

        public string GameRulesMessage
        {
            get
            {
                return @"Please try to guess my secret 4-digit number. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
            }
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
