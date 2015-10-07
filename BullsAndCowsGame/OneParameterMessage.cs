using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class OneParameterMessage:Message
    {
        public string Argument { get; set; }

        public string Congratulations
        {
            get
            {
                return string.Format("Congratulations! You guessed the secret number in {0} attempts.", this.Argument);
            }
        }
    }
}
