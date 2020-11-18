using System;
using System.Drawing;
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

        public ComSettings()
        {
            InitializeComponent();
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

        public void ButtonConected()
        {
            TestCheckSup.BackColor = Color.Green;
        }
        public void ButtonDisconected()
        {
            TestCheckSup.BackColor = Color.Red;
        }
    }
}
