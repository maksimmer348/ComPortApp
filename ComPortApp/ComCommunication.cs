using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GodSharp.SerialPort;
using System.Timers;

namespace ComPortApp
{
    public class ComCommunication
    {
        ASCIIEncoding ascii = new ASCIIEncoding();
        private GodSerialPort gsp;
        public int NumPort;
        public int BaudRate;
        public int Parity;
        public bool Dtr;
        public string WriteCom;
        public string ReadCom;
        

        public void ComInit()
        {
            GodSerialPort serialPortInit = new GodSerialPort("COM" + NumPort, BaudRate, Parity) {DtrEnable = Dtr};
            serialPortInit.Open();
            gsp = serialPortInit;
        }

        public void ComWrite(string write)
        {
            if (!string.IsNullOrEmpty(write))
            {
                gsp.WriteAsciiString(write + "\r\n");
                WriteCom = write;
                ReadCom = ComRead();
            }
        }

        public string ComRead()
        {
            Thread.Sleep(1000); //BUG:временная мера чтобы ответ успел сформироватся ИСПРАВИТЬ

            byte[] byt = gsp.Read();
            if (byt == null)
            {
                return "null";
            }
            else
            {
                string read = ascii.GetString(byt);

                if (read[0] == '?')
                {
                    var buff = read.Substring(1);
                    return  buff;
                }
                else
                {
                    return read;
                }
            }
        }
    }
}
