using System;
using System.Collections.Generic;
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

        public Dictionary<string ,Button> Buttons = new Dictionary<string, Button>();

        public Form1()
        {
            InitializeComponent();
            AddButtons();
        }

        void AddButtons()
        {
            Buttons.Add("Output",Output);
            Buttons.Add("SetValue",SetValue);
            //Buttons.Add("Output", Output);
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

        public void StatusButtonOn(string name, bool activate)
        {
            if (activate)
            {
                Buttons[name].BackColor = Color.Green;
            }

            if (!activate)
            {
                Buttons[name].BackColor = Color.Red;
            }

        }

        public void StatusButtonEnable(string name, bool activate)
        {
            Buttons[name].Enabled = activate;
        }

        public void ButtonConected()
        {
            Output.BackColor = Color.Green;
        }

        public void ButtonDisconected()
        {
            Output.BackColor = Color.Red;
        }

        //todo переименовать
        public void ReadToCom(string writeVoltage, string writeCurrent)
        {
            //todo перенести расчеты и формативрование в класс calculate
            if (writeVoltage != "" && writeCurrent != "")
            {
                VoltageValueReadings.Text = string.Empty;
                VoltageValueReadings.Text = writeVoltage;
                CurrentValueReadings.Text = string.Empty;
                CurrentValueReadings.Text = writeCurrent;

                double tempV = double.Parse(writeVoltage, CultureInfo.InvariantCulture);
                double tempC = double.Parse(writeCurrent, CultureInfo.InvariantCulture);
                double tempP = tempV * tempC;
                PowerValueReadings.Text = string.Empty;
                PowerValueReadings.Text = tempP.ToString();
            }
            else
            {
                CurrentValueReadings.Text = string.Empty;
                VoltageValueReadings.Text = string.Empty;
                PowerValueReadings.Text = string.Empty;
                ButtonDisconected();
            }
            //todo
            
        }


        public string [] GetParams()
        {
            return new [] { VoltageValueWrite.Text, CurrentValueWrite.Text, PowerValueWrite.Text};
        }
    }
}
