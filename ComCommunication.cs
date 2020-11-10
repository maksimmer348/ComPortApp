namespace ComPortSettings
{
    public class ComCommunication
    {

        public void ComInit()
        {
            GodSerialPort serialPortInit = new GodSerialPort("COM" + NumPort, BaudRate, Parity) { DtrEnable = Dtr };
            serialPortInit.Open();
            gsp = serialPortInit;
        }

        public void ComWrite(string write)
        {
            if (!string.IsNullOrEmpty(write))
            {
                if (gsp.Open())
                {
                    gsp.WriteAsciiString(write + "\r\n");
                    WriteCom = write;
                    ReadCom = ComRead();
                }

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
                    return buff;
                }
                else
                {
                    return read;
                }
            }
        }
    }
}
    }
}