using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class OneParameterMessageFactory
    {
        public OneParameterMessage MakeCongratulation(int attempts)
        {
            var message = "Congratulations! You guessed the secret number in {0} attempts.";
            var congratulation = new OneParameterMessage(message, attempts);
            return congratulation;
        }
    }
}
