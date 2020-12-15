using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ComPortSettings.ComPort;
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
                port.TryReadNumber = 1;
                port.TryReadSpanTime = 0;
                port.Terminator = null;
                port.Open();
                CfgChannelNum = cfg.ChannelNum;
                //port.Buf
            }
        }

        public void Close()
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
            }
        }

        public async Task<string> Write(string write, int delay = 200, bool extraDelayOn = false)
        {
            if (port == null) return null;
            const string endOfLine = "\r\n";
            if (!port.Open()) throw new Exception("Порт не открыт или занят");
            port.WriteAsciiString(write + endOfLine);
           
            return await Read(delay, extraDelayOn);
        }
        
        public async Task<string> Read(int delay, bool extraDelayOn)
        {
            await Task.Delay(200);
            byte[] buffer = port.Read();

            if (buffer == null)
            {
                return String.Empty;
            }
            else if (!buffer.Contains((byte)10)&& extraDelayOn)
            {
                await Task.Delay(50);
            }
            
            string read = Encoding.ASCII.GetString(buffer);
           
            return DelTrash(read);
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

        public string DelTrash(string enter)
        {
            char[] trash = new[] {'?', '\n', '\r'};
            return String.Join("",enter.Where((ch) => !trash.Contains(ch)));
        }
    }
}