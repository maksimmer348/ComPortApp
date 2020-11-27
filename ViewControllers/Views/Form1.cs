using System;
using System.Drawing;
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
        public event Action UpdateTest;
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
            OutputLoad?.Invoke();
            //this.Tag.ToString();
        }

        private void StartMeasurements_Click(object sender, EventArgs e)
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

        private void VoltageValueWrite_TextChanged(object sender, EventArgs e)
        {
            SetVoltage?.Invoke();
        }

        private void CurrentValueWrite_TextChanged(object sender, EventArgs e)
        {
            SetCurrent?.Invoke();
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

        private void SetValue_Click(object sender, EventArgs e)
        {
            UpdateTest?.Invoke();
        }

        public void ReadToCom(string writeVoltage, string writeCurrent)
        {
            VoltageValueReadings.Text = writeVoltage;
            CurrentValueReadings.Text = writeCurrent;
        }
    }
}
