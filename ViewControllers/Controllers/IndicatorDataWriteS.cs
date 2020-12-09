namespace ComPortSettings
{
    public struct IndicatorDataWriteS
    {
        public double WriteVoltage;
        public double WriteCurrent;
        public double WritePower;

        public static IndicatorDataWriteS[] Default =
        {
            new IndicatorDataWriteS {WriteVoltage = 00.00, WriteCurrent = 00.00, WritePower = 00.00}
        };
    }
}
