namespace BullsAndCows
{
    using CommandProcessors;
    using Contracts;

    public class BullsAndCowsArcade
    {
        private const int MaxPlayersInScoreboard = 5;
        public BullsAndCowsArcade() {}

        public void StartGame()
        {
            Initialize();
        }

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
