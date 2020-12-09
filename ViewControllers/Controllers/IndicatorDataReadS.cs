namespace ComPortSettings
{
    public class IndicatorDataReadS
    {
    
           
            public double ReadVoltage;
            public double ReadCurrent;
            public double ReadPower;

            public static IndicatorDataReadS[] Default =
            {
                new IndicatorDataReadS {ReadVoltage = 00.00, ReadCurrent = 00.00, ReadPower = 00.00}
            };
        }
    }
