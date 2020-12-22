using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;
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
                View.WriteSupplySettings(configSupply);
                View.WriteMeterSettings(configMeter);

            }
        }

        protected override void OnShown()
        {
            DeserializeConfig();
            View.SelectToTab(SelectedTab);
        }

        void DefaultSettingsSupply()
        {
            View.WriteSupplySettings(ComConfig.DefaultSupply);
        }

        void DefaultSettingsMeter()
        {
            View.WriteMeterSettings(ComConfig.DefaultMeter);
        }

        public async void TestSupply()
        {
            if (View.ValidatePorts())
            {
                try
                {
                    MainFormController.MyTimer.Stop();
                    View.StatusButtonEnable("TestComSupply", false);
                    Service<ComPorts>.Get().Supply.Close();
                    Service<ComPorts>.Get().Supply.Open(View.ReadSupplySettings());

                    if (!ValidateTest())
                    {
                        Service<ComPorts>.Get().Meter.Close();
                        Service<ComPorts>.Get().Meter.Open(View.ReadMeterSettings());
                    }
                    await Service<ComPorts>.Get().Supply.Write(":outp:stat 0",300);
                    ((MainFormController) Host).View.StatusButtonOn("Output", false);
                   
                    var ss =  await Service<ComPorts>.Get().Supply.Write(":syst:vers?", 300);

                    if (ss.Contains("."))
                    {
                        View.StatusButtonOn("TestCheckSup", true);
                        View.StatusButtonEnable("TestComSupply", true);
                    }
                    else if (string.IsNullOrEmpty(ss))
                    {
                        View.StatusButtonOn("TestCheckSup", false);
                        View.StatusButtonEnable("TestComSupply", true);
                    }
                    MainFormController.SetValue = true;
                    MainFormController.MyTimer.Start();
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
                    Service<ComPorts>.Get().Meter.Open(View.ReadMeterSettings());

                    if (!ValidateTest())
                    {
                        Service<ComPorts>.Get().Supply.Close();
                        Service<ComPorts>.Get().Supply.Open(View.ReadSupplySettings());
                    }
                    await Task.Delay(200);
                    if ((await Service<ComPorts>.Get().Meter.Write("V00")).Contains("E"))
                    {
                        View.StatusButtonOn("TestCheckMet", true);
                       // View.ButtonConectedMeter();
                    }
                    else
                    {
                        View.StatusButtonOn("TestCheckMet", false);
                        //View.ButtonDisconectedMeter();
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

                ComConfig[] configs = {View.ReadSupplySettings(), View.ReadMeterSettings()};

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

            if (meterPort == View.ReadSupplySettings().ChannelNum || supplyPort == View.ReadMeterSettings().ChannelNum)
            {
                return false;
            }

            return true;
        }

       
}
}