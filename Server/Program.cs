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
using System.Security.Cryptography;

namespace Server
{

    static class Vars
    {
        public static List<ClientHandler> clients = new List<ClientHandler>();
        public static int clientCounter = 0;
        public static string iv;
        public static string key;
    }

    internal class Program
    {
        private const int PORT = 10000;

        static void Main(string[] args)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            Vars.key = Convert.ToBase64String(aes.Key);
            Vars.iv = Convert.ToBase64String(aes.IV);

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
                //networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                ClientHandler clientHandler = new ClientHandler(client);
                clientHandler.Handle();                             
            }
        }
    }

    // criar clients
    class ClientHandler
    {
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        private TcpClient client;
        private string clientID;
        private string fileName = "";
        private string publickey;

        public ClientHandler(TcpClient client)
        {
            this.client = client;
            Thread.Sleep(100);
        }

        public void Handle()
        {
            Thread thread = new Thread(threadhandler);
            thread.Start();
        }

        public void threadhandler()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            NetworkStream networkStream = this.client.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();

            byte[] finalDataBytes = new byte[] { };
            int dataLength = 0;

            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                EncrypterHandler EH = new EncrypterHandler();
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

                        CreateSendDataThreads(ProtocolSICmdType.DATA, EH.encrypt(message, Vars.iv, Vars.key));
                        Thread.Sleep(100);
                        CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_4, Encoding.ASCII.GetBytes(Vars.clients.Count.ToString()));
                        break;

                    case ProtocolSICmdType.DATA:
                        dataBytes = protocolSI.GetData();

                        finalDataBytes = finalDataBytes.Concat(dataBytes).ToArray();
                        //Console.WriteLine($"{finalDataBytes.Length} - {dataLength} : {finalDataBytes.Length != dataLength}");
                        if (finalDataBytes.Length != dataLength) { break; }

                        finalDataBytes = EH.decrypt(finalDataBytes, Vars.iv, Vars.key);

                        message = $"{DateTime.Now} - Client {clientID}: {ASCIIEncoding.ASCII.GetString(finalDataBytes)}";
                        Console.WriteLine(message);

                        CreateSendDataThreads(ProtocolSICmdType.DATA, EH.encrypt(message, Vars.iv, Vars.key));

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

                    case ProtocolSICmdType.USER_OPTION_4:
                        this.clientID = protocolSI.GetStringFromData();

                        Vars.clients.Add(this);
                        Vars.clientCounter++;

                        message = $"{DateTime.Now} - [SERVER] Client '{this.clientID}' connected";
                        Console.WriteLine(message);
                        Thread.Sleep(100);
                        CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_4, Encoding.ASCII.GetBytes(Vars.clients.Count.ToString()));
                        Thread.Sleep(100);
                        CreateSendDataThreads(ProtocolSICmdType.DATA, EH.encrypt(message, Vars.iv, Vars.key));
                        break;

                    case ProtocolSICmdType.PUBLIC_KEY:
                        string publickey = protocolSI.GetStringFromData();
                        this.publickey = publickey;

                        RSA.FromXmlString(publickey);

                        byte[] keybytes = RSA.Encrypt(ByteConverter.GetBytes(Vars.key), false);
                        byte[] ivbytes = RSA.Encrypt(ByteConverter.GetBytes(Vars.iv), false);

                        SendDataToClients(this, ProtocolSICmdType.SECRET_KEY, keybytes);
                        Thread.Sleep(100);
                        SendDataToClients(this, ProtocolSICmdType.IV, ivbytes);
                        Thread.Sleep(100);
                        break;
                }         
            }

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