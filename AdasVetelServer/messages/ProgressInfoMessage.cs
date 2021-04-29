using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.messages
{
    class ProgressInfoMessage : MessageBase
    {
        public string Info { get; set; }

        public ProgressInfoMessage(string info) : base("ProgressInfo")
        {
            Info = info;
        }
    }
}
