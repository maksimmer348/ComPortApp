using System;
using System.Windows.Forms;

namespace ComPortApp
{
    public class ComConfig
    {
        public ComCommunication CC = new ComCommunication();

        private string Name;
        public ComConfig(string name)
        {
            Name = name;
        }

        private ComboBox CannelComBox;
        private ComboBox BaudRateBox;
        private ComboBox ParityBitbox;
        private ComboBox StopBitsBox;
        private ComboBox FlovControl;
        private CheckBox DtrBox;

        private string[] cannelNum = new[] {"1", "2", "3", "4"};
        private string[] baudRate = new[] {"2400", "9600"};
        private string[] parityBit = new[] {"0", "1"};
        private string[] stopBits = new[] {"0", "1"};
        private string[] flovControl = new[] { "on", "off" };

        public void RestoreForm(ComboBox cannelComBox, ComboBox baudRateBox, ComboBox parityBitbox, ComboBox stopBitsBox, ComboBox flovControlBox, CheckBox dtr)
        {
            CannelComBox = cannelComBox;
            BaudRateBox =  baudRateBox;
            ParityBitbox = parityBitbox;
            StopBitsBox = stopBitsBox;
            FlovControl = flovControlBox;
            DtrBox = dtr;

            AddCountSettings(CannelComBox, cannelNum);
            AddCountSettings(BaudRateBox, baudRate);
            AddCountSettings(ParityBitbox, parityBit);
            AddCountSettings(StopBitsBox, stopBits);
            AddCountSettings(FlovControl, flovControl);
        }

        private void AddCountSettings(ComboBox box, string[] adds)
        {
            box.Items.AddRange(adds);
            box.Text = adds[0];
        }
       
            public void DefaultConfCom()
        {
            if (Name == "Supply")
            {
                CannelComBox.SelectedIndex = (int) DefaultSettings.defCanSup;
                BaudRateBox.SelectedIndex = (int) DefaultSettings.defBRSup;
                ParityBitbox.SelectedIndex = (int) DefaultSettings.defParSup;
                StopBitsBox.SelectedIndex = (int) DefaultSettings.defStopSup;
                DtrBox.CheckState = CheckState.Checked;
                ApplySettings();


            }
            if (Name == "Meter")
            {
                CannelComBox.SelectedIndex = (int)DefaultSettings.defCanMet;
                BaudRateBox.SelectedIndex = (int)DefaultSettings.defBRMet;
                ParityBitbox.SelectedIndex = (int)DefaultSettings.defParMet;
                StopBitsBox.SelectedIndex = (int)DefaultSettings.defStopMet;
                DtrBox.CheckState = CheckState.Unchecked;
                ApplySettings();
            }
        }

        public void ApplySettings()
        {
            CC.NumPort = Int32.Parse(CannelComBox.Text);
            CC.BaudRate = Int32.Parse(BaudRateBox.Text);
            CC.Dtr = DtrBox.Checked;

        }
        public void CancelSettings()
        {
            CannelComBox.Text = CC.NumPort.ToString();
            BaudRateBox.Text = CC.BaudRate.ToString();
            DtrBox.Checked = CC.Dtr;
        }
        public void TestSettings(TextBox send, RichTextBox recieve)
        {
            CC.Data = send.Text;
            CC.ComInit();
            recieve.Text = CC.Buffer;
        }

        // CC.data = SendToCom.Text;
        //CSM.CC.ComInit();
        //ReceivingInformation.Text = CSM.CC.Buffer;

    }
}