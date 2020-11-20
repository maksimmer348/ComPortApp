using System;
using System.IO.Ports;
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
        public GodSerialPort port;

        public void Open(ComConfig cfg)
        {
            if (port == null || port.IsOpen == false)
            {
                port = new GodSerialPort("COM" + cfg.ChannelNum, cfg.BaudRate, cfg.ParityBit) {DtrEnable = cfg.DTR};
                ConvertStopBits(cfg.StopBits, port);
                port.Open();
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

        public void ConvertStopBits(int stopBit, GodSerialPort port)
        {
            switch (stopBit)
            {
                case 1:
                    port.StopBits = StopBits.One;
                    break;
                case 2:
                    port.StopBits = StopBits.Two;
                    break;
                default:
                    port.StopBits = StopBits.One;
                    break;
            }
        }
    }
}