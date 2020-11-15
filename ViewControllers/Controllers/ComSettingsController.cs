using System;
using System.IO;
using System.Net.Security;
using System.Windows.Forms;
using ComPortSettings.MVC;

namespace ComPortSettings
{
    public class ComSettingsController : Controller<ComSettings>
    {

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
        protected override void OnClosed()
        {
            ComConfig[] configs = { View.ReadSupply(), View.ReadMeter() };

            var serializer = new ComConfigsSerializer();
            serializer.Serialize(configs);
            OnShown();
        }

        void DefaultSettingsSupply()
        {
            View.WriteSupply(ComConfig.DefaultSupply);
        }

        void DefaultSettingsMeter()
        {
            View.WriteMeter(ComConfig.DefaultMeter);
        }

        void TestSupply()
        {

        }
        void TestMeter()
        {

        }
        private void CancelSettings()
        {
            
        }

        private void OkSettings()
        {
            
        }

    }
}