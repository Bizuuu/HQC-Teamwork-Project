using System;
using System.Collections.Generic;
using System.Text;

    public class Cows_buls
    {
        private const byte GuessNumberLength = 4;
        private const byte AllDigitsCount = 10;
        private static List<PlayerInfo> leaderBoard = new List<PlayerInfo>();
        private static int cheatAttemptCounter;
        private static int guessAttemptCounter;
        private static string guessNumberToString;
        private static bool isGuessed;
        private static char[] helpingNumber;
        private static Random randomGenerator;

        public static void Play()
        {
            Console.WriteLine(
                "Welcome to “Bulls and Cows” game." +
                "Please try to guess my secret 4-digit number." +
                "Use 'top' to view the top scoreboard, 'restart'" +
                "to start a new game and 'help'" +
                " to cheat and 'exit' to quit the game.");

            Initialize();
            GenerateNumberForGuess();

            string input;

            while (!isGuessed)
            {
                Console.Write("Enter your guess or command: ");
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

            AddPlayerToScoreboard(guessAttemptCounter);
            PrintScoreboard();
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
                PrintCongratulationMessage();
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
            CountBullsAndCows(tryNumberString, ref bullsCount, ref cowsCount);
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}!", bullsCount, cowsCount);
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

        private static void PrintCongratulationMessage()
        {
            if (cheatAttemptCounter == 0)
            {
                Console.WriteLine(
                    "Congratulations! You guessed" +
                    " the secret number in {0} attempts.",
                    guessAttemptCounter);
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the" + " secret number in {0}" + " attempts and {1} cheats.", guessAttemptCounter, cheatAttemptCounter);
            }

            Console.WriteLine();
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
                    PrintScoreboard();
                    break;
                case "help":
                    RevealDigit();
                    cheatAttemptCounter++;
                    break;
                case "restart":
                    CreateNewGame();
                    return;
                case "exit":
                    Console.WriteLine("Good bye!");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid command!");
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

            PrintHelpingNumber();
        }

        private static void PrintHelpingNumber()
        {
            Console.Write("The number looks like ");

            foreach (char ch in helpingNumber)
            {
                Console.Write(ch);
            }

            Console.Write(".");
            Console.WriteLine();
        }

        private static void CreateNewGame()
        {
            Play();
        }

        private static void AddPlayerToScoreboard(int guesses)
        {
            if (cheatAttemptCounter > 0)
            {
                Console.WriteLine(
                    "You are not allowed to enter the top scoreboard.");
            }
            else
            {
                if (leaderBoard.Count < 5)
                {
                    AddPlayer(guesses);
                }
                else if (leaderBoard[4].Guesses > guesses)
                {
                    leaderBoard.RemoveAt(4);
                    AddPlayer(guesses);
                }
            }
        }

        private static void AddPlayer(int guesses)
        {
            Console.WriteLine("You can add your nickname to top scores!");
            string playerNick = string.Empty;
            while (playerNick == string.Empty)
            {
                try
                {
                    Console.Write("Enter your nickname: ");
                    playerNick = Console.ReadLine();
                    PlayerInfo newPlayer = new PlayerInfo(playerNick, guesses);
                    leaderBoard.Add(newPlayer);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        private static void PrintScoreboard()
        {
            Console.WriteLine();
            if (leaderBoard.Count > 0)
            {
                Console.WriteLine("Scoreboard:");
                leaderBoard.Sort();
                int currentPosition = 1;
                Console.WriteLine("  {0,7} | {1}", "Guesses", "Name");
                PrintLine(40);

                foreach (var currentPlayerInfo in leaderBoard)
                {
                    Console.WriteLine("{0}| {1}", currentPosition, currentPlayerInfo);
                    PrintLine(40);
                    currentPosition++;
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Scoreboard is empty!");
            }
        }

        private static void PrintLine(int dashesForPrint)
        {
            for (int i = 0; i < dashesForPrint; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
