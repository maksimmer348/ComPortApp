using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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

            CSS.RestoreForm(CannelComSupply, BaudRateSupply, ParityBitSupply, StopBitsSupply, FlowControlSupply, DtrSupply);
            CSM.RestoreForm(CannelComMeter, BaudRateMeter, ParityBitMeter, StopBitsMeter,FlowControlMeter, DtrMeter);
            CSS.DefaultConfCom();
            CSM.DefaultConfCom();
            
            Deserialize();
            //временно потом удалить
            SendToComSup.Text = "L";
            SendToComMet.Text = "V00";
            
        }

        //временно удалить после создания библиот команд, пока для тестов команд
        private void Recieve_Click(object sender, EventArgs e)
        {
            CSS.CC.ComWrite(SendToComSup.Text);
            ReceivingInformation.Text += CSS.CC.ReadCom + "\n";
            CSM.CC.ComWrite(SendToComMet.Text);
            ReceivingInformation.Text += CSM.CC.ReadCom;
        }

        private void ResetSettingsSupply_Click(object sender, EventArgs e)
        {
            //TODO:потом сделать один методом ResetSettings в ComConfig
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
            //CSS.SaveSettings();
            //CSM.SaveSettings();
            Serialize();
            // this.Close();
        }

        private void CancelSettings_Click(object sender, EventArgs e)
        {
            CSS.CancelSettings();
            CSM.CancelSettings();
            Deserialize();
            //this.Close();

        }
        public void Serialize()
        {
            List<ComConfig> comConfigs = new List<ComConfig> {CSS, CSM};
            string json = JsonConvert.SerializeObject(comConfigs, Formatting.Indented);//, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            File.WriteAllText("Settings.json", json , Encoding.UTF8);
        }

        private void Deserialize()
        {
            var ss = JsonConvert.DeserializeObject<List<ComConfig>>(File.ReadAllText("Settings.json"));

            CSS = ss[0];
            CSM = ss[1];

            CSS.CannelComBox.Text = ss[0].CC.NumPort.ToString();
            CSM.CannelComBox.Text = ss[1].CC.NumPort.ToString();
        }

        private void TestComSupply_Click(object sender, EventArgs e)
        {
            //добавить функционал и  для meter
            CSS.TestCommunication(TestCheckSup);

        }

        private void TestComMeter_Click(object sender, EventArgs e)
        {
            CSM.TestCommunication(TestCheckMet);
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

        private void Clear_Click(object sender, EventArgs e)
        {
            ReceivingInformation.Text = String.Empty;
        }
    }
}
