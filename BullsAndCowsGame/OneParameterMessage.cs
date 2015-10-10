using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class OneParameterMessage:Message
    {
        private Message message;

        public OneParameterMessage(Message message,int parameter)
        {
            this.Parameter = parameter;
            this.Message = message;
        }

        public override string Text
        {
            get; set;
        }

        public int Parameter { get; private set; }

        public Message Message {
            get
            {
                return this.message;
            }
             private set
            {
                this.message = value;
            }
        } 
    }
}
