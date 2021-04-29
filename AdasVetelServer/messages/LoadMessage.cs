using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.messages
{
    class LoadMessage : MessageBase
    {
        public string Data { get; set; } = "";
        public string FileName { get; set; } = "";

        public LoadMessage(string data, string fileName) : base("LoadContract")
        {
            Data = data;
            FileName = fileName;
        }
     
    }
}
