using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPortApp
{
    public partial class ComSettings : Form
    {
        private int[] BaudRate = new[] {2400, 9600};

        public ComSettings()
        {
            InitializeComponent();
        }

        private void CannelComSupply_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataTerminalReady_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ResetSettings_Click(object sender, EventArgs e)
        {

        }

        private void TestComSupply_Click(object sender, EventArgs e)
        {

        }

        private void OkSettings_Click(object sender, EventArgs e)
        {

        }
    }
}
