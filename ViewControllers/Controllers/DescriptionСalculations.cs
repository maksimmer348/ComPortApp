using System;
using System.Globalization;

namespace ComPortSettings
{
    public static class DescriptionСalculations
    {
        public static string GetPower(double voltage, double current)
        {
            double power = voltage * current;
            return ReturnValue(power);
        }
        public static string GetVoltage(double current, double power)
        {
            double voltage = power / current;
            return ReturnValue(voltage);
        }
        public static string GetСurrent(double voltage, double power)
        {
            double current = power / voltage;
            return ReturnValue(current);
        }
        public static string ReturnValue(double input)
        {
            return Math.Round(input, 2).ToString("0.00", CultureInfo.InvariantCulture).Replace(",", ".");
        }

    }
}