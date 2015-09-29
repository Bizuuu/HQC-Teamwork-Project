using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class Message
    {
        private int bullsCount;
        private int cowsCount;

        public Message()
        {

        }

        public Message(int bullsCount, int cowsCount)
        {
            this.BullsCount = bullsCount;
            this.CowsCount = cowsCount;
        }

        public string Welcome
        {
            get
            {
                return "Welcome to “Bulls and Cows” game.";
            }
        }

        public string GameRules
        {
            get
            {
                return "Please try to guess my secret 4-digit number. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
            }
        }

        public string Command
        {
            get
            {
                return "Enter your guess or command: ";
            }
        }

        public string WrongNumber
        {
            get
            {
                return string.Format("Wrong number! Bulls: {0}, Cows: {1}!", this.BullsCount, this.CowsCount);
            }
        }
        // TODO : VALIDATION
        public int BullsCount
        {
            get
            {
                return this.bullsCount;
            }
            set
            {
                this.bullsCount = value;
            }
        }

        public int CowsCount
        {
            get
            {
                return this.cowsCount;
            }
            set
            {
                this.cowsCount = value;
            }
        }
    }
}
