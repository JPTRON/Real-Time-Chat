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
            s s = new s();
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

                if(protocolSI.GetCmdType() == ProtocolSICmdType.USER_OPTION_4)
                {
                    s.login(protocolSI.GetData(), networkStream);
                }
                else if(protocolSI.GetCmdType() == ProtocolSICmdType.USER_OPTION_5)
                {
                    s.signup(protocolSI.GetData(), networkStream);
                }
                else
                {
                    Vars.clientCounter++;

                    ClientHandler clientHandler = new ClientHandler(client, protocolSI.GetStringFromData(), aesKey, aesIV);
                    clientHandler.Handle();
                } 
            }
        }
    }

    class s
    {
        BDHandler BD = new BDHandler();
        ProtocolSI protocolSI = new ProtocolSI();
        Credenciais credenciais;

        public void login(byte[] dataBytes, NetworkStream clientNetworkStream)
        {
            credenciais = System.Text.Json.JsonSerializer.Deserialize<Credenciais>(dataBytes);

            string message = BD.CompareCredentials(credenciais.username, credenciais.passwordHash);

            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, Encoding.ASCII.GetBytes(message));
            clientNetworkStream.Write(packet, 0, packet.Length);

            packet = protocolSI.Make(ProtocolSICmdType.ACK);
            clientNetworkStream.Write(packet, 0, packet.Length);
        }

        public void signup(byte[] dataBytes, NetworkStream clientNetworkStream)
        {
            credenciais = System.Text.Json.JsonSerializer.Deserialize<Credenciais>(dataBytes);

            string message = BD.RegisterUser(credenciais.username, credenciais.passwordHash);

            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, Encoding.ASCII.GetBytes(message));
            clientNetworkStream.Write(packet, 0, packet.Length);

            packet = protocolSI.Make(ProtocolSICmdType.ACK);
            clientNetworkStream.Write(packet, 0, packet.Length);
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
            byte[] finalDataBytes = new byte[] { };
            byte[] finalFileBytes = new byte[] { };
            int dataLength = 0;
            int fileLength = 0;

            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                
                string message;
                byte[] dataBytes;
                byte[] EncryptedMsg;
                Credenciais credenciais;
                BDHandler BD = new BDHandler();

                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.EOT:

                        message = $"{DateTime.Now.ToString("HH:mm")} | [SERVER] - '{this.clientID}' disconnected";

                        Console.WriteLine(message);

                        EncryptedMsg = AesEncryption(message);

                        Vars.clients.Remove(this);

                        CreateSendDataThreads(ProtocolSICmdType.DATA, EncryptedMsg);
                        Thread.Sleep(100);
                        CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_4, Encoding.ASCII.GetBytes(Vars.clients.Count.ToString()));
                        break;

                    case ProtocolSICmdType.DATA:

                        dataBytes = protocolSI.GetData();
                        //Console.WriteLine($"{finalDataBytes.Length} - {dataLength} : {finalDataBytes.Length != dataLength}");
                        if (dataBytes.Length != dataLength) { break; }

                        ArrayM mensagem = System.Text.Json.JsonSerializer.Deserialize<ArrayM>(dataBytes);
                        
                        finalDataBytes = AesDecrypt(mensagem.message);

                        if (VerifyData(finalDataBytes, mensagem.signatureHash))
                        {
                            message = $"{DateTime.Now.ToString("HH:mm")} | {clientID}: {ASCIIEncoding.ASCII.GetString(finalDataBytes)}";

                            Console.WriteLine(message);

                            byte[] NewEncryptedMsg = AesEncryption(message);

                            Vars.clients.Remove(this);
                            CreateSendDataThreads(ProtocolSICmdType.DATA, NewEncryptedMsg);
                            Vars.clients.Add(this);

                            finalDataBytes = new byte[] { };
                            dataLength = 0;
                        }
                        break;

                    case ProtocolSICmdType.USER_OPTION_1:
                        fileName = protocolSI.GetStringFromData();
                        break;

                    case ProtocolSICmdType.USER_OPTION_2:
                        
                        dataBytes = protocolSI.GetData();

                        finalFileBytes = finalFileBytes.Concat(dataBytes).ToArray();
                        //Console.WriteLine($"{finalFileBytes.Length} - {fileLength} : {finalFileBytes.Length != dataLength}");
                        if (finalFileBytes.Length != fileLength) { break; }

                        ArrayM fileMsg = System.Text.Json.JsonSerializer.Deserialize<ArrayM>(finalFileBytes);

                        finalFileBytes = AesDecrypt(fileMsg.message);

                        if (VerifyData(finalFileBytes, fileMsg.signatureHash))
                        {
                            List<byte[]> file = new List<byte[]>();

                            message = $"{DateTime.Now.ToString("HH:mm")} | [FILE] - {clientID}: {fileName}";
                            Console.WriteLine(message);

                            BinaryFormatter formatter = new BinaryFormatter();
                            MemoryStream ms = new MemoryStream();

                            file.Add(Encoding.ASCII.GetBytes(fileName));
                            file.Add(finalFileBytes);
                            file.Add(Encoding.ASCII.GetBytes(message));
                            formatter.Serialize(ms, file);
                            ms.Position = 0;
                            //File.WriteAllBytes($"./{fileName}", finalDataBytes);

                            CreateSendDataThreads(ProtocolSICmdType.USER_OPTION_2, ms.ToArray());

                            ms.Flush();
                            ms.Close();
                            finalFileBytes = new byte[] { };
                            fileLength = 0;
                        }
                        break;

                    case ProtocolSICmdType.USER_OPTION_3:
                        Info info = System.Text.Json.JsonSerializer.Deserialize<Info>(protocolSI.GetData());
                        
                        if(info.tipo == "USER_OPTION_2")
                        {
                            fileLength = info.tamanho;
                        }
                        else if(info.tipo == "DATA")
                        {
                            dataLength = info.tamanho;
                        }

                        break;

                    case ProtocolSICmdType.PUBLIC_KEY:
                        string publickey = protocolSI.GetStringFromData();
                        this.publickey = publickey;

                        RSA.FromXmlString(this.publickey);
                        
                        byte[] keybytes = RSA.Encrypt(ByteConverter.GetBytes(key), false);
                        byte[] ivbytes = RSA.Encrypt(ByteConverter.GetBytes(iv), false);

                        byte[] packet = protocolSI.Make(ProtocolSICmdType.SECRET_KEY, keybytes);
                        networkStream.Write(packet, 0, packet.Length);

                        while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                        {
                            networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        }

                        packet = protocolSI.Make(ProtocolSICmdType.IV, ivbytes);
                        networkStream.Write(packet, 0, packet.Length);

                        while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                        {
                            networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        }

                        message = $"{DateTime.Now.ToString("HH:mm")} | [SERVER] - '{this.clientID}' connected";
                        Console.WriteLine(message);

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

    class Credenciais
    {
        public string username { get; set; }
        public string passwordHash { get; set; }
    }

    class Info
    {
        public int tamanho { get; set; }
        public string tipo { get; set; }
    }
}