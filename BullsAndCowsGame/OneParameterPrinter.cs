using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    class OneParameterPrinter : Printer
    {
        public OneParameterPrinter(string argument)
        {
            this.Message.Argument = argument;
        }

        public string Argument { get; set; }

        public OneParameterMessage Message { get; set; }

        public override void Print()
        {
            Console.WriteLine(this.Message);
        }
    }
}
