using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using View = ComPortSettings.MVC.View;

namespace ComPortSettings
{
    public partial class ComSettings : View
    {
        public event Action ResetSupply;
        public event Action ResetMeter;
        public event Action TestSupply;
        public event Action TestMeter;
        public event Action Ok;
        public event Action Cancel;

        private Dictionary<string, object> Elements = new Dictionary<string, object>();

        public ComSettings()
        {
            InitializeComponent();
            AddElements();
        }

        private void ResetSettingsSupply_Click(object sender, EventArgs e)
        {
            ResetSupply?.Invoke();
        }

        private void ResetSettingsMeter_Click(object sender, EventArgs e)
        {
            ResetMeter?.Invoke();
        }

        private void TestComSupply_Click(object sender, EventArgs e)
        {
            TestSupply?.Invoke();
        }

        private void TestComMeter_Click(object sender, EventArgs e)
        {
            TestMeter?.Invoke();
        }

        private void OkSettings_Click(object sender, EventArgs e)
        {
            Ok?.Invoke();
        }

        private void CancelSettings_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke();
        }

        void AddElements()
        {
            var type1 = typeof(ComSettings);
            var type2 = type1.GetFields();

            foreach (var types in type2)
            {

                if (types.FieldType.Name == "Button")
                {
                    Elements.Add(types.Name, types.GetValue(this));

                }

            }
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

        //public void ButtonConected()
        //{
        //    TestCheckSup.BackColor = Color.Green;
        //}
        //public void ButtonDisconected()
        //{
        //    TestCheckSup.BackColor = Color.Red;
           
        //}
        //public void ButtonConectedMeter()
        //{
        //    TestCheckMet.BackColor = Color.Green;
        //}
        //public void ButtonDisconectedMeter()
        //{
        //    TestCheckMet.BackColor = Color.Red;
        //}

        public void SelectToTab(int tab)
        {
            SelectSettingsCom.SelectedTab = SelectSettingsCom.TabPages[tab];
        }

        public void ReceivingInformation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
