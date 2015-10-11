namespace BullsAndCows
{
    using CommandProcessors;
    using Contracts;
    using Messages;

    /// <summary>
    /// Class implementing the Facade design pattern used for creating all needed objects for the game and starting the game.
    /// </summary>
    public class BullsAndCowsArcade
    {
        /// <summary>
        /// A constant containing the amount of players which will be displayed in the leaderboard.
        /// </summary>
        private const int MaxPlayersInScoreboard = 5;

        /// <summary>
        /// Public method used by the user to start the process of starting the game.
        /// </summary>
        public void StartGame()
        {
            this.Initialize();
        }

        /// <summary>
        /// Creates the needed requirements for the game, initializes it and starts it.
        /// </summary>
        private void Initialize()
        {
            NumberCommandProcessor numberCommandProcessor = new NumberCommandProcessor();
            HelpCommandProcessor helpCommandProcessor = new HelpCommandProcessor();
            numberCommandProcessor.SetSuccessor(helpCommandProcessor);

            TopCommandProcessor topCommandProcessor = new TopCommandProcessor();
            helpCommandProcessor.SetSuccessor(topCommandProcessor);

            RestartCommandProcessor restartCommandProcessor = new RestartCommandProcessor();
            topCommandProcessor.SetSuccessor(restartCommandProcessor);

            ExitCommandProcessor exitCommandProcessor = new ExitCommandProcessor();
            restartCommandProcessor.SetSuccessor(exitCommandProcessor);

            InvalidCommandProcessor invalidCommandProcessor = new InvalidCommandProcessor();
            exitCommandProcessor.SetSuccessor(invalidCommandProcessor);

            ScoreBoard scoreBoard = new ScoreBoard(MaxPlayersInScoreboard);
            MessageFactory messageFactory = new MessageFactory();
            IPrinter printer = new Printer(messageFactory);
            IRandomNumberProvider randomNumberProvider = RandomNumberProvider.Instance;

            BullsAndCowsGame game = new BullsAndCowsGame(randomNumberProvider, scoreBoard, printer, numberCommandProcessor);

            game.Initialize();
            game.Play();
        }
    }
}
