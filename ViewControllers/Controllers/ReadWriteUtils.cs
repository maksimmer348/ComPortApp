using System;
using System.Globalization;
using System.Windows.Forms;

namespace ComPortSettings
{
    public static class ReadWriteUtils
    {
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

        public static IndicatorDataWriteS WriteSupply(this Form1 view, double[] val)
        {
            return new IndicatorDataWriteS()
            {
                WriteVoltage = val[0],
                WriteCurrent = val[1],
                //WritePower = val[2]
            };
        }

        public static void Temp()
        {
           
            //todo вынести в отдельны метод  валидации
            if (!double.TryParse(View.GetParams()[0].Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture,
                out double volResult))
            {
                MessageBox.Show("Введите допустимое числовое значение напряжения", "Supply Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                View.SetValue.Enabled = true;
                return;
            }

            if (!double.TryParse(View.GetParams()[1].Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture,
                out double currResult))
            {
                MessageBox.Show("Введите допустимое числовое значение тока", "Supply Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                View.SetValue.Enabled = true;
                return;
            }

            //if (!double.TryParse(View.WriteToCom()[2].Replace(",", "."), NumberStyles.Any,
            //    CultureInfo.InvariantCulture,
            //    out double powResult))
            //{
            //    MessageBox.Show("Введите допустимое числовое значение мощности");
            //    return;
            //}
            double[] val = { volResult, currResult };
            View.WriteSupply(val);
            //await CommandToFormSupply("Return voltage", volResult.ToString(),extraDelayOn: false),
            //await CommandToFormSupply("Return current", currResult.ToString(), extraDelayOn: false));
        }
    }
}