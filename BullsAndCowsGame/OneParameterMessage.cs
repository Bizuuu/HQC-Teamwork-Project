using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public class OneParameterMessage:Message
    {
        public OneParameterMessage(string message,int parameter)
        {
            this.Parameter = parameter;
            this.Message = message;
        }

        public int Parameter { get; private set; }

        public string Message { get; private set; }

        public string ParameterMessage
        {
            get
            {
                return string.Format(this.Message, this.Parameter);
            }
        }
    }
}
