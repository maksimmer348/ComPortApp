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

        public void SelectLoadSelecting(object sender, EventArgs e)
        {
            SelectTabLoad?.Invoke();
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

        public T GetComponent<T>(string name) where T : Component
        {
            return Elements[name] as T;
        }

        public string GetTabsPage()
        {
            return SelectLoad.SelectedTab.Name;
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
        public void StatusTextBoxEnable(string name, bool activate)
        {
            GetComponent<TextBox>(name).Enabled = activate;
        }
        private void TestTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Hours_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

