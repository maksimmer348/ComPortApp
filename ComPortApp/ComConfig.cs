using System;
using System.Windows.Forms;

namespace ComPortApp
{
    public class ComConfig
    {
        private string Name;
        public ComConfig(string name)
        {
            Name = name;
        }


        private ComboBox CannelComBox;
        private ComboBox BaudRateBox;
            private ComboBox StopBitsBox;


        public ComCommunication CC = new ComCommunication();

        private string[] cannelNum = new[] {"1", "2", "3", "4"};

        private string[] baudRate = new[] {"2400", "9600"};

        private string[] parityBit = new[] {"0", "1"};

        private string[] stopBits = new[] {"0", "1"};

        //private bool flowContr = false;

        private bool dtrEnable;


        public void RestoreForm(ComboBox cannelComBox, ComboBox baudRateBox, ComboBox stopBitsBox)
        {
            CannelComBox = cannelComBox;
            BaudRateBox =  baudRateBox;
            StopBitsBox = stopBitsBox;
            AddCountSettings(CannelComBox, cannelNum);
            AddCountSettings(BaudRateBox, baudRate);
            AddCountSettings(StopBitsBox, stopBits);
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
                //StopBitsBox.SelectedIndex = (int)DefaultSettings.def
                //CC.NumPort = 
                //CC.BaudRate = Int32.Parse(baudRate[0]);
                //CC.Parity = Int32.Parse(parityBit[0]);
                //CC.Dtr = true;
            }
            if (Name == "Meter")
            {
                CannelComBox.SelectedIndex = (int)DefaultSettings.defCanMet;
                BaudRateBox.SelectedIndex = (int)DefaultSettings.defBRMet;
                //StopBitsBox.SelectedIndex = (int)DefaultSettings.
                //CC.NumPort = cannelNum[3];
                //CC.BaudRate = Int32.Parse(baudRate[1]);
                //CC.Parity = Int32.Parse(parityBit[0]);
                //CC.Dtr = false;
            }
        }
    }
}