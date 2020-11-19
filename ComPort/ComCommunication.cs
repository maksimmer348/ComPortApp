using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using GodSharp.SerialPort;

namespace ComPortSettings
{
    public class ComCommunication
    {
   
        private GodSerialPort port;


        public void Open(ComConfig cfg)
        {
            //TODO проверить на живом com
            //Close();
            if (port == null || port.IsOpen == false)
            {
                port = new GodSerialPort("COM" + cfg.ChannelNum, cfg.BaudRate, cfg.ParityBit) { DtrEnable = cfg.DTR };
                port.Open();
            }
        }

        public void Close()
        {
            //TODO проверить на живом com
            if (port != null && port.IsOpen)
            {
                port.Close();
               
            }

        }

        public async Task<string> Write(string write)
        {
            if (port == null) return null;

                const string endOfLine = "\r\n";

            if (port.Open())
            {
                port.WriteAsciiString(write + endOfLine);

                return await Read();
            }
            throw new Exception("Port not open");
            
        }


        
        public async Task<string> Read()
        {
            await Task.Delay(1000);
            
            byte[] buffer = port.Read();
            if (buffer == null)
            {
                return "null";
            }

            string read = Encoding.ASCII.GetString(buffer);

            if (read[0] == '?')
            {
                return read.Substring(1);
            }
            else
            {
                return read;
            }
            
        }
    }
}