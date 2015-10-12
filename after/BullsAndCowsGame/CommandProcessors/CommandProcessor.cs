// <summary>Contains the abstract CommandProcessor class.</summary>
//-----------------------------------------------------------------------
// <copyright file="CommandProcessor.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.CommandProcessors
{
    using Contracts;

    /// <summary>
    /// Abstract class implementing the chain of responsibility design pattern. Used for handling different commands.
    /// </summary>
    internal abstract class CommandProcessor : ICommandProcessor
    {
        /// <summary>
        /// Gets or sets the next Successor in the chain of responsibility.
        /// </summary>
        protected ICommandProcessor Successor { get; set; }

        /// <summary>
        /// Used to set the next successor in the chain.
        /// </summary>
        /// <param name="successor">The next successor to be set.</param>
        public void SetSuccessor(ICommandProcessor successor)
        {
            this.Successor = successor;
        }

        /// <summary>
        /// Abstract method overridden by the different CommandProcessors which defines how to process the command.
        /// </summary>
        /// <param name="command">The command which has to be processed.</param>
        /// <param name="game">The game from which the command comes. Used for gathering other vital info and using the printer.</param>
        public abstract void ProcessCommand(string command, BullsAndCowsGame game);
    }
}
