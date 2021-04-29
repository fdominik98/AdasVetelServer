using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.messages
{
    public class MessageBase
    {
        public string Type { get; set; }
        public MessageBase(string type)
        {
            Type = type;            
        }
    }
}
