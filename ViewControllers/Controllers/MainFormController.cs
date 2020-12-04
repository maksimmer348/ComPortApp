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
        private bool Error;

        public MainFormController(Form1 view) : base(view)
        {
            
            View.OpenSettings += () => OpenSettings();//ттак можно избежать требований сигнатуры метода при вызове экшана
            View.OutputLoad += Output;
            View.SetVoltage += SetVoltage;
        }

        private void SetVoltage()
        {

        }

        protected override void OnClosed()
        {
            View.OutputLoad -= Output;
            View.SetVoltage -= SetVoltage;
        }

        private void OpenSettings(int startTab = 0)
        {
            ComSettingsController comSettingsController = new ComSettingsController(new ComSettings(), this);

            if (startTab ==0)
            {
                comSettingsController.SelectedTab = 0;
            }
            if (startTab == 1)
            {
                comSettingsController.SelectedTab = 1;
            }
            comSettingsController.ShowDialog();

        }

        void Deserialize()
        {
            var configSupply = CCS.Deserialize()[0];
            var configMeter = CCS.Deserialize()[1];
            Service<ComPorts>.Get().Supply.Open(configSupply);
            Service<ComPorts>.Get().Meter.Open(configMeter);
        }

        private async Task<string> BtnStat(string cmd)
        {
            return await CommandToFormSupply(cmd);

        }

        protected override void OnShown()
        {
            Deserialize();
            StartSettings();
        }

        public async void Output()
        {

            UpdateValues(true);
            if (await BtnStat("Get Output") == null)
            {
                return;

            }

            else if (await BtnStat("Get Output") == "1")
            {
                await CommandToFormSupply("Output", "0");

                Buttondriver();
            }

            else if (await BtnStat("Get Output") == "0")
            {
                await CommandToFormSupply("Output", "1");
                View.ButtonConected();
            }
            
        }


        private async void StartSettings()
        {
            await CommandToFormSupply("Output", "0");
            await CommandToFormMeter("Output", "0");
            View.ButtonDisconected();
            //UpdateValues();
        }

        public async void UpdateValues(bool cancelCmd = false, bool loop = true)
        {
            //todo сдклать таймером
            View.ReadToCom(await CommandToFormSupply("Return voltage", Cnclcmd: cancelCmd, delay: 500),
                    await CommandToFormSupply("Return current", Cnclcmd: cancelCmd, delay: 500));
                await Task.Delay(200);
        }

        public async Task<string> CommandToFormSupply(string cmd, string param = null, int delay = 200,bool Cnclcmd = false)
        {
            try
            {
                return await Service<ComPorts>.Get().Supply
                    .Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay, Cnclcmd);
                Error = false;
            }
            catch (Exception e)
            {
                ErrorMsgSupply();
                Error = true;
                return null;
            }
        }

        public async Task<string> CommandToFormMeter(string cmd, string param = null, int delay = 100)
        {
            try
            {
                return await Service<ComPorts>.Get().Supply
                    .Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay);
            }
            catch (Exception e)
            {
                ErrorMsgMeter();
                Error = true;
                return null;
            }
        }

        void ErrorMsgSupply()
        {
            string inf = "Блок питания не подключен или настроен неправильно открыть настроки подключения?";
            var dialog = MessageBox.Show(inf, "ComPort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                OpenSettings();
            }
               
        }

        void ErrorMsgMeter()
        {
            string inf = " Измерительный прибор не подключен или настроен неправильно открыть настроки подключения?";
            var dialog = MessageBox.Show(inf, "ComPort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                OpenSettings(1);
            }
                
        }

        public void Buttondriver()
        {
            View.ButtonDisconected();
        }
    }
}

