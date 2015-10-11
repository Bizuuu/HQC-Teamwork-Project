namespace BullsAndCows.CommandProcessors
{
    using System;
    using Common;
    using Contracts;

    /// <summary>
    /// Used for handling a number command.
    /// </summary>
    internal class NumberCommandProcessor : CommandProcessor, ICommandProcessor
    {
        /// <summary>
        /// Gets or sets the BullsAndCowsCounter responsible for calculating the score.
        /// </summary>
        private BullsAndCowsCounter BullsAndCowsCounter { get; set; }

        /// <summary>
        /// Gets or sets the BullsAndCowsResult which is responsible for holding the score of the current guess.
        /// </summary>
        private BullsAndCowsResult BullsAndCowsResult { get; set; }

        /// <summary>
        /// Checks if the number is guessed correctly, if it's of valid length and calculates the results.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="game">The game used to access the printer and other needed properties.</param>
        public override void ProcessCommand(string command, BullsAndCowsGame game)
        {
            if (BullsAndCowsCounter == null)
            {
                BullsAndCowsCounter = new BullsAndCowsCounter(game.NumberForGuess);
            }

            int commandAsNumber;

            if (int.TryParse(command, out commandAsNumber))
            {
                if (command.Length != game.NumberForGuess.Length)
                {
                    game.Printer.PrintMessage(MessageType.InvalidNumberLength);
                    return;
                }

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

        /// <summary>
        /// Checks whether the number is guessed correctly.
        /// </summary>
        /// <param name="command">The number to be checked.</param>
        /// <param name="game">The game used to retrieve the NumberToGuess.</param>
        /// <returns>True or false whether the number is guessed.</returns>
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
