using System;
using System.Windows.Forms;
using ComPortSettings.ComPort;
using ComPortSettings.MVC;

namespace ComPortSettings
{
    public class MainFormController : Controller<Form1>
    {
        ComConfigsSerializer CCS = new ComConfigsSerializer();

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

        protected override void OnShown()
        {
            Service<ComPorts>.Get().Supply.Open(CCS.Deserialize()[0]);
            Service<ComPorts>.Get().Meter.Open(CCS.Deserialize()[1]);
        }

        public async void Output()
        {
            try
            {
                await Service<ComPorts>.Get().Supply
                    .Write(Service<MeterLib>.Get().GetCommand(View.Output.Tag.ToString()));

                if ((await Service<ComPorts>.Get().Supply.Read()).Contains("R"))
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
                MessageBox.Show(e.Message);
            }

        }
    }
}