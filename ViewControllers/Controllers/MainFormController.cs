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

        void Deserialize()
        {
            Service<ComPorts>.Get().Supply.Open(CCS.Deserialize()[0]);
            Service<ComPorts>.Get().Meter.Open(CCS.Deserialize()[1]);
        }
        protected override void OnShown()
        {
            Deserialize();
        }

        public async void Output()
        {
            //TODO сделать для Supply
            //string ss = await Service<ComPorts>.Get().Supply.Write(":chan1: curr ?");
            // 
            // View.ReceivingInformation.Text += ss.Trim(MyChar);
            try
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}