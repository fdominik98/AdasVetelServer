using AdasVetelServer.db;
using AdasVetelServer.logger;
using AdasVetelServer.logic.analyzing;
using AdasVetelServer.messages;
using SimpleTcp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdasVetelServer.tcp
{
    public class TcpServerWrapper
    {
        public static TcpServerWrapper Instance { get; } = new TcpServerWrapper();
        private JsonSerializerOptions sOption = new JsonSerializerOptions { WriteIndented = false };
       private ClientHolder clients= new ClientHolder();
        private SimpleTcpServer server;
        private ContractLoadingThread contractLoadingThread;
        private int currentMessageSize = 0;
        private MemoryStream currentMessageStream = new MemoryStream();
        private BinaryReader br;
        long readPos = 0;
        object lockObject = new object();

        private TcpServerWrapper()  {            
            br = new BinaryReader(currentMessageStream);
        }
    
        public void stopServer()
        {
            contractLoadingThread.stopThread();
            foreach (ClientModel item in clients.Clients)        
                server.DisconnectClient(item.IpPort);           
            clients.clear();
            server.Stop();
            server.Dispose();
            while (server.IsListening) ;
            ServerLogger.Instance.writeLog("Server stopped...");
            server.Events.ClientConnected -= EventClientConnected;
            server.Events.ClientDisconnected -= EventClientDisconnected;
            server.Events.DataReceived -= EventDataReceived;
        }
        public void startServer(string port,bool localhost)
        {      
            string ip;
            if (localhost)
                ip = "127.0.0.1";
            else
            {
                ip = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            }

            server = new SimpleTcpServer($"{ip}:{port}");       
          
            ServerLogger.Instance.writeLog("Starting...");
            server.Start();
            while (!server.IsListening) ;
            ServerLogger.Instance.writeLog("Done.");
            ServerLogger.Instance.writeLog($"Server ip: {ip}");
            ServerLogger.Instance.writeLog($"Listening on port {port}...");
            server.Events.ClientConnected += EventClientConnected;
            server.Events.ClientDisconnected += EventClientDisconnected;
            server.Events.DataReceived += EventDataReceived;
         

            contractLoadingThread = new ContractLoadingThread();
            Thread thread = new Thread(contractLoadingThread.startListening);
            thread.IsBackground = true;
            thread.Start();
        }
        public void send<T>(string port, MessageBase message) where T : MessageBase
        {
            using (var outputStream = new MemoryStream())
            {
                using (var bw = new BinaryWriter(outputStream))
                {
                    byte[] data = JsonSerializer.SerializeToUtf8Bytes((T)message, sOption);
                    outputStream.Capacity = data.Length + 4;
                    bw.Write(data.Length);
                    bw.Write(data);
                    outputStream.Position = 0;
                    server.Send(port, outputStream.Length, outputStream);
                    ServerLogger.Instance.writeLog($"{outputStream.Length} bytes sent to {port}.");
                }
            }
        }
        public void sendToAll<T>(MessageBase message) where T : MessageBase
        {
            foreach (ClientModel item in clients.Clients)
                send<T>(item.IpPort, message);
        }
        private void EventDataReceived(object sender, DataReceivedEventArgs e)
        {
            ServerLogger.Instance.writeLog($"{e.Data.Length} bytes received from {e.IpPort}");
            lock (lockObject) { 
                receiveData(e.Data, e.IpPort);
            }
        }
        private void receiveData(byte[] data, string ipPort)
        {
            currentMessageStream.Capacity = currentMessageStream.Capacity + data.Length;
            currentMessageStream.Write(data, 0, data.Length);
            currentMessageStream.Position = readPos;
            if (currentMessageSize == 0)
            {
                currentMessageSize = br.ReadInt32();
                if (currentMessageStream.Length - 4 < currentMessageSize)
                {
                    readPos = currentMessageStream.Position;
                    currentMessageStream.Seek(0, SeekOrigin.End);
                    return;
                }
            }
            handleData(br.ReadBytes(currentMessageSize), ipPort);
            if (currentMessageStream.Position < currentMessageStream.Length)
            {
                byte[] remaining = br.ReadBytes((int)(currentMessageStream.Length - currentMessageStream.Position));
                resetStream();
                receiveData(remaining, ipPort);
            }
            else if (currentMessageStream.Position == currentMessageStream.Length)
            {
                resetStream();
            }
        }
        private void resetStream()
        {
            currentMessageStream.Close();
            br.Close();
            currentMessageStream = new MemoryStream();
            br = new BinaryReader(currentMessageStream);
            readPos = 0;
            currentMessageSize = 0;
        }
        private void handleData(byte[] data, string port) {
            try {
                MessageBase msg = JsonSerializer.Deserialize<MessageBase>(new ReadOnlySpan<byte>(data));

                if (msg.Type == "LoadContract")
                {
                    LoadMessage lmsg = JsonSerializer.Deserialize<LoadMessage>(new ReadOnlySpan<byte>(data));
                    if (lmsg.Data != "") 
                       contractLoadingThread.addTask(lmsg, port);
                }
                if (msg.Type == "RecordRequest")
                {
                    GetRecordMessage grmsg = JsonSerializer.Deserialize<GetRecordMessage>(new ReadOnlySpan<byte>(data));
                    ServerLogger.Instance.writeLog($"Server: {grmsg.Type}, route: {grmsg.Route}");
                    List<byte[]> res = RouteContainer.Instance.getDataByRoute(grmsg.Route);
                    send<GetRecordMessage>(port, new GetRecordMessage(grmsg.Route, new byte[0], true));
                    foreach (byte[] item in res)                  
                         send<GetRecordMessage>(port, new GetRecordMessage(grmsg.Route,item,false)); 
                }
            }
            catch (Exception ex)
            {
                ServerLogger.Instance.writeLog($"Server error: {ex.StackTrace}\n {ex.Message}");
                send<ErrorMessage>(port, new ErrorMessage(ex.Message));
            }          
        }

        private void EventClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {            
            clients.removeClient(e.IpPort);
            ServerLogger.Instance.writeLog($"{e.IpPort }: Disconnected.");     
            
        }

        private void EventClientConnected(object sender, ClientConnectedEventArgs e)
        {
            clients.addClient(e.IpPort);
            ServerLogger.Instance.writeLog($"{e.IpPort }: Connected.");           
        }      

    }
}
