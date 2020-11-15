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
        ComCommunication comCommSupply = new ComCommunication();
        ComCommunication comCommMeter = new ComCommunication();

        public ComSettingsController(ComSettings view) : base(view)
        {
            View.ResetSupply += DefaultSettingsSupply;
            View.ResetMeter  += DefaultSettingsMeter;
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

        public void TestSupply()
        {
            Service<ComPorts>.Get().Supply.Write("L");

            if (Service<ComPorts>.Get().Supply.Read().Contains("V"))
            { 
                View.TestCheckSup.ForeColor = Color.Green;
            }
            else
            {
                View.TestCheckSup.ForeColor = Color.Red;
            }
        }

        void TestMeter()
        {
            Service<ComPorts>.Get().Meter.Write("L");

            if (Service<ComPorts>.Get().Supply.Read().Contains("V"))
            {
                View.TestCheckSup.ForeColor = Color.Green;
            }
            else
            {
                View.TestCheckSup.ForeColor = Color.Red;
            }
        }
        private void CancelSettings()
        {
            View.Close();
        }

        private void OkSettings()
        {
            ComConfig[] configs = { View.ReadSupply(), View.ReadMeter() };

            var serializer = new ComConfigsSerializer();
            serializer.Serialize(configs);
            //OnShown();
            
            View.Close();
        }

    }
}