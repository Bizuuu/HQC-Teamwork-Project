namespace BullsAndCows
{
    using System;
    using BullsAndCows.Common;
    using Contracts;

    public class BullsAndCowsGame : IDisposable
    {
        private char[] helpingNumber;
        private string playerName;

        public BullsAndCowsGame(
            IRandomNumberProvider randomNumberProvider,
            ScoreBoard scoreboard,
            IPrinter printer,
            ICommandProcessor commandProcessor)
        {
            this.RandomNumberProvider = randomNumberProvider;
            this.ScoreBoard = scoreboard;
            this.Printer = printer;
            this.CommandProcessor = commandProcessor;
        }

        public IRandomNumberProvider RandomNumberProvider { get; private set; }

        public ScoreBoard ScoreBoard { get; private set; }

        public IPrinter Printer { get; private set; }

        public ICommandProcessor CommandProcessor { get; private set; }

        public string NumberForGuess { get; private set; }

        public int CheatAttemptCounter { get; set; }

        public int GuessAttemptCounter { get; private set; }

        public bool IsGuessed { get; set; }

        public void Play()
        {
            if (this.playerName == null)
            {
                this.Printer.PrintMessage(MessageType.EnterName);
                this.playerName = Console.ReadLine();
            }

            this.Printer.PrintMessage(MessageType.Welcome);
            this.Printer.PrintMessage(MessageType.GameRules);

            string input;

            while (!this.IsGuessed)
            {
                this.Printer.PrintMessage(MessageType.Command);
                input = Console.ReadLine();
                this.GuessAttemptCounter++;

                this.CommandProcessor.ProcessCommand(input, this);
            }

            ScoreBoard.AddPlayerScore(new PlayerScore(this.playerName, this.GuessAttemptCounter));
            this.Printer.PrintLeaderBoard(ScoreBoard.LeaderBoard);

            Console.ReadLine();
        }

        public void Initialize()
        {
            this.NumberForGuess = this.RandomNumberProvider.GenerateNumber(1000, 9999).ToString();
            this.GuessAttemptCounter = 0;
            this.CheatAttemptCounter = 0;
            this.IsGuessed = false;
            this.helpingNumber = new char[] { 'X', 'X', 'X', 'X' };
        }

        public void RevealDigit()
        {
            bool flag = false;
            int c = 0;
            while (!flag &&
                   c != 2 * this.NumberForGuess.Length)
            {
                int digitForReveal = this.RandomNumberProvider.GenerateNumber(0, 4);

                if (this.helpingNumber[digitForReveal] == 'X')
                {
                    this.helpingNumber[digitForReveal] =
                    this.NumberForGuess[digitForReveal];
                    flag = true;
                }

                c++;
            }

            this.Printer.PrintHelpingNumber(this.helpingNumber);
        }

        public void Dispose()
        {
            this.Initialize();
        }

        // private bool IsValidNumber(string input)
        // {
        //     if (input.Length != GuessNumberLength)
        //     {
        //         return false;
        //     }
           
        //     for (int i = 0; i < GuessNumberLength; i++)
        //     {
        //         if (!char.IsDigit(input[i]))
        //         {
        //             return false;
        //         }
        //     }
           
        //     return true;
        // }
    }
}
