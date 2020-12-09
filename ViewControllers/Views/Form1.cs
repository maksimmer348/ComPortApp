using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using View = ComPortSettings.MVC.View;
using System.Windows.Forms;

namespace ComPortSettings
{
    public partial class Form1 : View
    {
        public event Action OpenSettings;
        public event Action OutputLoad;
        public event Action SetVoltage;
        public event Action SetCurrent;
        public event Action SetValues;
        public event Action StartMesaure;
        public Form1()
        {
            InitializeComponent();
        }

        private void ComMenu_Click(object sender, EventArgs e)
        {
            OpenSettings?.Invoke();
        }

        private void Output_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Output_Click", sender);
            OutputLoad?.Invoke();
            //this.Tag.ToString();
        }

        private void StartMeasurements_Click(object sender, EventArgs e)
        {
            StartMesaure?.Invoke();
        }

        private void VoltageValueWrite_TextChanged(object sender, EventArgs e)
        {
            SetVoltage?.Invoke();
        }

        private void CurrentValueWrite_TextChanged(object sender, EventArgs e)
        {
            SetCurrent?.Invoke();
        }

        private void SetValue_Click(object sender, EventArgs e)
        {
            SetValues?.Invoke();
        }

        private void VoltageValueReadings_TextChanged(object sender, EventArgs e)
        {

        }

        private void CurrentValueReadings_TextChanged(object sender, EventArgs e)
        {

        }

        private void PowerValueReadings_TextChanged(object sender, EventArgs e)
        {

        }

        public void ButtonConected()
        {
            Output.BackColor = Color.Green;
        }

        public void ButtonDisconected()
        {
            Output.BackColor = Color.Red;
        }
        public void ReadToCom(string writeVoltage, string writeCurrent)
        {
            //todo перенести расчеты и формативрование в класс calculate
            if (writeVoltage != "" && writeCurrent != "")
            {
                VoltageValueReadings.Text = String.Empty;
                VoltageValueReadings.Text = writeVoltage;
                CurrentValueReadings.Text = String.Empty;
                CurrentValueReadings.Text = writeCurrent;

                double tempV = double.Parse(writeVoltage, CultureInfo.InvariantCulture);
                double tempC = double.Parse(writeCurrent, CultureInfo.InvariantCulture);
                double tempP = tempV * tempC;
                PowerValueReadings.Text = String.Empty;
                PowerValueReadings.Text = tempP.ToString();
            }
            else
            {
                CurrentValueReadings.Text = String.Empty;
                VoltageValueReadings.Text = String.Empty;
                PowerValueReadings.Text = String.Empty;
                ButtonDisconected();
            }
            //todo
            
        }
        public string [] WriteToCom()
        {
            string[] ss = {VoltageValueWrite.Text, CurrentValueWrite.Text, PowerValueWrite.Text};
            return ss;
        }
            public void ButtonEnabled(string sender)
        {
            
          
            
        }
    }
}
