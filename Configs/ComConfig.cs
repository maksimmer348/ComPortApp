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
            new ComConfig {ChannelNum = 1, BaudRate = 2400, ParityBit = 0, StopBits = 0, DTR = true},
            new ComConfig {ChannelNum = 2, BaudRate = 9600, ParityBit = 1, StopBits = 0, DTR = false},
        };

        public static ComConfig DefaultSupply => Default[0];
        public static ComConfig DefaultMeter => Default[1];
    }
}
   