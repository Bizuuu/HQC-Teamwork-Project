namespace BullsAndCows
{
    using System;
    using BullsAndCows.Common;

    public class Cows_buls
    {
        private const byte GuessNumberLength = 4;
        private const byte AllDigitsCount = 10;
        private static int maxPlayersInScoreBoard = 5;
        private static ScoreBoard scoreBoard = new ScoreBoard(maxPlayersInScoreBoard);
        private static Printer printer = new Printer();
        private static int cheatAttemptCounter;
        private static int guessAttemptCounter;
        private static string guessNumberToString;
        private static bool isGuessed;
        private static char[] helpingNumber;
        private static Random randomGenerator;
        private static string name;

        public static void Play()
        {
            if (name == null)
            {
                printer.Print(MessageType.EnterName);
                name = Console.ReadLine();
            }

            printer.Print(MessageType.Welcome);
            printer.Print(MessageType.GameRules);

            Initialize();
            GenerateNumberForGuess();

            string input;

            while (!isGuessed)
            {
                printer.Print(MessageType.Command);
                input = Console.ReadLine();

                if (IsValidNumber(input))
                {
                    ProcessDigitCommand(input);
                }
                else
                {
                    ProcessTextCommand(input);
                }
            }

            scoreBoard.AddPlayerScore(new PlayerScore(name, guessAttemptCounter));
            printer.PrintLeaderBoard(scoreBoard.LeaderBoard);
            CreateNewGame();
        }

        private static void Initialize()
        {
            randomGenerator = new Random();
            guessAttemptCounter = 0;
            cheatAttemptCounter = 0;
            isGuessed = false;
            helpingNumber = new char[] { 'X', 'X', 'X', 'X' };
        }

        private static void GenerateNumberForGuess()
        {
            int guessNumber = randomGenerator.Next(1000, 10000);
            guessNumberToString = guessNumber.ToString();
        }

        private static bool IsValidNumber(string input)
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

        private static void ProcessDigitCommand(string numberAsString)
        {
            guessAttemptCounter++;

            if (IsEqualToNumberForGuess(numberAsString))
            {
                isGuessed = true;
                
                printer.PrintCongratulationMessage(cheatAttemptCounter, guessAttemptCounter);
            }
            else
            {
                PrintBullsAndCows(numberAsString);
            }
        }

        private static void PrintBullsAndCows(string tryNumberString)
        {
            int bullsCount = 0;
            int cowsCount = 0;
            var printer = new Printer();

            CountBullsAndCows(tryNumberString, ref bullsCount, ref cowsCount);

            printer.Print(MessageType.WrongNumber, bullsCount, cowsCount);
        }

        private static void CountBullsAndCows(string tryNumberString, ref int bullsCount, ref int cowsCount)
        {
            bool[] bulls = new bool[GuessNumberLength];
            bool[] cows = new bool[AllDigitsCount];
            bullsCount = CountBulls(tryNumberString, bullsCount, bulls);
            cowsCount = CountCows(tryNumberString, cowsCount, bulls, cows);
        }

        private static int CountCows(string tryNumberString, int cowsCount, bool[] bulls, bool[] cows)
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

        private static int CountBulls(string tryNumberString, int bullsCount, bool[] bulls)
        {
            for (int i = 0; i < GuessNumberLength; i++)
            {
                if (tryNumberString[i] == guessNumberToString[i])
                {
                    bulls[i] = true;
                    bullsCount++;
                }
            }

            return bullsCount;
        }

        private static int CountCowsForCurrentDigit(string tryNumberString, int cowsCount, bool[] bulls, int i)
        {
            for (int j = 0; j < tryNumberString.Length; j++)
            {
                if (tryNumberString[i] == guessNumberToString[j])
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

        private static bool IsEqualToNumberForGuess(string tryNumber)
        {
            if (tryNumber == guessNumberToString)
            {
                return true;
            }

            return false;
        }

        private static void ProcessTextCommand(string command)
        {
            switch (command.ToLower())
            {
                case "top":
                    printer.PrintLeaderBoard(scoreBoard.LeaderBoard);
                    break;
                case "help":
                    RevealDigit();
                    cheatAttemptCounter++;
                    break;
                case "restart":
                    CreateNewGame();
                    return;
                case "exit":
                    printer.Print(MessageType.Exit);
                    Environment.Exit(1);
                    break;
                default:
                    printer.Print(MessageType.InvalidCommand);
                    break;
            }
        }

        private static void RevealDigit()
        {
            bool flag = false;
            int c = 0;
            while (!flag &&
                   c != 2 * guessNumberToString.Length)
            {
                int digitForReveal = randomGenerator.Next(0, 4);

                if (helpingNumber[digitForReveal] == 'X')
                {
                    helpingNumber[digitForReveal] =
                    guessNumberToString[digitForReveal];
                    flag = true;
                }

                c++;
            }

            printer.PrintHelpingNumber(helpingNumber);
        }

        private static void CreateNewGame()
        {
            Play();
        }
    }
}
