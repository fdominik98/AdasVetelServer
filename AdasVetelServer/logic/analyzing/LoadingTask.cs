using AdasVetelServer.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdasVetelServer.logic.analyzing
{
    class LoadingTask
    {
        public LoadMessage Contract { get; set; }
        public string Port { get; set; }
        public LoadingTask(LoadMessage contract, string port)
        {
            Contract = contract;
            Port = port;
        }
        public void executeTask()
        {
            TextAnalyzer.Instance.analyzeText(Contract.Data, Contract.FileName);
        }
    }
}
