namespace BullsAndCows.Contracts
{
    using System.Collections.Generic;
    using Common;

    public interface IPrinter
    {
        void PrintMessage(MessageType messageTime, int parametere, int secondParameter);

        void PrintMessage(MessageType messageType);

        void PrintMessage(MessageType messageType, int parameter);

        void PrintLeaderBoard(IList<PlayerScore> leaderBoard);

        void PrintHelpingNumber(char[] helpingNumber);

        void PrintCongratulationMessage(int cheatAttemptCounter, int guessAttemptCounter);
    }
}
