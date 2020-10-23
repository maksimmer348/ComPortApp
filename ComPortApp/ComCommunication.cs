using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodSharp.SerialPort;

namespace ComPortApp
{
    class ComCommunication
    {
        public void ComInit()
        {

            ASCIIEncoding ascii = new ASCIIEncoding();

            //Console.Write("input serialport number(only 0-9):");
            string read = Console.ReadLine();
            bool flag = uint.TryParse(read, out uint num);
            if (!flag)
            {
                Exit();
            }

            GodSerialPort gsp = new GodSerialPort("COM" + num, 9600, 0);
            gsp.DtrEnable = true;
            gsp.UseDataReceived(true, (sp, bytes) =>
            {
                //string buffer = string.Join(" ", bytes);
                string buffer = ascii.GetString(bytes);
                Console.WriteLine("receive data:" + buffer);
            });
            //byte[] bytes = gsp.Read();
            //string AOAAO = gsp.ReadString();
            //Console.WriteLine(AOAAO);

            flag = gsp.Open();


            if (!flag)
            {
                Exit();
            }

            Console.WriteLine("serialport opend");

            Console.WriteLine("press any thing as data to send,press key 'q' to quit.");

            string data = null;
            while (data == null || data.ToLower() != "q")
            {
                if (!string.IsNullOrEmpty(data))
                {
                    Console.WriteLine("send data:" + data);
                    gsp.WriteAsciiString(data + "\r\n");
                }

                data = Console.ReadLine().ToUpper();
            }

        }

        static void Exit()
        {
            Console.WriteLine("press any key to quit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

