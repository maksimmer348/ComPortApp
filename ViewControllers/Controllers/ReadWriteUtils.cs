using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace ComPortSettings
{
    public static class ReadWriteUtils
    {
        public static double TempResult;
        /// <summary>
        /// запись из ComPort в ComboBox для блока питания
        /// </summary>
        public static void WriteSupplySettings(this ComSettings view, ComConfig cfg)
        {
            view.ChannelComSupply.Text = cfg.ChannelNum.ToString();
            view.BaudRateSupply.Text = cfg.BaudRate.ToString();
            view.ParityBitSupply.Text = cfg.ParityBit.ToString();
            view.StopBitsSupply.Text = cfg.StopBits.ToString();
            view.DtrSupply.Checked = cfg.DTR;
        }

        /// <summary>
        /// запись из ComPort в ComboBox для измерителя
        /// </summary>
        public static void WriteMeterSettings(this ComSettings view, ComConfig cfg)
        {
            view.ChannelComMeter.Text = cfg.ChannelNum.ToString();
            view.BaudRateMeter.Text = cfg.BaudRate.ToString();
            view.ParityBitMeter.Text = cfg.ParityBit.ToString();
            view.StopBitsMeter.Text = cfg.StopBits.ToString();
            view.DtrMeter.Checked = cfg.DTR;
        }

        /// <summary>
        /// запись из ComboBox в ComPort для блока питания
        /// </summary>
        public static ComConfig ReadSupplySettings(this ComSettings view)
        {
            return new ComConfig()
            {
                ChannelNum = int.Parse((string) view.ChannelComSupply.SelectedItem),
                BaudRate = int.Parse((string) view.BaudRateSupply.SelectedItem),
                ParityBit = int.Parse((string) view.ParityBitSupply.SelectedItem),
                StopBits = int.Parse((string) view.StopBitsSupply.SelectedItem),
                DTR = view.DtrSupply.Checked,
            };

        }

        /// <summary>
        /// запись из ComboBox в ComPort для измерителя
        /// </summary>
        public static ComConfig ReadMeterSettings(this ComSettings view)
        {
            return new ComConfig()
            {
                ChannelNum = int.Parse((string) view.ChannelComMeter.SelectedItem),
                BaudRate = int.Parse((string) view.BaudRateMeter.SelectedItem),
                ParityBit = int.Parse((string) view.ParityBitMeter.SelectedItem),
                StopBits = int.Parse((string) view.StopBitsMeter.SelectedItem),
                DTR = view.DtrMeter.Checked,
            };
        }

        public static bool ValidatePorts(this ComSettings view)
        {
            if (view.ChannelComMeter.SelectedItem == view.ChannelComSupply.SelectedItem)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// запись из ComboBox в ComPort для измерителя
        /// </summary>
        public static bool ValidateText(this Form1 view, string name, out double result)
        {
            if (!double.TryParse(view.GetComponent<TextBox>(name).Text.Replace(",", "."),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out result))
            {
                MessageBox.Show(
                    $"Введите допустимое числовое значение {(string) view.GetComponent<TextBox>(name).Tag}",
                    "Error Value Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;

        }


        //private async SetSupplyValues()
        //{
        //    //if (View.ValidateText("PowerValueWrite", out var result))
        //    //{
        //    //    Calc.GetPower()
        //    //}
        //    if (ValidateText(VoltageValueWrite, out result))
        //    {
        //        await CommandToFormSupply("Set voltage", result.ToString());
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (View.ValidateText("CurrentValueWrite", out result))
        //    {
        //        await CommandToFormSupply("Set current", result.ToString());
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    await CommandToFormSupply("Output", "0");
        //    View.StatusButtonOn("Output", false);

        //}

        public static bool GetSupplyCheckValues(this Form1 view, string name)
        {
            return view.GetComponent<CheckBox>(name).Checked;
        }


        public static void GetSupplyReadings(this Form1 view, string writeVoltage, string writeCurrent)
        {

            if (!string.IsNullOrEmpty(writeVoltage) && !string.IsNullOrEmpty(writeCurrent))
            {
                view.VoltageValueReadings.Text = string.Empty;
                view.VoltageValueReadings.Text = writeVoltage;
                view.CurrentValueReadings.Text = string.Empty;
                view.CurrentValueReadings.Text = writeCurrent;
                if (ValidateLoad(writeVoltage, writeCurrent, out double[] result))
                {
                    var voltage = result[0];
                    var current = result[1];
                    view.PowerValueReadings.Text = DescriptionСalculations.GetPower(voltage, current);
                }
            }
            else
            {
                view.CurrentValueReadings.Text = string.Empty;
                view.VoltageValueReadings.Text = string.Empty;
                view.PowerValueReadings.Text = string.Empty;
                view.StatusButtonOn("Output", false);
            }
        }

        static bool ValidateLoad(string valueVoltage, string valueCurrent, out double[] result)
        {
            result = new double[2];
            if (!double.TryParse(valueVoltage.Replace(",", "."),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out result[0]))
            {
                return false;
            }
            if (!double.TryParse(valueCurrent.Replace(",", "."),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out result[1]))
            {
                return false;
            }
            return true;
        }

        public static void WriteMeterValues(this Form1 view, string name, string value )
        {
            view.GetComponent<TextBox>(name).Text = value;
        }
    }
}