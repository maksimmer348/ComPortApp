namespace ComPortSettings
{
    public struct ComConfig
    {
        public int ChannelNum;
        public int BaudRate;
        public int ParityBit;
        public int StopBits;
        public bool DTR;

        public static ComConfig[] Default =
        {
            new ComConfig {ChannelNum = 3, BaudRate = 9600, ParityBit = 0, StopBits = 1, DTR = false},
            new ComConfig {ChannelNum = 4, BaudRate = 9600, ParityBit = 0, StopBits = 1, DTR = false},
        };

        public static ComConfig DefaultSupply => Default[0];
        public static ComConfig DefaultMeter => Default[1];
    }
}
   