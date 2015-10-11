namespace BullsAndCows
{
    using System;
    using BullsAndCows.Common;
    using Contracts;

    public class BullsAndCowsGame : IDisposable
    {
        private int guessAttemptCounter;
        private bool isGuessed;
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

            while (!this.isGuessed)
            {
                this.Printer.PrintMessage(MessageType.Command);
                input = Console.ReadLine();

                this.CommandProcessor.ProcessCommand(input, this);
            }

            ScoreBoard.AddPlayerScore(new PlayerScore(this.playerName, this.guessAttemptCounter));
            this.Printer.PrintLeaderBoard(ScoreBoard.LeaderBoard);
        }

        public void Initialize()
        {
            this.NumberForGuess = this.RandomNumberProvider.GenerateNumber(1000, 9999).ToString();
            this.guessAttemptCounter = 0;
            this.CheatAttemptCounter = 0;
            this.isGuessed = false;
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

        //private bool IsValidNumber(string input)
        //{
        //    if (input.Length != GuessNumberLength)
        //    {
        //        return false;
        //    }

        //    for (int i = 0; i < GuessNumberLength; i++)
        //    {
        //        if (!char.IsDigit(input[i]))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        private bool IsEqualToNumberForGuess(string tryNumber)
        {
            if (tryNumber == this.NumberForGuess)
            {
                return true;
            }

            return false;
        }
    }
}
