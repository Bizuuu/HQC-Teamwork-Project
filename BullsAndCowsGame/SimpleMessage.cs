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

        public string Text { get; set; }

        public override string Show()
        {
           return this.Text;
        }
    }
}
