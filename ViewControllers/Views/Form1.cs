using System;
using View = ComPortSettings.MVC.View;
using System.Windows.Forms;

namespace ComPortSettings
{
    public partial class Form1 : View
    {
        public event Action OpenSettings;
        public event Action OO;
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
            OO?.Invoke();
        }
    }
}
