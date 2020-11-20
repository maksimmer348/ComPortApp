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


        public ComSettingsController(ComSettings view) : base(view)
        {
            View.ResetSupply += DefaultSettingsSupply;
            View.ResetMeter += DefaultSettingsMeter;
            View.TestSupply += TestSupply;
            View.TestMeter += TestMeter;
            View.Ok += OkSettings;
            View.Cancel += CancelSettings;
        }




        protected override void OnShown()
        {

            var serializer = new ComConfigsSerializer();


            if (File.Exists("Settings.json"))
            {
                var configs = serializer.Deserialize();

                View.WriteSupply(configs[0]);
                View.WriteMeter(configs[1]);

            }


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

                    await Service<ComPorts>.Get().Supply.Write(":chan1: curr ?", 100);

                    if ((await Service<ComPorts>.Get().Supply.Write(":chan1: curr ?", 100)).Contains("."))
                    {
                        View.ButtonConected();
                    }
                    else
                    {

                        View.ButtonDisconected();
                    }

                    //TODO сделать для Supply
                    //string ss = await Service<ComPorts>.Get().Supply.Write(":chan1: curr ?");
                    // 
                    // View.ReceivingInformation.Text += ss.Trim(MyChar);
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ComPort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!View.ValidatePorts())
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

            if (!View.ValidatePorts())
            {
                MessageBox.Show("Номера портов не должны совпадать", "ComPort", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void CancelSettings()
        {
            OnShown();
            View.Close();
        }

        private void OkSettings()
        {

            if (View.ValidatePorts())
            {
                Service<ComPorts>.Get().Supply.Close();
                Service<ComPorts>.Get().Meter.Close();

                ComConfig[] configs = {View.ReadSupply(), View.ReadMeter()};
                ReadWriteUtils.ValidatePorts(View);
                var serializer = new ComConfigsSerializer();
                serializer.Serialize(configs);

                Service<ComPorts>.Get().Supply.Open(configs[0]);
                Service<ComPorts>.Get().Meter.Open(configs[1]);


                View.Close();
            }

            if (!View.ValidatePorts())
            {
                MessageBox.Show("Номера портов не должны совпадать", "ComPort", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

        }

        public bool ValidateTest()
        {
            string meterPort = new string(Service<ComPorts>.Get().Meter.port.PortName.Where(c => Char.IsDigit(c)).ToArray());
            string supplyPort = new string(Service<ComPorts>.Get().Meter.port.PortName.Where(c => Char.IsDigit(c)).ToArray());

            if (int.Parse(meterPort) == View.ReadSupply().ChannelNum)
            {
                return false;
            }
            else if (int.Parse(supplyPort) == View.ReadMeter().ChannelNum)
            {
                return false;
            }
            return true;
        }

    }
}