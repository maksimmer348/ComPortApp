using System;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ComPortSettings.ComPort;
using ComPortSettings.MVC;

namespace ComPortSettings
{

    public class MainFormController : Controller<Form1>
    {

        ComConfigsSerializer CCS = new ComConfigsSerializer();
        CommandLib CLib = new CommandLib();
        private bool CmdFail;

        public MainFormController(Form1 view) : base(view)
        {
            View.OpenSettings += OpenSettings;
            View.OutputLoad += Output;
            View.SetVoltage += SetVoltage;
               //View.UpdateTest += UpdateValues;
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
            comSettingsController.ShowDialog();
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
            return await CommandToFormSupply(cmd);
            //return await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand(cmd), 100);
        }

        protected override void OnShown()
        {

            Deserialize(); 
            
        }

        public async void Output()
        {
           
            //изм6енить задержку
            if (await BtnStat("Get Output") == null)
            {
                return;
                //UpdateValues();
            }
              
            else if(await BtnStat("Get Output") == "1")
            {
                await CommandToFormSupply("Output", "0");
                
                View.ButtonDisconected();
                //UpdateValues();
            }

            else if(await BtnStat("Get Output") == "0")
            {
                await CommandToFormSupply("Output", "1");
                View.ButtonConected();
               
                    //UpdateValues(true);
            }
        }


        private async void StartSettings()
        {
            await CommandToFormSupply("Output", "0");
            View.ButtonDisconected();
            UpdateValues();
        }

        public async void UpdateValues(bool loop = false)
        {
            View.ReadToCom(await CommandToFormSupply("Return voltage", null),
                    await CommandToFormSupply("Return current",null));
                    // await Task.Delay(1000);
        }

        public async Task<string> CommandToFormSupply(string cmd, string param = null, int delay = 500)
        {
            try
            {
                CmdFail = false;
                return await Service<ComPorts>.Get().Supply
                    .Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay);
            }
            catch (Exception e)
            {
                ErrorMsg();
                CmdFail = true;
                return null;
            }
        }

        public async Task<string> CommandToFormMeter(string cmd, string param = null, int delay = 100)
        {
            return await Service<ComPorts>.Get().Supply.Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay);
        }

        void ErrorMsg()
        {
            string inf = "Блок питания не подключен или настроен неправильно открыть настроки подключения?";
            var dialog = MessageBox.Show(inf, "ComPort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
                OpenSettings();
        }
    }
}

