using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Logger
    {

        public void WriteLog(string message)
        {
            string currentDir = Environment.CurrentDirectory;
            string path = currentDir+@".\logs.txt";


            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(message);

            sw.Close();
        }

    }
}
