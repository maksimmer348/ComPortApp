using System;
using View = ComPortSettings.MVC.View;

namespace ComPortSettings
{
    public partial class MainForm : View
    {
        public event Action OpenSettings;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openSettingsBtn_Click(object sender, EventArgs e)
        {
            OpenSettings?.Invoke();
        }
    }
}
