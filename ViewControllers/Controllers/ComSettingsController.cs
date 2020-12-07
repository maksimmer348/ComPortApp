using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Windows.Forms;
using ComPortSettings.ComPort;
using ComPortSettings.MVC;

namespace ComPortSettings
{
    public class ComSettingsController : Controller<ComSettings>
    {
        public int SelectedTab = 0;

        public ComSettingsController(ComSettings view, IController host) : base(view, host)
        {
            View.ResetSupply += DefaultSettingsSupply;
            View.ResetMeter += DefaultSettingsMeter;
            View.TestSupply += TestSupply;
            View.TestMeter += TestMeter;
            View.Ok += OkSettings;
            View.Cancel += CancelSettings;
        }

        protected override void OnClosed()
        {
            View.ResetSupply -= DefaultSettingsSupply;
            View.ResetMeter -= DefaultSettingsMeter;
            View.TestSupply -= TestSupply;
            View.TestMeter -= TestMeter;
            View.Ok -= OkSettings;
            View.Cancel -= CancelSettings;
        }

        void DeserializeConfig()
        {
            var serializer = new ComConfigsSerializer();

            if (File.Exists("Settings.json"))
            {
                var configs = serializer.Deserialize();

                var configSupply = configs[0];
                var configMeter = configs[1];
                View.WriteSupply(configSupply);
                View.WriteMeter(configMeter);

            }
        }

        protected override void OnShown()
        {
            DeserializeConfig();
            View.SelectToTab(SelectedTab);
        }

        void DefaultSettingsSupply()
        {
            View.WriteSupply(ComConfig.DefaultSupply);
        }

        void DefaultSettingsMeter()
        {
            View.WriteMeter(ComConfig.DefaultMeter);
        }

        public async void TestSupply()
        {
            if (View.ValidatePorts())
            {
                try
                {
                    Service<ComPorts>.Get().Supply.Close();
                    Service<ComPorts>.Get().Supply.Open(View.ReadSupply());

                    if (!ValidateTest())
                    {
                        Service<ComPorts>.Get().Meter.Close();
                        Service<ComPorts>.Get().Meter.Open(View.ReadMeter());
                    }

                    await Service<ComPorts>.Get().Supply.Write(":outp:stat 0");
                    ((MainFormController) Host).Buttondriver();
                    const string TestCmd = ":outp:stat?";
                    if ((await Service<ComPorts>.Get().Supply.Write(TestCmd, 200)).Contains("null"))
                    {

                    }

                    if ((await Service<ComPorts>.Get().Supply.Write(TestCmd, 200)).Contains("0"))
                    {
                        View.ButtonConected();
                    }
                    else
                    {
                        View.ButtonDisconected();
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ComPort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Номера портов не должны совпадать", "ComPort", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        public async void TestMeter()
        {
            if (View.ValidatePorts())
            {
                try
                {
                    Service<ComPorts>.Get().Meter.Close();
                    Service<ComPorts>.Get().Meter.Open(View.ReadMeter());

                    if (!ValidateTest())
                    {
                        Service<ComPorts>.Get().Supply.Close();
                        Service<ComPorts>.Get().Supply.Open(View.ReadSupply());
                    }

                    if ((await Service<ComPorts>.Get().Meter.Write("V00", 200)).Contains("E"))
                    {
                        View.ButtonConectedMeter();
                    }
                    else
                    {
                        View.ButtonDisconectedMeter();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ComPort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Номера портов не должны совпадать", "ComPort", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void CancelSettings()
        {
            var serializer = new ComConfigsSerializer();

            if (File.Exists("Settings.json"))
            {
                var configs = serializer.Deserialize();
                var configSupply = configs[0];
                var configMeter = configs[1];
                Service<ComPorts>.Get().Supply.Close();
                Service<ComPorts>.Get().Meter.Close();
                Service<ComPorts>.Get().Supply.Open(configSupply);
                Service<ComPorts>.Get().Meter.Open(configMeter);
            }

            OnClosed();
            View.Close();
        }

        private void OkSettings()
        {
            if (View.ValidatePorts())
            {
                Service<ComPorts>.Get().Supply.Close();
                Service<ComPorts>.Get().Meter.Close();

                ComConfig[] configs = {View.ReadSupply(), View.ReadMeter()};

                var serializer = new ComConfigsSerializer();
                serializer.Serialize(configs);

                var configSupply = configs[0];
                var configMeter = configs[1];
                Service<ComPorts>.Get().Supply.Open(configSupply);
                Service<ComPorts>.Get().Meter.Open(configMeter);

                OnClosed();
                View.Close();
            }
            else
            {
                MessageBox.Show("Номера портов не должны совпадать", "ComPort", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

        }

        public bool ValidateTest()
        {
            var meterPort = Service<ComPorts>.Get().Meter.CfgChannelNum;
            var supplyPort = Service<ComPorts>.Get().Supply.CfgChannelNum;

            if (meterPort == View.ReadSupply().ChannelNum || supplyPort == View.ReadMeter().ChannelNum)
            {
                return false;
            }

            return true;
        }

       
}
}