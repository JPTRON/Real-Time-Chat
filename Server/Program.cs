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
using System.Text.Json;

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
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            string aesKey = Convert.ToBase64String(aes.Key);
            string aesIV = Convert.ToBase64String(aes.IV);
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

                ClientHandler clientHandler = new ClientHandler(client, protocolSI.GetStringFromData(), aesKey, aesIV);
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
        private string iv;
        private string key;
        private string publickey;

        public ClientHandler(TcpClient client, string username, string key, string iv)
        {
            this.client = client;
            this.clientID = username;
            this.iv = iv;
            this.key = key;

            Vars.clients.Add(this);

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
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            NetworkStream networkStream = this.client.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();
            Logger logger = new Logger();
            byte[] finalDataBytes = new byte[] { };
            int dataLength = 0;


            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                
                string message;
                byte[] dataBytes;
                byte[] EncryptedMsg;


                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.EOT:

                        message = $"{DateTime.Now} - [SERVER] Client '{this.clientID}' disconnected";

                        Console.WriteLine(message);

                        logger.WriteLog(message);

                        EncryptedMsg = AesEncryption(message);

                        Vars.clients.Remove(this);

                        CreateSendDataThreads(ProtocolSICmdType.DATA, EncryptedMsg);
                        Thread.Sleep(100);
                        CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_4, Encoding.ASCII.GetBytes(Vars.clients.Count.ToString()));
                        break;

                    case ProtocolSICmdType.DATA:

                        dataBytes = protocolSI.GetData();
                        
                        if (dataBytes.Length != dataLength) { break; }

                        ArrayM mensagem = System.Text.Json.JsonSerializer.Deserialize<ArrayM>(dataBytes);
                        
                        finalDataBytes = AesDecrypt(mensagem.message);

                        if (VerifyData(finalDataBytes, mensagem.signatureHash))
                        {

                            Console.WriteLine(Convert.ToBase64String(finalDataBytes));
                            
                            message = $"{DateTime.Now} - Client {clientID}: {ASCIIEncoding.ASCII.GetString(finalDataBytes)}";

                            logger.WriteLog(message);

                            Console.WriteLine(message);

                            byte[] NewEncryptedMsg = AesEncryption(message);

                            Console.WriteLine(Convert.ToBase64String(NewEncryptedMsg));

                            CreateSendDataThreads(ProtocolSICmdType.DATA, NewEncryptedMsg);

                            finalDataBytes = new byte[] { };
                            dataLength = 0;
                        }
                        break;

                    case ProtocolSICmdType.USER_OPTION_1:
                        fileName = protocolSI.GetStringFromData();
                        break;

                    case ProtocolSICmdType.USER_OPTION_2:
                        
                        dataBytes = protocolSI.GetData();
                        
                        finalDataBytes = finalDataBytes.Concat(dataBytes).ToArray();

                        if (finalDataBytes.Length != dataLength) { break; }

                        ArrayM fileMsg = System.Text.Json.JsonSerializer.Deserialize<ArrayM>(finalDataBytes);

                        finalDataBytes = AesDecrypt(fileMsg.message);

                        bool teste = VerifyData(finalDataBytes, fileMsg.signatureHash);

                        if (VerifyData(finalDataBytes, fileMsg.signatureHash))
                        {
                            List<byte[]> file = new List<byte[]>();

                            message = $"{DateTime.Now} - [FILE] Client {clientID}: {fileName}";
                            logger.WriteLog(message);
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
                        }
                        break;

                    case ProtocolSICmdType.USER_OPTION_3:
                        dataLength = Int32.Parse(protocolSI.GetStringFromData());
                        break;

                    case ProtocolSICmdType.PUBLIC_KEY:
                        string publickey = protocolSI.GetStringFromData();
                        this.publickey = publickey;

                        RSA.FromXmlString(this.publickey);

                        
                        byte[] keybytes = RSA.Encrypt(ByteConverter.GetBytes(key), false);
                        byte[] ivbytes = RSA.Encrypt(ByteConverter.GetBytes(iv), false);


                        SendDataToClients(this, ProtocolSICmdType.SECRET_KEY, keybytes);
                        
                        while(protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                        {
                            networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        }

                        SendDataToClients(this, ProtocolSICmdType.IV, ivbytes);

                        while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                        {
                            networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        }

                        message = $"{DateTime.Now} - [SERVER] Client '{this.clientID}' connected";
                        Console.WriteLine(message);
                        logger.WriteLog(message);

                        byte[] Alert = AesEncryption(message);

                        CreateSendDataThreads(ProtocolSICmdType.DATA, Alert);
                        break;
                }
                
            }

            Vars.clientCounter++;
            networkStream.Close();
            client.Close();
        }
        private bool VerifyData(byte[] msg, byte[] signature)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                bool verify = RSA.VerifyData(msg, sha1, signature);
                return verify;
            }
        }

        public byte[] AesEncryption(string data)
        {
            byte[] dataB = Encoding.ASCII.GetBytes(data);
            MemoryStream ms = new MemoryStream();
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

            aes.IV = Convert.FromBase64String(iv);
            aes.Key = Convert.FromBase64String(key);

            CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);

            cs.Write(dataB, 0, dataB.Length);
            cs.FlushFinalBlock();

            dataB = ms.ToArray();

            ms.Flush();
            cs.Close();
            ms.Close();


            return dataB;
        }

        public byte[] AesDecrypt(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

            aes.IV = Convert.FromBase64String(iv);
            aes.Key = Convert.FromBase64String(key);


            CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Write);

            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();

            byte[] msgbytes = ms.ToArray();

            ms.Flush();
            cs.Close();
            ms.Close();

            return msgbytes;
        }

        public void CreateSendDataThreads(ProtocolSICmdType type, byte[] data)
        {
            
            byte[] tyaws = (data);
            string ff = Convert.ToBase64String(tyaws);

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
    class ArrayM
    {
        public byte[] message { get; set; }
        public byte[] signatureHash { get; set; }
    }
}