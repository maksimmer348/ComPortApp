using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ComPortSettings.ComPort;
using ComPortSettings.MVC;
using System.Timers;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using Timer = System.Windows.Forms.Timer;
using View = ComPortSettings.MVC.View;

namespace ComPortSettings
{

    public class MainFormController : Controller<Form1>
    {
        ComConfigsSerializer CCS = new ComConfigsSerializer();
        static Timer myTimer = new Timer();
        static Timer TimerMesaure = new Timer();
        public bool SetValue;

        public MainFormController(Form1 view) : base(view)
        {
            View.OpenSettings += () => OpenSettings(); //ттак можно избежать требований сигнатуры метода при вызове экшана
            View.OutputLoad += Output;
            View.SetValues += SetValues;
            View.StartMesaure += StartMesauring;
        }

        void TimerCalculate(int hour, int minute, int second)
        {
            //var ss = new TimeSpan(hour, minute, second);
                //var ff = ss.TotalSeconds;
            TimerMesaure.Tick += new EventHandler(TimesMesauring);
            TimerMesaure.Interval = 1000;
            TimerMesaure.Start();

               
        }

        void TimesMesauring(Object myObject, EventArgs myEventArgs)
        {
            View.SafeGetComponent<TextBox>("VoltageValueWrite").Text += "1";
        }


        private void StartMesauring()
        {
            TimerCalculate(0, 0, 10);
        }

        protected override void OnClosed()
        {
            View.OutputLoad -= Output;
            //View.OpenSettings -= () => OpenSettings(); todo исправить на рабочее
            myTimer.Tick -= new EventHandler(TimerEventProcessor);
            myTimer.Stop();
            View.StartMesaure += StartMesauring;
        }


            async Task ValidateValue()
            {
                if (!double.TryParse(View.SafeGetComponent<TextBox>("VoltageValueWrite").Text.Replace(",", "."),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double volResult))
                {
                    MessageBox.Show(
                        $"Введите допустимое числовое значение {(string)View.SafeGetComponent<TextBox>("VoltageValueWrite").Tag}",
                        "Error Value Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(View.SafeGetComponent<TextBox>("CurrentValueWrite").Text.Replace(",", "."),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double currResult))
                {
                    MessageBox.Show(
                        $"Введите допустимое числовое значение {(string)View.SafeGetComponent<TextBox>("CurrentValueWrite").Tag}",
                        "Error Value Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await CommandToFormSupply("Output", "0");
                View.StatusButtonOn("Output", false);
                CommandToFormSupply("Set voltage", volResult.ToString());
                CommandToFormSupply("Set current", currResult.ToString());
            }


        private async void SetValues()
        {

            View.StatusButtonEnable("SetValue", false);

            myTimer.Stop();

            await Task.Delay(500);
               
            await ErrorMsgSupply(true);

            await ValidateValue();

            SetValue = true;

            myTimer.Start();

            View.StatusButtonEnable("SetValue", true);
        }

        protected override void OnShown()
        {
            Deserialize();
            StartSettings();
            SetValue = true;
            SetTimer();
            myTimer.Start();
        }

        private async void StartSettings()
        {
            await ErrorMsgSupply(true);
            await CommandToFormSupply("Output", "0");
            View.StatusButtonOn("Output", false);
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
            //todo исправить 
            View.Output.Enabled = false;
           
            myTimer.Stop();
            await Task.Delay(500);
            var cmd = await ErrorMsgSupply(true, "Get Output");

            switch (cmd)
            {
                case "1":
                    await CommandToFormSupply("Output", "0");
                    View.StatusButtonOn("Output",false);
                    SetValue = true;
                    break;
                case "0":
                    await CommandToFormSupply("Output", "1");
                    View.StatusButtonOn("Output", true);
                    SetValue = false;
                    break;
            }
             Debug.WriteLine(cmd);
             myTimer.Start();
             //todo исправить 
            View.Output.Enabled = true;
        }


      

        public async void UpdateValues(bool set = false)
        {
            if (!set)
            {
                View.ReadToCom(await CommandToFormSupply("Return voltage", extraDelayOn: false),
                    await CommandToFormSupply("Return current", extraDelayOn: false));
            }

            if (set)
            {
                View.ReadToCom(await CommandToFormSupply("Return set voltage", extraDelayOn: false),
                    await CommandToFormSupply("Return set current", extraDelayOn: false));
            }
        }


        public async Task<string> CommandToFormSupply(string cmd, string param = null, bool extraDelayOn = false)
        {
            try
            {
                var recieveCmd = await Service<ComPorts>.Get().Supply
                    .Write(Service<SupplyLib>.Get().GetCommand(cmd, param), extraDelayOn: extraDelayOn);

                return recieveCmd;
            }
            catch (Exception e)
            {
                await ErrorMsgSupply();
                return null;
            }
        }

        public async Task<string> CommandToFormMeter(string cmd, string param = null, int delay = 100)
        {
            try
            {
                var recieveCmd = await Service<ComPorts>.Get().Supply
                    .Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay);

                return recieveCmd;
            }
            catch (Exception e)
            {
                ErrorMsgMeter();
                return null;
            }
        }
        //todo сделать один метод error сообщений обеденит и вынести какието части 
        async Task<string> ErrorMsgSupply(bool sendCmd = false, string output = "Get Output")
        {
            myTimer.Stop();
            if (sendCmd)
            {
                var cmd = await BtnStat(output);
                if (cmd != "")
                {
                    myTimer.Start();
                    return cmd;
                }
            }

            string inf = "Блок питания не подключен или настроен неправильно открыть настроки подключения?";
          
            var dialog = MessageBox.Show(inf, "ComPort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                OpenSettings();
            }
            myTimer.Start();
            return null;
        }
        //todo сделать один метод error сообщений обеденит и вынести какието части 
        void ErrorMsgMeter()
        {
            string inf = " Измерительный прибор не подключен или настроен неправильно открыть настроки подключения?";
            var dialog = MessageBox.Show(inf, "ComPort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                OpenSettings(1);
            }
        }

        void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            UpdateValues(SetValue);
        }

     

        void SetTimer()
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 500;
        }
    }
}

