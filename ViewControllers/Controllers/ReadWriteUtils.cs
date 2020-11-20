﻿using System.Windows.Forms;
using ComPortSettings.MVC;

namespace ComPortSettings
{
    public static class ReadWriteUtils
    {
        /// <summary>
        /// запись из ComPort в ComboBox для блока питания
        /// </summary>
        public static void WriteSupply(this ComSettings view,ComConfig cfg)
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
        public static void WriteMeter(this ComSettings view, ComConfig cfg)
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
        public static ComConfig ReadSupply(this ComSettings view)
        {
            return new ComConfig()
            {
                ChannelNum = int.Parse((string)view.ChannelComSupply.SelectedItem),
                BaudRate = int.Parse((string)view.BaudRateSupply.SelectedItem),
                ParityBit = int.Parse((string)view.ParityBitSupply.SelectedItem),
                StopBits = int.Parse((string)view.StopBitsSupply.SelectedItem),
                DTR = view.DtrSupply.Checked,
            };

        }
        /// <summary>
        /// запись из ComboBox в ComPort для измерителя
        /// </summary>
        public static ComConfig ReadMeter(this ComSettings view)
        {
            return new ComConfig()
            {
                ChannelNum = int.Parse((string)view.ChannelComMeter.SelectedItem),
                BaudRate = int.Parse((string)view.BaudRateMeter.SelectedItem),
                ParityBit = int.Parse((string)view.ParityBitMeter.SelectedItem),
                StopBits = int.Parse((string)view.StopBitsMeter.SelectedItem),
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

       
        
}
}