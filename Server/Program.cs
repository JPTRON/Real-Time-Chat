using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{

    static class Vars
    {
        public static List<ClientHandler> clients = new List<ClientHandler>();
        public static int clientCounter = 0;
    }

    internal class Program
    {
        private const int PORT = 10000;

        static void Main(string[] args)
        {
            ProtocolSI protocolSI = new ProtocolSI();

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
            
            TcpListener tcplistener = new TcpListener(endPoint);
            tcplistener.Start();

            Console.WriteLine($"{DateTime.Now} - Server Ready!");

            while (true)
            {
                Thread.Sleep(10);
                TcpClient client = tcplistener.AcceptTcpClient();

                NetworkStream networkStream = client.GetStream();
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                Vars.clientCounter++;

                ClientHandler clientHandler = new ClientHandler(client, protocolSI.GetStringFromData());
                clientHandler.Handle();
            }
        }
    }

    // criar clients
    class ClientHandler
    {
        private TcpClient client;
        private string clientID;
        private string fileName = "";

        public ClientHandler(TcpClient client, string username)
        {
            this.client = client;
            this.clientID = username;

            Vars.clients.Add(this);

            string message = $"{DateTime.Now} - [SERVER] Client '{username}' connected";
            Console.WriteLine(message);

            CreateSendDataThreads(ProtocolSICmdType.DATA, Encoding.ASCII.GetBytes(message));
            Thread.Sleep(100);
            CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_4, Encoding.ASCII.GetBytes(Vars.clients.Count.ToString()));
        }

        public void Handle()
        {
            Thread thread = new Thread(threadhandler);
            thread.Start();
        }

        public void threadhandler()
        {
            NetworkStream networkStream = this.client.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();
            byte[] finalDataBytes = new byte[] { };
            int dataLength = 0;

            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                byte[] ack;
                string message;
                byte[] dataBytes;

                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.EOT:
                        message = $"{DateTime.Now} - [SERVER] Client '{this.clientID}' disconnected";

                        Console.WriteLine(message);              

                        Vars.clients.Remove(this);

                        CreateSendDataThreads(ProtocolSICmdType.DATA, Encoding.ASCII.GetBytes(message));
                        Thread.Sleep(100);
                        CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_4, Encoding.ASCII.GetBytes(Vars.clients.Count.ToString()));
                        break;

                    case ProtocolSICmdType.DATA:
                        dataBytes = protocolSI.GetData();

                        finalDataBytes = finalDataBytes.Concat(dataBytes).ToArray();
                        //Console.WriteLine($"{finalDataBytes.Length} - {dataLength} : {finalDataBytes.Length != dataLength}");
                        if (finalDataBytes.Length != dataLength) { break; }

                        message = $"{DateTime.Now} - Client {clientID}: {ASCIIEncoding.ASCII.GetString(finalDataBytes)}";

                        Console.WriteLine(message);

                        CreateSendDataThreads(ProtocolSICmdType.DATA, Encoding.ASCII.GetBytes(message));

                        finalDataBytes = new byte[] { };
                        dataLength = 0;
                        break;

                    case ProtocolSICmdType.USER_OPTION_1:
                        fileName = protocolSI.GetStringFromData();
                        break;

                    case ProtocolSICmdType.USER_OPTION_2:
                        dataBytes = protocolSI.GetData();
                        
                        finalDataBytes = finalDataBytes.Concat(dataBytes).ToArray();
                        //Console.WriteLine($"{finalDataBytes.Length} - {dataLength} : {finalDataBytes.Length != dataLength}");
                        if (finalDataBytes.Length != dataLength) { break; }

                        List<byte[]> file = new List<byte[]>();

                        message = $"{DateTime.Now} - [FILE] Client {clientID}: {fileName}";
                        Console.WriteLine(message);

                        BinaryFormatter formatter = new BinaryFormatter();
                        MemoryStream ms = new MemoryStream();

                        file.Add(Encoding.ASCII.GetBytes(fileName));
                        file.Add(finalDataBytes);
                        file.Add(Encoding.ASCII.GetBytes(message));
                        formatter.Serialize(ms, file);
                        ms.Position = 0;
                        //File.WriteAllBytes($"./{fileName}", finalDataBytes);

                        CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_2, ms.ToArray());

                        ms.Flush();
                        ms.Close();
                        finalDataBytes = new byte[] { };
                        dataLength = 0;
                        break;

                    case ProtocolSICmdType.USER_OPTION_3:
                        dataLength = Int32.Parse(protocolSI.GetStringFromData());

                        break;
                }
                
            }

            Vars.clientCounter++;
            networkStream.Close();
            client.Close();
        }

        public void CreateSendDataThreads(ProtocolSICmdType type, byte[] data)
        {
            foreach (ClientHandler clientHandler in Vars.clients)
            {
                Thread trd = new Thread(() => SendDataToClients(clientHandler, type, data));
                trd.IsBackground = true;
                trd.Start();
            }
        }

        public void SendDataToClients(ClientHandler clientHandler, ProtocolSICmdType type, byte[] data)
        {
            ProtocolSI protocolSI = new ProtocolSI();

            byte[] originalData = data;

            byte[] packet;
            data = originalData;

            NetworkStream clientNetworkStream = clientHandler.client.GetStream();

            packet = protocolSI.Make(ProtocolSICmdType.USER_OPTION_3, data.Length);
            clientNetworkStream.Write(packet, 0, packet.Length);

            do
            {
                if (data.Length >= 1400)
                {
                    packet = protocolSI.Make(type, data.Take(1400).ToArray());
                }
                else
                {
                    packet = protocolSI.Make(type, data);
                }

                data = data.Skip(1400).ToArray();

                clientNetworkStream.Write(packet, 0, packet.Length);
            }
            while (data.Length > 0);
        }
    }
}