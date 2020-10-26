using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPortApp
{
    public partial class ComSettings : Form
    {

        ComConfig CSS = new ComConfig("Supply");
        ComConfig CSM = new ComConfig("Meter");

        public ComSettings()
        {
            InitializeComponent();
           
           
            CSS.RestoreForm(CannelComSupply, BaudRateSupply, StopBitsSupply);
            CSM.RestoreForm(CannelComMeter, BaudRateMeter, StopBitsMeter);
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

       
        private void CannelComSupply_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void DataTerminalReady_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ResetSettingsSupply_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Усановить настройки по умолчанию?", "По умолчанию", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return; 
            CSS.DefaultConfCom();
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

        private void CannelComMeter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BaudRateMeter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ParityBitMeter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StopBitsMeter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FlowControlMeter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ResetSettingsMeter_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Усановить настройки по умолчанию?", "По умолчанию", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            CSM.DefaultConfCom();
        }
    }
}
