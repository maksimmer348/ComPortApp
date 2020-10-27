using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GodSharp.SerialPort;

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
        public string Buffer;
        public string Data;

        public void ComInit()
        {

            //bool flag = uint.TryParse(NumPort, out uint num);

            //if (!flag)
            //{
            //    Exit();
            //}

            GodSerialPort gsp = new GodSerialPort("COM" + NumPort, BaudRate, Parity) {DtrEnable = Dtr};
            gsp.Open();

            //if (!flag)
            //{
            //    Exit();
            //}

            //if (!string.IsNullOrEmpty(Data))
            //{
            gsp.WriteAsciiString(Data + "\r\n");
            //} 

            byte[] byt = gsp.Read();
            string buffer = ascii.GetString(byt);
            Buffer = buffer;
        }

       

        static void Exit()
        {
            Environment.Exit(0);
        }
    }
}

