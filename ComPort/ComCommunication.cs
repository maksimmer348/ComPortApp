using System;
using System.IO.Ports;
using System.Linq;
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
        public int CfgChannelNum;
        public void Open(ComConfig cfg)
        {
            if (port == null || port.IsOpen == false)
            {
                port = new GodSerialPort("COM" + cfg.ChannelNum, cfg.BaudRate, cfg.ParityBit) {DtrEnable = cfg.DTR};
                port.StopBits = ConvertStopBits(cfg.StopBits);
                port.Open();
                CfgChannelNum = cfg.ChannelNum;
            }
        }

        public void Close()
        {
            if (port != null && port.IsOpen)
            {
                port.Close();

            }
        }

        public async Task<string> Write(string write, int delay = 1000)
        {
            if (port == null) return null;

            const string endOfLine = "\r\n";

            if (port.Open())
            {
                port.WriteAsciiString(write + endOfLine);

                return await Read(delay);
            }

            throw new Exception("Порт не открыт или занят");
        }

        public async Task<string> Read(int delay)
        {
            await Task.Delay(delay);

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

        public StopBits ConvertStopBits(int stopBit)
        {
            return stopBit switch
            {
                1 => StopBits.One,
                2 => StopBits.Two,
                _ => StopBits.One
            };
        }


    }
}