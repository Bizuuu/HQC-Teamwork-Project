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
            if (playerName == null)
            {
                Printer.PrintMessage(MessageType.EnterName);
                playerName = Console.ReadLine();
            }

            Printer.PrintMessage(MessageType.Welcome);
            Printer.PrintMessage(MessageType.GameRules);

            string input;

            while (!isGuessed)
            {
                Printer.PrintMessage(MessageType.Command);
                input = Console.ReadLine();

                CommandProcessor.ProcessCommand(input, this);
            }

            ScoreBoard.AddPlayerScore(new PlayerScore(playerName, guessAttemptCounter));
            Printer.PrintLeaderBoard(ScoreBoard.LeaderBoard);
        
        }

        public void Initialize()
        {
            this.NumberForGuess = RandomNumberProvider.GenerateNumber(1000, 9999).ToString();
            guessAttemptCounter = 0;
            this.CheatAttemptCounter = 0;
            isGuessed = false;
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

        private bool IsEqualToNumberForGuess(string tryNumber)
        {
            if (tryNumber == this.NumberForGuess)
            {
                return true;
            }

            return false;
        }

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
