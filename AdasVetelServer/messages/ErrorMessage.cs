using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.messages
{
    class ErrorMessage : MessageBase
    {
        public string Message { get; set; }
        public ErrorMessage(string message) : base("Error")
        {
            Message = message;
        }
    }
}
