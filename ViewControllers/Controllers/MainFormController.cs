using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComPortSettings.ComPort;
using ComPortSettings.MVC;

namespace ComPortSettings
{

    public class MainFormController : Controller<Form1>
    {

        ComConfigsSerializer CCS = new ComConfigsSerializer();
        CommandLib CLib = new CommandLib();

        public MainFormController(Form1 view) : base(view)
        {
            View.OpenSettings += OpenSettings;
            View.OutputLoad += Output;
            View.SetVoltage += SetVoltage;
            //View.SetCurrent += 
        }

        private void SetVoltage()
        {

        }

        protected override void OnClosed()
        {
            View.OpenSettings -= OpenSettings;
        }

        private void OpenSettings()
        {
            var comSettingsController = new ComSettingsController(new ComSettings());
            comSettingsController.Show();
        }

        void Deserialize()
        {
            var configSupply = CCS.Deserialize()[0];
            var configMeter = CCS.Deserialize()[1];
            Service<ComPorts>.Get().Supply.Open(configSupply);
            Service<ComPorts>.Get().Meter.Open(configMeter);
            StartSettings();
        }

        private async Task<string> BtnStat(string cmd)
        {
             return await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand(cmd), 100);
        }
        protected override void OnShown()
        {
            Deserialize();
        }

        public async void Output()
        {
            string param = String.Empty;

            if (await BtnStat("Get Output") == "1\n")
            {
                param = "0";
                View.ButtonDisconected();
            }
            if (await BtnStat("Get Output") == "0\n")
            {
                param = "1";
                View.ButtonConected();
               
            }
            await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand("Output", param), 100);
        }

        private async void StartSettings()
        {
            await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand("Output", "0"), 100);
            View.ButtonDisconected();
        }
    }
}