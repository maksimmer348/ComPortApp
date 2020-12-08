using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ComPortSettings.ComPort;
using ComPortSettings.MVC;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace ComPortSettings
{

    public class MainFormController : Controller<Form1>
    {
        ComConfigsSerializer CCS = new ComConfigsSerializer();

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static int alarmCounter = 1;

        public MainFormController(Form1 view) : base(view)
        {

            View.OpenSettings += () => OpenSettings(); //ттак можно избежать требований сигнатуры метода при вызове экшана
            View.OutputLoad += Output;
        }

        protected override void OnClosed()
        {
            View.OutputLoad -= Output;
            View.OpenSettings -= () => OpenSettings();
            myTimer.Tick -= new EventHandler(TimerEventProcessor);
            myTimer.Stop();
        }
        protected override void OnShown()
        {
            Deserialize();
            StartSettings();
            SetTimer();
            myTimer.Start();
        }


        private void OpenSettings(int startTab = 0)
        {
            ComSettingsController comSettingsController = new ComSettingsController(new ComSettings(), this);

            if (startTab == 0)
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
            return await CommandToFormSupply(cmd,extraDelayOn: true);
        }

       
        public async void Output()
        {
            View.Output.Enabled = false;
            myTimer.Stop();
            await Task.Delay(500);
            string ss = await BtnStat("Get Output");
            if (ss == "1")
            {
                await CommandToFormSupply("Output", "0");

                Buttondriver();
            }
            else if (ss == "0")
            {
                await CommandToFormSupply("Output", "1");

                View.ButtonConected();
            }
             Debug.WriteLine(ss);
             myTimer.Start();
             View.Output.Enabled = true;
        }


        private async void StartSettings()
        {
            await CommandToFormSupply("Output", "0");
            View.ButtonDisconected();
        }

        public async void UpdateValues()
        {
            View.ReadToCom(await CommandToFormSupply("Return voltage",extraDelayOn: false),
                await CommandToFormSupply("Return current", extraDelayOn: false));
        }

        public async Task<string> CommandToFormSupply(string cmd, string param = null, bool extraDelayOn = false)
        {
            try
            {
                return await Service<ComPorts>.Get().Supply
                    .Write(Service<SupplyLib>.Get().GetCommand(cmd, param), extraDelayOn: extraDelayOn);
            }
            catch (Exception e)
            {
                ErrorMsgSupply();
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

        void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            UpdateValues();
        }

        void SetTimer()
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 500;
        }
    }
}

