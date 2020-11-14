using System;
using System.IO;
using System.Net.Security;
using ComPortSettings.MVC;

namespace ComPortSettings
{
    public class ComSettingsController : Controller<ComSettings>
    {
        
        public ComSettingsController(ComSettings view) : base(view)
        {
        }

        protected override void OnShown()
        {
            var serializer = new ComConfigsSerializer();

            if (File.Exists("Settings.json"))
            {
                var configs = serializer.Deserialize(File.OpenRead("Settings.json"));

                WriteSupply(configs[0]);
                WriteMeter(configs[1]);

            }
            
        }

        void WriteSupply(ComConfig cfg)
        {
            View.ChannelComSupply.Text = cfg.ChannelNum.ToString();
            View.BaudRateSupply.Text   = cfg.BaudRate.ToString();
            View.ParityBitSupply.Text  = cfg.ParityBit.ToString();
            View.StopBitsSupply.Text   = cfg.StopBits.ToString();
            View.DtrSupply.Checked     = cfg.DTR;
        }

        void WriteMeter(ComConfig cfg)
        {
            View.ChannelComMeter.Text = cfg.ChannelNum.ToString();
            View.BaudRateMeter.Text   = cfg.BaudRate.ToString();
            View.ParityBitMeter.Text  = cfg.ParityBit.ToString();
            View.StopBitsMeter.Text   = cfg.StopBits.ToString();
            View.DtrMeter.Checked     = cfg.DTR;
        }

        ComConfig ReadSupply()
        {
            return new ComConfig()
            {
                ChannelNum = int.Parse((string)View.ChannelComSupply.SelectedItem),
                BaudRate   = int.Parse((string)View.BaudRateSupply.SelectedItem),
                ParityBit  = int.Parse((string)View.ParityBitSupply.SelectedItem),
                StopBits   = int.Parse((string)View.StopBitsSupply.SelectedItem), 
                DTR        = View.DtrSupply.Checked,
            };
            
        }

        ComConfig ReadMeter()
        {
            return new ComConfig()
            {
                ChannelNum = int.Parse((string)View.ChannelComMeter.SelectedItem),
                BaudRate   = int.Parse((string)View.BaudRateMeter.SelectedItem),
                ParityBit  = int.Parse((string)View.ParityBitMeter.SelectedItem),
                StopBits   = int.Parse((string)View.StopBitsMeter.SelectedItem),
                DTR        = View.DtrMeter.Checked,
            };
        }

        protected override void OnClosed()
        {
            ComConfig[] configs = {ReadSupply(), ReadMeter()};

            var serializer = new ComConfigsSerializer();

            if (File.Exists("Settings.json"))
            {
                serializer.Serialize(File.OpenWrite("Settings.json"),configs);
            }

        }
    }
}