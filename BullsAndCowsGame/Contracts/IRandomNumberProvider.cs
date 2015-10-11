namespace BullsAndCows.Contracts
{
    public interface IRandomNumberProvider
    {
        int GenerateNumber(int from, int to);
    }
}
