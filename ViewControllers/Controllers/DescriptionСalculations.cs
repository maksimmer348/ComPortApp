using System;
using System.Globalization;

namespace ComPortSettings
{
    public class DescriptionСalculations
    {
        public string GetPower(double voltage, double current)
        {
            double power = voltage * current;
            return ReturnValue(power);
        }
        public string GetVoltage(double current, double power)
        {
            double voltage = power / current;
            return ReturnValue(voltage);
        }
        public string GetСurrent(double voltage, double power)
        {
            double current = power / voltage;
            return ReturnValue(current);
        }
        public string ReturnValue(double input)
        {
            return Math.Round(input, 2).ToString("0.00", CultureInfo.InvariantCulture).Replace(",", ".");
        }

    }
}