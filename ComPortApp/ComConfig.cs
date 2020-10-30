using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ComPortApp
{
    public class ComConfig
    {
        public ComCommunication CC = new ComCommunication();
        SerDeser serDeser = new SerDeser();

        public string Name;

        public ComConfig(string name)
        {
            //хорошее ли решение с экземплярами для supply и meter?
            Name = name;
        }

        //может в структуру?
        [JsonIgnore]
        public ComboBox CannelComBox;
        [JsonIgnore]
        public ComboBox BaudRateBox;
        [JsonIgnore]
        public ComboBox ParityBitbox;
        [JsonIgnore]
        public ComboBox StopBitsBox;
        [JsonIgnore]
        public ComboBox FlovControl;
        [JsonIgnore]
        private CheckBox DtrBox;

        private string[] cannelNum = new[] {"1", "2", "3", "4"};
        private string[] baudRate = new[] {"2400", "9600"};
        private string[] parityBit = new[] {"0", "1"};
        private string[] stopBits = new[] {"0", "1"};

        private string[] flovControl = new[] {"on", "off"};
        //может в структуру?

        public void RestoreForm(ComboBox cannelComBox, ComboBox baudRateBox, ComboBox parityBitbox,
            ComboBox stopBitsBox, ComboBox flovControlBox, CheckBox dtr)
        {
            CannelComBox = cannelComBox;
            BaudRateBox = baudRateBox;
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
            //хорошее ли решение с экземплярами для supply и meter?
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
                CannelComBox.SelectedIndex = (int) DefaultSettings.defCanMet;
                BaudRateBox.SelectedIndex = (int) DefaultSettings.defBRMet;
                ParityBitbox.SelectedIndex = (int) DefaultSettings.defParMet;
                StopBitsBox.SelectedIndex = (int) DefaultSettings.defStopMet;
                DtrBox.CheckState = CheckState.Unchecked;
                ApplySettings();
            }
        }

        public void ApplySettings()
        {
            CC.NumPort = Int32.Parse(CannelComBox.Text);
            CC.BaudRate = Int32.Parse(BaudRateBox.Text);
            CC.Dtr = DtrBox.Checked;
            CC.ComInit();
        }
        public void UnApplySettings()
        {
            CannelComBox.Text = CC.NumPort.ToString();
            //CC.BaudRate = Int32.Parse(BaudRateBox.Text);
            DtrBox.Checked = CC.Dtr;
            CC.ComInit();
        }
        public void CancelSettings()
        {
            CannelComBox.Text = CC.NumPort.ToString();
            BaudRateBox.Text = CC.BaudRate.ToString();
            DtrBox.Checked = CC.Dtr;
        }
      
        public void TestCommunication(Button bt)
        {
            if (Name == "Supply")
            {
                //переделать под два класса и чтобы кнопка блочилась на время выполнения ком врайта
                CC.ComWrite("L");
                //вожномжно переделать пока провожу тесты меня это утсраивает 
                if (CC.ReadCom.Contains("V"))
                {
                    bt.BackColor = Color.Green;
                }
                else
                {
                    bt.BackColor = Color.Red;
                }
            }
            else if (Name == "Meter")
            {
                //переделать под два класса и чтобы кнопка блочилась на время выполнения ком врайта
                CC.ComWrite("V00");
                //вожномжно переделать пока провожу тесты меня это утсраивает 
                if (CC.ReadCom.Contains("E"))
                {
                    bt.BackColor = Color.Green;
                }
                else
                {
                    bt.BackColor = Color.Red;
                }
            }
        }

       
        //public void SaveSettings()
        //{
        //    serDeser.Serialize();
        //}
    }
}