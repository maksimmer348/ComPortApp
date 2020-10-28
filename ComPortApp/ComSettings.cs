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
        //хорошее ли решение с экземплярами для supply и meter?
        ComConfig CSS = new ComConfig("Supply");
        ComConfig CSM = new ComConfig("Meter");

        public ComSettings()
        {
            InitializeComponent();
            CSS.RestoreForm(CannelComSupply, BaudRateSupply, ParityBitSupply, StopBitsSupply,FlowControlSupply, DtrSupply);
            CSM.RestoreForm(CannelComMeter, BaudRateMeter, ParityBitMeter, StopBitsMeter,FlowControlMeter, DtrMeter);
            CSS.DefaultConfCom();
            CSM.DefaultConfCom();

            //временно потом удалить
            SendToComSup.Text = "L";
            SendToComMet.Text = "V00";

        }

        //временно удалить после создания библиот команд, пока для тестов команд
        private void Recieve_Click(object sender, EventArgs e)
        {
            CSS.CC.ComWrite(SendToComSup.Text);
            ReceivingInformation.Text += CSS.CC.ReadCom;
            CSM.CC.ComWrite(SendToComMet.Text);
            ReceivingInformation.Text += CSM.CC.ReadCom;
        }

        private void ResetSettingsSupply_Click(object sender, EventArgs e)
        {
            //потом сделать один методом ResetSettings в ComConfig
            var dialogResult = MessageBox.Show("Усановить настройки по умолчанию?", "По умолчанию", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return; 
            CSS.DefaultConfCom();
        }
        private void ResetSettingsMeter_Click(object sender, EventArgs e)
        {
            //потом сделать один методом ResetSettings в ComConfig
            var dialogResult = MessageBox.Show("Усановить настройки по умолчанию?", "По умолчанию", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            CSM.DefaultConfCom();
        }

        private void OkSettings_Click(object sender, EventArgs e)
        {
            CSS.ApplySettings();
            CSM.ApplySettings();
            this.Close();
        }

        private void CancelSettings_Click(object sender, EventArgs e)
        {
            CSS.CancelSettings();
            CSM.CancelSettings();
            this.Close();
        }

        private void TestComSupply_Click(object sender, EventArgs e)
        {
            //добавить функционал и  для meter
            CSS.TestCommunication(TestCheckSup);
        }

        private void TestComMeter_Click(object sender, EventArgs e)
        {

        }

        private void CannelComSupply_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DtrSupply_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void BaudRateSupply_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StopBitsSupply_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void ParityBitSupply_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckClass_Click(object sender, EventArgs e)
        {

        }

        private void SendToComMet_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ReceivingInformation_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendToComSup_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TestCheckSup_Click(object sender, EventArgs e)
        {

        }
    }
}
