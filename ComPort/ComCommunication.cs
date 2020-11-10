using System.Text;
using System.Threading;
using GodSharp.SerialPort;

namespace ComPortSettings
{
    public class ComCommunication
    {
        private ComConfig config;
        private GodSerialPort port;

        public ComCommunication(ComConfig cfg)
        {
            config = cfg;
        }

        public void Open()
        {
            port = new GodSerialPort("COM" + config.ChannelNum, config.BaudRate, config.ParityBit) { DtrEnable = config.DTR };
            port.Open();
        }

        public string Write(string write)
        {
            if (port == null) return null;

            const string endOfLine = "\r\n";
            
            if (port.Open())
            {
                port.WriteAsciiString(write + endOfLine);
                
                Thread.Sleep(1000);
                
                return Read();
            }

            return null;
        }

        private string Read()
        {
            byte[] buffer = port.Read();
            if (buffer == null)
            {
                return "null";
            }

            string read = Encoding.ASCII.GetString(buffer);

            if (read[0] == '?')
            {
                return read.Substring(1);;
            }
            else
            {
                return read;
            }
        }
    }
}