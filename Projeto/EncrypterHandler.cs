using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Projeto
{
    internal class EncrypterHandler
    {
        public byte[] encrypt(string data, string iv, string key)
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

        public byte[] decrypt(byte[] data, string iv, string key)
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
    }
}

