namespace BullsAndCows
{
    using System;
    using BullsAndCows.Common;
    using Contracts;

    public class BullsAndCowsGame
    {
        private const byte GuessNumberLength = 4;
        private const byte AllDigitsCount = 10;
        private int cheatAttemptCounter;
        private int guessAttemptCounter;
        private string guessNumberAsString;
        private bool isGuessed;
        private char[] helpingNumber;
        private string name;

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

        public void Play()
        {
            if (name == null)
            {
                Printer.PrintMessage(MessageType.EnterName);
                name = Console.ReadLine();
            }

            Printer.PrintMessage(MessageType.Welcome);
            Printer.PrintMessage(MessageType.GameRules);

            string input;

            while (!isGuessed)
            {
                Printer.PrintMessage(MessageType.Command);
                input = Console.ReadLine();

                CommandProcessor.ProcessCommand(input);
            }

            ScoreBoard.AddPlayerScore(new PlayerScore(name, guessAttemptCounter));
            Printer.PrintLeaderBoard(ScoreBoard.LeaderBoard);
            CreateNewGame();
        }

        public void Initialize()
        {
            guessNumberAsString = RandomNumberProvider.GenerateNumber(1000, 9999).ToString();
            guessAttemptCounter = 0;
            cheatAttemptCounter = 0;
            isGuessed = false;
            helpingNumber = new char[] { 'X', 'X', 'X', 'X' };
        }

        private bool IsValidNumber(string input)
        {
            if (input.Length != GuessNumberLength)
            {
                return false;
            }

            for (int i = 0; i < GuessNumberLength; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private void ProcessDigitCommand(string numberAsString)
        {
            guessAttemptCounter++;

            if (IsEqualToNumberForGuess(numberAsString))
            {
                isGuessed = true;

                Printer.PrintCongratulationMessage(cheatAttemptCounter, guessAttemptCounter);
            }
            else
            {
                PrintBullsAndCows(numberAsString);
            }
        }

        private void PrintBullsAndCows(string tryNumberString)
        {
            int bullsCount = 0;
            int cowsCount = 0;

            CountBullsAndCows(tryNumberString, ref bullsCount, ref cowsCount);

            Printer.PrintMessage(MessageType.WrongNumber, bullsCount, cowsCount);
        }

        private void CountBullsAndCows(string tryNumberString, ref int bullsCount, ref int cowsCount)
        {
            bool[] bulls = new bool[GuessNumberLength];
            bool[] cows = new bool[AllDigitsCount];
            bullsCount = CountBulls(tryNumberString, bullsCount, bulls);
            cowsCount = CountCows(tryNumberString, cowsCount, bulls, cows);
        }

        private int CountCows(string tryNumberString, int cowsCount, bool[] bulls, bool[] cows)
        {
            for (int i = 0; i < GuessNumberLength; i++)
            {
                int digitForTry = int.Parse(tryNumberString[i].ToString());
                if (!bulls[i] && !cows[digitForTry])
                {
                    cows[digitForTry] = true;
                    cowsCount = CountCowsForCurrentDigit(tryNumberString, cowsCount, bulls, i);
                }
            }

            return cowsCount;
        }

        private int CountBulls(string tryNumberString, int bullsCount, bool[] bulls)
        {
            for (int i = 0; i < GuessNumberLength; i++)
            {
                if (tryNumberString[i] == guessNumberAsString[i])
                {
                    bulls[i] = true;
                    bullsCount++;
                }
            }

            return bullsCount;
        }

        private int CountCowsForCurrentDigit(string tryNumberString, int cowsCount, bool[] bulls, int i)
        {
            for (int j = 0; j < tryNumberString.Length; j++)
            {
                if (tryNumberString[i] == guessNumberAsString[j])
                {
                    if (!bulls[j])
                    {
                        cowsCount++;
                        break;
                    }
                }
            }

            return cowsCount;
        }

        private bool IsEqualToNumberForGuess(string tryNumber)
        {
            if (tryNumber == guessNumberAsString)
            {
                return true;
            }

            return false;
        }

        private void ProcessTextCommand(string command)
        {
            switch (command.ToLower())
            {
                case "top":
                    Printer.PrintLeaderBoard(ScoreBoard.LeaderBoard);
                    break;
                case "help":
                    RevealDigit();
                    cheatAttemptCounter++;
                    break;
                case "restart":
                    CreateNewGame();
                    return;
                case "exit":
                    Printer.PrintMessage(MessageType.Exit);
                    Environment.Exit(1);
                    break;
                default:
                    Printer.PrintMessage(MessageType.InvalidCommand);
                    break;
            }
        }

        private void RevealDigit()
        {
            bool flag = false;
            int c = 0;
            while (!flag &&
                   c != 2 * guessNumberAsString.Length)
            {
                int digitForReveal = RandomNumberProvider.GenerateNumber(0, 4);

                if (helpingNumber[digitForReveal] == 'X')
                {
                    helpingNumber[digitForReveal] =
                    guessNumberAsString[digitForReveal];
                    flag = true;
                }

                c++;
            }

            Printer.PrintHelpingNumber(helpingNumber);
        }

        private void CreateNewGame()
        {
            Play();
        }
    }
}
