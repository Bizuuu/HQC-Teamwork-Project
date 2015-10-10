using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class OneParameterMessage : Message
    {
        private Message message;

        public OneParameterMessage(Message message, int parameter)
        {
            this.Parameter = parameter;
            this.Message = message;
        }

        public int Parameter { get; private set; }

        public Message Message { get; private set; }

        public override string Show()
        {
            return string.Format(this.Message.Text,this.Parameter);
        }
    }
}
