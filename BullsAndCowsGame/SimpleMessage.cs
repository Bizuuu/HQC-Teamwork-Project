using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class SimpleMessage : Message
    {
        public SimpleMessage(string text)
        {
            this.Text = text;
        }

        public override string Text
        {
            get;
            set;
        }
    }
}
