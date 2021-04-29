using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.tcp
{
    public class ClientModel
    {
        public string IpPort { get; set; }
        public bool UpToDate { get; set; } = false;

        public ClientModel(string ipPort) {
            IpPort = ipPort;
        }
    }
}
