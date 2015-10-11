// <summary>Contains the IRandomNumberGenerator interface.</summary>
namespace BullsAndCows.Contracts
{
    /// <summary>
    /// Holds the needed method for a randomNumberProvider.
    /// </summary>
    public interface IRandomNumberProvider
    {
        /// <summary>
        /// Generates a random number between two other numbers.
        /// </summary>
        /// <param name="from">The minimal number to be generated.</param>
        /// <param name="to">The maximal number to be generated.</param>
        /// <returns>A random integer number in the range.</returns>
        int GenerateNumber(int from, int to);
    }
}
