using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComPortSettings.ComPort;
using ComPortSettings.MVC;
using TextBox = System.Windows.Forms.TextBox;
using Timer = System.Windows.Forms.Timer;

namespace ComPortSettings
{

    public class MainFormController : Controller<Form1>
    {
        private ComConfigsSerializer CCS = new ComConfigsSerializer();
        private static Timer MyTimer = new Timer();
        private static Timer TimerMeasuring = new Timer();
        public bool SetValue;
        Stopwatch stopWatch = new Stopwatch();
        public MainFormController(Form1 view) : base(view)
        {
            View.OpenSettings += () => OpenSettings(); //так можно избежать требований сигнатуры метода при вызове экшена
            View.OutputLoad += Output;
            View.SetValues += SetValues;
            View.StartMesaure += StartMesauring;
            View.SelectTabLoad += SetValuesLoad;
        }

     
        protected override void OnClosed()
        {
            View.OutputLoad -= Output;
            //View.OpenSettings -= () => OpenSettings(); todo исправить на рабочее
            MyTimer.Tick -= new EventHandler(TimerEventProcessor);
            MyTimer.Stop();
            View.StartMesaure += StartMesauring;
        }

        protected override void OnShown()
        {
            Deserialize();
            StartSettings();
            SetValue = true;
            SetTimer();
            MyTimer.Start();
        }

       void SetValuesLoad()
       {
           var ss = View.GetTabsPage();
           switch (ss)
           {
               case "SelectTransistor"
                   :
                    //WriteMeterValues()

                    break;
               case "SelectResistor"
                   :
                    //WriteMeterValues()
                    break;
                case "TheirValues"
                   :
                    //WriteMeterValues()
                    Debug.WriteLine("Their values");
                    break;
           }
          
       }

        private async Task SetSupplyValues()
        {
            //View.HoldVoltage
            //View.HoldCurrent
            //View.HoldPower

            if (View.GetSupplyCheckValues("HoldVoltage"))
            {

            }
            else if (View.GetSupplyCheckValues("HoldCurrent"))
            {

            }

            if (View.ValidateText("PowerValueWrite", out var result))
            {
                
            }
            if (View.ValidateText("VoltageValueWrite", out  result))
            {
                await CommandToFormSupply("Set voltage", result.ToString());
            }
            else
            {
                return;
            }
            if (View.ValidateText("CurrentValueWrite", out result))
            {
                await CommandToFormSupply("Set current", result.ToString());
            }
            else
            {
                return;
            }
            await CommandToFormSupply("Output", "0");
            View.StatusButtonOn("Output", false);

        }


        private async void SetValues()
        {

            View.StatusButtonEnable("SetValue", false);

            MyTimer.Stop();

            await Task.Delay(500);

            await ErrorMsgSupply(true);

            await SetSupplyValues();

            SetValue = true;

            MyTimer.Start();

            View.StatusButtonEnable("SetValue", true);
        }


        private async void StartSettings()
        {
            if (!string.IsNullOrEmpty(await ErrorMsgSupply(true)))
            {
                await CommandToFormSupply("Output", "0");
                View.StatusButtonOn("Output", false);
            }
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

        private void Deserialize()
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
            View.StatusButtonEnable("Output", false);


            MyTimer.Stop();
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
             MyTimer.Start();
             View.StatusButtonEnable("Output", true);
        }

        public async void UpdateValues(bool set = false)
        {
            if (!set)
            {
                View.GetSupplyReadings(await CommandToFormSupply("Return voltage", extraDelayOn: false),
                    await CommandToFormSupply("Return current", extraDelayOn: false));
            }

            if (set)
            {
                View.GetSupplyReadings(await CommandToFormSupply("Return set voltage", extraDelayOn: false),
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
            catch (Exception)
            {
                if (!ErrCheck)
                {
                    await ErrorMsgSupply();
                    return null;
                }
                return null;
            }
        }

        public bool ErrCheck;

        public async Task<string> CommandToFormMeter(string cmd, string param = null, int delay = 100)
        {
            try
            {
                var recieveCmd = await Service<ComPorts>.Get().Supply
                    .Write(Service<SupplyLib>.Get().GetCommand(cmd, param), delay);

                return recieveCmd;
            }
            catch (Exception)
            {
                ErrorMsgMeter();
                return null;
            }
        }
        //todo сделать один метод error сообщений обеденит и вынести какието части 
        private async Task<string> ErrorMsgSupply(bool sendCmd = false, string output = "Get Output")
        {
            MyTimer.Stop();
            if (sendCmd)
            {
                ErrCheck = true;
                var cmd = await BtnStat(output);
                if (!string.IsNullOrEmpty(cmd))
                {
                    MyTimer.Start();
                    return cmd;
                }
                ErrCheck = false;
            }

            string inf = "Блок питания не подключен или настроен неправильно открыть настроки подключения?";
          
            var dialog = MessageBox.Show(inf, "ComPort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                OpenSettings();
            }
            MyTimer.Start();
            return null;
        }



        //todo сделать один метод error сообщений обеденит и вынести какието части 
        private void ErrorMsgMeter()
        {
            string inf = " Измерительный прибор не подключен или настроен неправильно открыть настроки подключения?";
            var dialog = MessageBox.Show(inf, "ComPort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                OpenSettings(1);
            }
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            UpdateValues(SetValue);
        }


        private void SetTimer()
        {
            MyTimer.Tick += new EventHandler(TimerEventProcessor);
            MyTimer.Interval = 500;
        }


        private void TimerCalculate(int hour, int minute, int second)
        {
            //var ss = new TimeSpan(hour, minute, second);
            //var ff = ss.TotalSeconds;
            TimerMeasuring.Tick += new EventHandler(TimesMesauring);
            TimerMeasuring.Interval = 1000;
            TimerMeasuring.Start();


        }

        private void TimesMesauring(Object myObject, EventArgs myEventArgs)
        {
            View.GetComponent<TextBox>("VoltageValueWrite").Text += "1";
        }


        private void StartMesauring()
        {
            TimerCalculate(0, 0, 10);
        }



        private void SetTimerMes()
        {
            MyTimer.Tick += new EventHandler(TimerEventProcessor);
            MyTimer.Interval = 1000;
            MyTimer.Start();
        }

    }
}

