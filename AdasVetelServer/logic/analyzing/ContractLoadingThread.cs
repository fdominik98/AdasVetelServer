using AdasVetelServer.logger;
using AdasVetelServer.messages;
using AdasVetelServer.tcp;
using System.Collections.Generic;
using System.Threading;


namespace AdasVetelServer.logic.analyzing
{
    class ContractLoadingThread
    {
        static ManualResetEvent waitForTask = new ManualResetEvent(false);
        private List<LoadingTask> tasks = new List<LoadingTask>();     
        private bool endThread = false;
        public ContractLoadingThread()  { }
        public void startListening()          
        {
           
            while (true)
            {
                waitForTask.WaitOne();
                while (tasks.Count > 0)
                {
                    ProgressInfoMessage progress = new ProgressInfoMessage($"Analyzing {tasks[0].Contract.FileName}.");
                    TcpServerWrapper.Instance.send<ProgressInfoMessage>(tasks[0].Port, progress);
                    ServerLogger.Instance.writeLog(progress.Info);
                    tasks[0].executeTask();
                    LoadMessage resp = new LoadMessage("", tasks[0].Contract.FileName);
                    TcpServerWrapper.Instance.send<LoadMessage>(tasks[0].Port, resp);                  
                    TcpServerWrapper.Instance.sendToAll<DatabaseChangedMessage>(new DatabaseChangedMessage());
                    ServerLogger.Instance.writeLog($"{resp.FileName} analyzed succesfully.");
                    tasks.RemoveAt(0);
                }
                waitForTask.Reset();
                if (endThread)
                    break;

            }
          
        }
        public void addTask(LoadMessage contract, string port){
            tasks.Add(new LoadingTask(contract, port));
            waitForTask.Set();
        }
        public void stopThread()
        {
            endThread = true;
            waitForTask.Set();
        }
    }
}
