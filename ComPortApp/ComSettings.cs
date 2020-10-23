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
        private string[] cannelNum = new[] {"1", "2", "3", "4"};

        private string[] baudRate = new[] {"2400", "9600"};

        //private int[] parityBit = new[] {0, 1};
        private string[] stopBits = new[] {"0", "1"};

        //private bool flowContr = false;
        private bool dtrEnable;

    public ComSettings()
        {
            InitializeComponent();
           
            ConfigTab();
            AddCountSettings(CannelComSupply,cannelNum);
            AddCountSettings(BaudRateSupply, baudRate);
            AddCountSettings(StopBitsSupply, stopBits);
            

        }

        void ConfigTab()
        {
            if (SelectSettingsCom.SelectedTab.Name == "SupplyTab")
            {
                
            }

            if (SelectSettingsCom.SelectedTab.Name == "MeterTab")
            {
               
            }
        }

        void AddCountSettings(ComboBox box, string[] adds)
        {
            box.Items.AddRange(adds);
            box.Text = adds[0];
           // dtrEnable = DataTerminalReady.Checked;
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

       

        private void BaudRateSupply_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StopBitsSupply_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OkSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
