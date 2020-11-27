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
            View.UpdateTest += UpdateValues;
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

        private async Task<string> 
            BtnStat(string cmd)
        {
            await CommandToFormSupply("Output");
                 return await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand(cmd), 100);
        }
        protected override void OnShown()
        {
            Deserialize();
        }

        public async void Output()
        {
            string param = String.Empty;

            if (await BtnStat("Get Output") == "1")
            {
                param = "0";
                View.ButtonDisconected();
            }
            if (await BtnStat("Get Output") == "0")
            {
                param = "1";
                View.ButtonConected();
               
            }
            await CommandToFormSupply("Output", param);
        }

        private async void StartSettings()
        {
            await CommandToFormSupply("Output", "0");
            View.ButtonDisconected();
        }

        async void UpdateValues()
        {
            View.ReadToCom(await CommandToFormSupply("Return voltage"), await CommandToFormSupply("Return current"));
        }

        public async Task<string>CommandToFormSupply(string cmd, string param = null, int delay = 200)
        {
            return await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay);
        }

        public async Task<string> CommandToFormMeter(string cmd, string param = null, int delay = 100)
        {
            return await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay);
        }
    }
}