namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    internal class NumberCommandProcessor : CommandProcessor, ICommandProcessor
    {
        public NumberCommandProcessor()
            : base()
        {
        }

        private BullsAndCowsCounter BullsAndCowsCounter { get; set; }

        private BullsAndCowsResult BullsAndCowsResult { get; set; }

        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (BullsAndCowsCounter == null)
            {
                BullsAndCowsCounter = new BullsAndCowsCounter(game.NumberForGuess);
            }

            int commandAsNumber;

            if (int.TryParse(command, out commandAsNumber))
            {
                if (!this.IsGuessedCorrectly(command, game))
                {
                    BullsAndCowsCounter.Dispose();
                    this.BullsAndCowsResult = BullsAndCowsCounter.CountBullsAndCows(command);
                    game.Printer.PrintMessage(MessageType.WrongNumber, this.BullsAndCowsResult.Bulls, this.BullsAndCowsResult.Cows);
                }
                else
                {
                    game.Printer.PrintCongratulationMessage(game.CheatAttemptCounter, game.GuessAttemptCounter);
                    game.IsGuessed = true;
                }
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessCommand(command, game);
            }
            else
            {
                throw new ArgumentNullException("There is no successor for NumberCommandProcessor.");
            }
        }

        private bool IsGuessedCorrectly(string command, BullsAndCowsGame game) 
        {
            if (command == game.NumberForGuess)
            {
                return true;
            }

            return false;
        }
    }
}
