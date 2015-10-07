using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    class ParametersMessage:Message
    {
        private int bullsCount;
        private int cowsCount;
        private int attemptsNumber;
        private int cheatsNumber;

        public ParametersMessage(int item, int secondItem)
        {
            this.BullsCount = item;
            this.CowsCount = secondItem;
            this.AttemptsNumber = item;
            this.CheatsNumber = secondItem;
        }

        public ParametersMessage(int attemptsNumber)
        {
            this.AttemptsNumber = attemptsNumber;
        }

       
        // TODO : VALIDATION
        public int CheatsNumber { get; private set; }

        public int AttemptsNumber
        {
            get
            {
                return this.attemptsNumber;
            }
            private set
            {
                this.attemptsNumber = value;
            }
        }

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

        public string WrongNumber
        {
            get
            {
                return string.Format("Wrong number! Bulls: {0}, Cows: {1}!", this.BullsCount, this.CowsCount);
            }
        }

        

        public string CheatCongratulations
        {
            get
            {
                return string.Format("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.",this.AttemptsNumber,this.CheatsNumber);
            }
        }

    }
}
