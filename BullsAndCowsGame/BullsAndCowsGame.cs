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
            if (playerName == null)
            {
                Printer.PrintMessage(MessageType.EnterName);
                playerName = Console.ReadLine();
            }

            Printer.PrintMessage(MessageType.Welcome);
            Printer.PrintMessage(MessageType.GameRules);

            string input;

            while (!this.IsGuessed)
            {
                Printer.PrintMessage(MessageType.Command);
                input = Console.ReadLine();
                this.GuessAttemptCounter++;
                CommandProcessor.ProcessCommand(input, this);
            }

            ScoreBoard.AddPlayerScore(new PlayerScore(playerName, this.GuessAttemptCounter));
            Printer.PrintLeaderBoard(ScoreBoard.LeaderBoard);

            Console.ReadLine();
        }

        public void Initialize()
        {
            this.NumberForGuess = RandomNumberProvider.GenerateNumber(1000, 9999).ToString();
            this.GuessAttemptCounter = 0;
            this.CheatAttemptCounter = 0;
            this.IsGuessed = false;
            helpingNumber = new char[] { 'X', 'X', 'X', 'X' };
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

        public void RevealDigit()
        {
            bool flag = false;
            int c = 0;
            while (!flag &&
                   c != 2 * this.NumberForGuess.Length)
            {
                int digitForReveal = RandomNumberProvider.GenerateNumber(0, 4);

                if (helpingNumber[digitForReveal] == 'X')
                {
                    helpingNumber[digitForReveal] =
                    this.NumberForGuess[digitForReveal];
                    flag = true;
                }

                c++;
            }

            Printer.PrintHelpingNumber(helpingNumber);
        }

        public void Dispose()
        {
            Initialize();
        }
    }
}
