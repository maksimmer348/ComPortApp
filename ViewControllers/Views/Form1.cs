using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public event Action SelectTabLoad;
            //public event Action SetTimer;
        
        private Dictionary<string, object> Elements = new Dictionary<string, object>();

        public Form1()
        {
            InitializeComponent();
            AddElements();
           // SelectLoad.SelectedIndexChanged += new EventHandler();
        }

        public void SelectLoadSelecting(object sender, EventArgs e)
        {
            SelectTabLoad?.Invoke();
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


        void AddElements()
        {
            var type1 = typeof(Form1);
            var type2 = type1.GetFields();

            foreach (var types in type2)
            {

                if (types.FieldType.Name == "Button" || types.FieldType.Name == "TextBox" ||
                    types.FieldType.Name == "CheckBox" || types.FieldType.Name == "TabControl")
                {
                    Elements.Add(types.Name, types.GetValue(this));

                }

            }
        }


        public string GetTabsPage()
        {
            return SelectLoad.SelectedTab.Name;
        }

    public T GetComponent<T>(string name) where T : Component
        {
            return Elements[name] as T;
        }

        public void StatusButtonOn(string name, bool activate)
        {
            if (activate)
            {
                GetComponent<Button>(name).BackColor = Color.Green;
            }

            if (!activate)
            {
                GetComponent<Button>(name).BackColor = Color.Red;
            }

        }

        public void StatusButtonEnable(string name, bool activate)
        {
            GetComponent<Button>(name).Enabled = activate;
        }

        void SetTimerValue()
        {
           
        }
        void GetTime()
        {
            GetComponent<TextBox>("Hours").Text = "1";
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

                //double tempV = double.Parse(writeVoltage, CultureInfo.InvariantCulture);
                //double tempC = double.Parse(writeCurrent, CultureInfo.InvariantCulture);
                //double tempP = tempV * tempC;
                //PowerValueReadings.Text = string.Empty;
                //PowerValueReadings.Text = tempP.ToString().Replace(",",".");
            }
            else
            {
                CurrentValueReadings.Text = string.Empty;
                VoltageValueReadings.Text = string.Empty;
                PowerValueReadings.Text = string.Empty;
                StatusButtonOn("Output", false);
            }
            //todo

        }

        private void TestTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Hours_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

