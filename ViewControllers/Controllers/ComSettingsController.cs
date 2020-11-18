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
                if ((await Service<ComPorts>.Get().Supply.Write("L")).Contains("V"))
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

        public async void TestMeter()
        {
            try
            {
                if ((await Service<ComPorts>.Get().Supply.Write("V00")).Contains("R"))
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

        private void CancelSettings()
        {
            View.Close();
        }

        private void OkSettings()
        {
            ComConfig[] configs = {View.ReadSupply(), View.ReadMeter()};

            var serializer = new ComConfigsSerializer();
            serializer.Serialize(configs);
            //OnShown();

            View.Close();
        }

    }
}