using System;
using System.Drawing;
using System.IO;
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
            try
            {
                View.WriteSupply(View.ReadSupply());
                if ((await Service<ComPorts>.Get().Supply.Write("V00")).Contains("E"))
                {
                    View.ButtonConected();
                }
                else
                {
                    View.ButtonDisconected();
                }
                //TODO сделать для Supply
                //string ss = await Service<ComPorts>.Get().Supply.Write(":chan1: curr ?");
                // char MyChar = '\n';
                // View.ReceivingInformation.Text += ss.Trim(MyChar);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ComPort", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void TestMeter()
        {
            try
            {
                //View.WriteMeter(View.ReadMeter());
                if ((await Service<ComPorts>.Get().Meter.Write("V00")).Contains("E"))
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

        private void CancelSettings()
        {
            View.Close();
        }

        private void OkSettings()
        {
            Service<ComPorts>.Get().Supply.Close();
            Service<ComPorts>.Get().Meter.Close();

            ComConfig[] configs = {View.ReadSupply(), View.ReadMeter()};
            View.Calc();
            var serializer = new ComConfigsSerializer();
            serializer.Serialize(configs);

            Service<ComPorts>.Get().Supply.Open(configs[0]);
            Service<ComPorts>.Get().Meter.Open(configs[1]);


            View.Close();
        }

    }
}