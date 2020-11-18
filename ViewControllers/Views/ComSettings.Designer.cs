namespace ComPortSettings
{
    partial class ComSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChannelComSupply = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectSettingsCom = new System.Windows.Forms.TabControl();
            this.SupplyTab = new System.Windows.Forms.TabPage();
            this.TestCheckSup = new System.Windows.Forms.Button();
            this.TestComSupply = new System.Windows.Forms.Button();
            this.DtrSupply = new System.Windows.Forms.CheckBox();
            this.ResetSettingsSupply = new System.Windows.Forms.Button();
            this.FlowControlSupply = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StopBitsSupply = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ParityBitSupply = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BaudRateSupply = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MeterTab = new System.Windows.Forms.TabPage();
            this.TestCheckMet = new System.Windows.Forms.Button();
            this.TestComMeter = new System.Windows.Forms.Button();
            this.DtrMeter = new System.Windows.Forms.CheckBox();
            this.ResetSettingsMeter = new System.Windows.Forms.Button();
            this.FlowControlMeter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.StopBitsMeter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ParityBitMeter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BaudRateMeter = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ChannelComMeter = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.OkSettings = new System.Windows.Forms.Button();
            this.CancelSettings = new System.Windows.Forms.Button();
            this.SendToComMet = new System.Windows.Forms.TextBox();
            this.ReceivingInformation = new System.Windows.Forms.RichTextBox();
            this.Recieve = new System.Windows.Forms.Button();
            this.SendToComSup = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.SelectSettingsCom.SuspendLayout();
            this.SupplyTab.SuspendLayout();
            this.MeterTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelComSupply
            // 
            this.ChannelComSupply.FormattingEnabled = true;
            this.ChannelComSupply.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.ChannelComSupply.Location = new System.Drawing.Point(6, 6);
            this.ChannelComSupply.Name = "ChannelComSupply";
            this.ChannelComSupply.Size = new System.Drawing.Size(79, 21);
            this.ChannelComSupply.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Channel com";
            // 
            // SelectSettingsCom
            // 
            this.SelectSettingsCom.Controls.Add(this.SupplyTab);
            this.SelectSettingsCom.Controls.Add(this.MeterTab);
            this.SelectSettingsCom.Location = new System.Drawing.Point(2, 3);
            this.SelectSettingsCom.Name = "SelectSettingsCom";
            this.SelectSettingsCom.SelectedIndex = 0;
            this.SelectSettingsCom.Size = new System.Drawing.Size(180, 230);
            this.SelectSettingsCom.TabIndex = 5;
            // 
            // SupplyTab
            // 
            this.SupplyTab.Controls.Add(this.TestCheckSup);
            this.SupplyTab.Controls.Add(this.TestComSupply);
            this.SupplyTab.Controls.Add(this.DtrSupply);
            this.SupplyTab.Controls.Add(this.ResetSettingsSupply);
            this.SupplyTab.Controls.Add(this.FlowControlSupply);
            this.SupplyTab.Controls.Add(this.label5);
            this.SupplyTab.Controls.Add(this.StopBitsSupply);
            this.SupplyTab.Controls.Add(this.label4);
            this.SupplyTab.Controls.Add(this.ParityBitSupply);
            this.SupplyTab.Controls.Add(this.label3);
            this.SupplyTab.Controls.Add(this.BaudRateSupply);
            this.SupplyTab.Controls.Add(this.label2);
            this.SupplyTab.Controls.Add(this.ChannelComSupply);
            this.SupplyTab.Controls.Add(this.label1);
            this.SupplyTab.Location = new System.Drawing.Point(4, 22);
            this.SupplyTab.Name = "SupplyTab";
            this.SupplyTab.Padding = new System.Windows.Forms.Padding(3);
            this.SupplyTab.Size = new System.Drawing.Size(172, 204);
            this.SupplyTab.TabIndex = 0;
            this.SupplyTab.Text = "Supply";
            this.SupplyTab.UseVisualStyleBackColor = true;
            // 
            // TestCheckSup
            // 
            this.TestCheckSup.Enabled = false;
            this.TestCheckSup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TestCheckSup.Location = new System.Drawing.Point(110, 179);
            this.TestCheckSup.Name = "TestCheckSup";
            this.TestCheckSup.Size = new System.Drawing.Size(10, 10);
            this.TestCheckSup.TabIndex = 15;
            this.TestCheckSup.UseVisualStyleBackColor = false;
            // 
            // TestComSupply
            // 
            this.TestComSupply.Location = new System.Drawing.Point(126, 173);
            this.TestComSupply.Name = "TestComSupply";
            this.TestComSupply.Size = new System.Drawing.Size(38, 23);
            this.TestComSupply.TabIndex = 14;
            this.TestComSupply.Text = "Test";
            this.TestComSupply.UseVisualStyleBackColor = true;
            this.TestComSupply.Click += new System.EventHandler(this.TestComSupply_Click);
            // 
            // DtrSupply
            // 
            this.DtrSupply.AutoSize = true;
            this.DtrSupply.Location = new System.Drawing.Point(7, 143);
            this.DtrSupply.Name = "DtrSupply";
            this.DtrSupply.Size = new System.Drawing.Size(149, 17);
            this.DtrSupply.TabIndex = 13;
            this.DtrSupply.Text = "Data terminal ready (DTR)";
            this.DtrSupply.UseVisualStyleBackColor = true;
            // 
            // ResetSettingsSupply
            // 
            this.ResetSettingsSupply.Location = new System.Drawing.Point(6, 173);
            this.ResetSettingsSupply.Name = "ResetSettingsSupply";
            this.ResetSettingsSupply.Size = new System.Drawing.Size(90, 23);
            this.ResetSettingsSupply.TabIndex = 12;
            this.ResetSettingsSupply.Text = "Reset settings";
            this.ResetSettingsSupply.UseVisualStyleBackColor = true;
            this.ResetSettingsSupply.Click += new System.EventHandler(this.ResetSettingsSupply_Click);
            // 
            // FlowControlSupply
            // 
            this.FlowControlSupply.FormattingEnabled = true;
            this.FlowControlSupply.Items.AddRange(new object[] {
            "on",
            "off"});
            this.FlowControlSupply.Location = new System.Drawing.Point(6, 114);
            this.FlowControlSupply.Name = "FlowControlSupply";
            this.FlowControlSupply.Size = new System.Drawing.Size(79, 21);
            this.FlowControlSupply.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Flow control";
            // 
            // StopBitsSupply
            // 
            this.StopBitsSupply.FormattingEnabled = true;
            this.StopBitsSupply.Items.AddRange(new object[] {
            "0",
            "1"});
            this.StopBitsSupply.Location = new System.Drawing.Point(6, 87);
            this.StopBitsSupply.Name = "StopBitsSupply";
            this.StopBitsSupply.Size = new System.Drawing.Size(79, 21);
            this.StopBitsSupply.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stop bits";
            // 
            // ParityBitSupply
            // 
            this.ParityBitSupply.FormattingEnabled = true;
            this.ParityBitSupply.Items.AddRange(new object[] {
            "0",
            "1"});
            this.ParityBitSupply.Location = new System.Drawing.Point(6, 60);
            this.ParityBitSupply.Name = "ParityBitSupply";
            this.ParityBitSupply.Size = new System.Drawing.Size(79, 21);
            this.ParityBitSupply.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Parity bit";
            // 
            // BaudRateSupply
            // 
            this.BaudRateSupply.FormattingEnabled = true;
            this.BaudRateSupply.Items.AddRange(new object[] {
            "2400",
            "9600"});
            this.BaudRateSupply.Location = new System.Drawing.Point(6, 33);
            this.BaudRateSupply.Name = "BaudRateSupply";
            this.BaudRateSupply.Size = new System.Drawing.Size(79, 21);
            this.BaudRateSupply.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud rate";
            // 
            // MeterTab
            // 
            this.MeterTab.Controls.Add(this.TestCheckMet);
            this.MeterTab.Controls.Add(this.TestComMeter);
            this.MeterTab.Controls.Add(this.DtrMeter);
            this.MeterTab.Controls.Add(this.ResetSettingsMeter);
            this.MeterTab.Controls.Add(this.FlowControlMeter);
            this.MeterTab.Controls.Add(this.label6);
            this.MeterTab.Controls.Add(this.StopBitsMeter);
            this.MeterTab.Controls.Add(this.label7);
            this.MeterTab.Controls.Add(this.ParityBitMeter);
            this.MeterTab.Controls.Add(this.label8);
            this.MeterTab.Controls.Add(this.BaudRateMeter);
            this.MeterTab.Controls.Add(this.label9);
            this.MeterTab.Controls.Add(this.ChannelComMeter);
            this.MeterTab.Controls.Add(this.label10);
            this.MeterTab.Location = new System.Drawing.Point(4, 22);
            this.MeterTab.Name = "MeterTab";
            this.MeterTab.Padding = new System.Windows.Forms.Padding(3);
            this.MeterTab.Size = new System.Drawing.Size(172, 204);
            this.MeterTab.TabIndex = 1;
            this.MeterTab.Text = "Meter";
            this.MeterTab.UseVisualStyleBackColor = true;
            // 
            // TestCheckMet
            // 
            this.TestCheckMet.Enabled = false;
            this.TestCheckMet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TestCheckMet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TestCheckMet.Location = new System.Drawing.Point(110, 179);
            this.TestCheckMet.Name = "TestCheckMet";
            this.TestCheckMet.Size = new System.Drawing.Size(10, 10);
            this.TestCheckMet.TabIndex = 27;
            this.TestCheckMet.UseVisualStyleBackColor = false;
            // 
            // TestComMeter
            // 
            this.TestComMeter.Location = new System.Drawing.Point(126, 173);
            this.TestComMeter.Name = "TestComMeter";
            this.TestComMeter.Size = new System.Drawing.Size(38, 23);
            this.TestComMeter.TabIndex = 26;
            this.TestComMeter.Text = "Test";
            this.TestComMeter.UseVisualStyleBackColor = true;
            this.TestComMeter.Click += new System.EventHandler(this.TestComMeter_Click);
            // 
            // DtrMeter
            // 
            this.DtrMeter.AutoSize = true;
            this.DtrMeter.Location = new System.Drawing.Point(7, 143);
            this.DtrMeter.Name = "DtrMeter";
            this.DtrMeter.Size = new System.Drawing.Size(149, 17);
            this.DtrMeter.TabIndex = 25;
            this.DtrMeter.Text = "Data terminal ready (DTR)";
            this.DtrMeter.UseVisualStyleBackColor = true;
            // 
            // ResetSettingsMeter
            // 
            this.ResetSettingsMeter.Location = new System.Drawing.Point(6, 173);
            this.ResetSettingsMeter.Name = "ResetSettingsMeter";
            this.ResetSettingsMeter.Size = new System.Drawing.Size(90, 23);
            this.ResetSettingsMeter.TabIndex = 24;
            this.ResetSettingsMeter.Text = "Reset settings";
            this.ResetSettingsMeter.UseVisualStyleBackColor = true;
            this.ResetSettingsMeter.Click += new System.EventHandler(this.ResetSettingsMeter_Click);
            // 
            // FlowControlMeter
            // 
            this.FlowControlMeter.FormattingEnabled = true;
            this.FlowControlMeter.Items.AddRange(new object[] {
            "on",
            "off"});
            this.FlowControlMeter.Location = new System.Drawing.Point(6, 114);
            this.FlowControlMeter.Name = "FlowControlMeter";
            this.FlowControlMeter.Size = new System.Drawing.Size(79, 21);
            this.FlowControlMeter.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Flow control";
            // 
            // StopBitsMeter
            // 
            this.StopBitsMeter.FormattingEnabled = true;
            this.StopBitsMeter.Items.AddRange(new object[] {
            "0",
            "1"});
            this.StopBitsMeter.Location = new System.Drawing.Point(6, 87);
            this.StopBitsMeter.Name = "StopBitsMeter";
            this.StopBitsMeter.Size = new System.Drawing.Size(79, 21);
            this.StopBitsMeter.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Stop bits";
            // 
            // ParityBitMeter
            // 
            this.ParityBitMeter.FormattingEnabled = true;
            this.ParityBitMeter.Items.AddRange(new object[] {
            "0",
            "1"});
            this.ParityBitMeter.Location = new System.Drawing.Point(6, 60);
            this.ParityBitMeter.Name = "ParityBitMeter";
            this.ParityBitMeter.Size = new System.Drawing.Size(79, 21);
            this.ParityBitMeter.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Parity bit";
            // 
            // BaudRateMeter
            // 
            this.BaudRateMeter.FormattingEnabled = true;
            this.BaudRateMeter.Items.AddRange(new object[] {
            "2400",
            "9600"});
            this.BaudRateMeter.Location = new System.Drawing.Point(6, 33);
            this.BaudRateMeter.Name = "BaudRateMeter";
            this.BaudRateMeter.Size = new System.Drawing.Size(79, 21);
            this.BaudRateMeter.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Baud rate";
            // 
            // ChannelComMeter
            // 
            this.ChannelComMeter.FormattingEnabled = true;
            this.ChannelComMeter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.ChannelComMeter.Location = new System.Drawing.Point(6, 6);
            this.ChannelComMeter.Name = "ChannelComMeter";
            this.ChannelComMeter.Size = new System.Drawing.Size(79, 21);
            this.ChannelComMeter.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Channel com";
            // 
            // OkSettings
            // 
            this.OkSettings.Location = new System.Drawing.Point(6, 239);
            this.OkSettings.Name = "OkSettings";
            this.OkSettings.Size = new System.Drawing.Size(63, 23);
            this.OkSettings.TabIndex = 14;
            this.OkSettings.Text = "OK";
            this.OkSettings.UseVisualStyleBackColor = true;
            this.OkSettings.Click += new System.EventHandler(this.OkSettings_Click);
            // 
            // CancelSettings
            // 
            this.CancelSettings.Location = new System.Drawing.Point(115, 239);
            this.CancelSettings.Name = "CancelSettings";
            this.CancelSettings.Size = new System.Drawing.Size(63, 23);
            this.CancelSettings.TabIndex = 15;
            this.CancelSettings.Text = "Cancel";
            this.CancelSettings.UseVisualStyleBackColor = true;
            this.CancelSettings.Click += new System.EventHandler(this.CancelSettings_Click);
            // 
            // SendToComMet
            // 
            this.SendToComMet.Location = new System.Drawing.Point(115, 369);
            this.SendToComMet.Name = "SendToComMet";
            this.SendToComMet.Size = new System.Drawing.Size(63, 20);
            this.SendToComMet.TabIndex = 16;
            // 
            // ReceivingInformation
            // 
            this.ReceivingInformation.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReceivingInformation.Location = new System.Drawing.Point(2, 278);
            this.ReceivingInformation.Name = "ReceivingInformation";
            this.ReceivingInformation.Size = new System.Drawing.Size(176, 85);
            this.ReceivingInformation.TabIndex = 17;
            this.ReceivingInformation.Text = "";
            // 
            // Recieve
            // 
            this.Recieve.Location = new System.Drawing.Point(2, 395);
            this.Recieve.Name = "Recieve";
            this.Recieve.Size = new System.Drawing.Size(63, 23);
            this.Recieve.TabIndex = 18;
            this.Recieve.Text = "Recieve";
            this.Recieve.UseVisualStyleBackColor = true;
            // 
            // SendToComSup
            // 
            this.SendToComSup.Location = new System.Drawing.Point(2, 369);
            this.SendToComSup.Name = "SendToComSup";
            this.SendToComSup.Size = new System.Drawing.Size(63, 20);
            this.SendToComSup.TabIndex = 19;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(115, 395);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(63, 23);
            this.Clear.TabIndex = 20;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            // 
            // ComSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 421);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.SendToComSup);
            this.Controls.Add(this.Recieve);
            this.Controls.Add(this.ReceivingInformation);
            this.Controls.Add(this.SendToComMet);
            this.Controls.Add(this.CancelSettings);
            this.Controls.Add(this.OkSettings);
            this.Controls.Add(this.SelectSettingsCom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComSettings";
            this.Text = "Com Settings";
            this.SelectSettingsCom.ResumeLayout(false);
            this.SupplyTab.ResumeLayout(false);
            this.SupplyTab.PerformLayout();
            this.MeterTab.ResumeLayout(false);
            this.MeterTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabControl SelectSettingsCom;
        private System.Windows.Forms.TabPage SupplyTab;
        private System.Windows.Forms.TabPage MeterTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SendToComMet;
        private System.Windows.Forms.RichTextBox ReceivingInformation;
        private System.Windows.Forms.Button Recieve;
        private System.Windows.Forms.TextBox SendToComSup;
        private System.Windows.Forms.Button Clear;
        public System.Windows.Forms.ComboBox ChannelComSupply;
        public System.Windows.Forms.CheckBox DtrSupply;
        public System.Windows.Forms.ComboBox FlowControlSupply;
        public System.Windows.Forms.ComboBox StopBitsSupply;
        public System.Windows.Forms.ComboBox ParityBitSupply;
        public System.Windows.Forms.ComboBox BaudRateSupply;
        public System.Windows.Forms.CheckBox DtrMeter;
        public System.Windows.Forms.ComboBox FlowControlMeter;
        public System.Windows.Forms.ComboBox StopBitsMeter;
        public System.Windows.Forms.ComboBox ParityBitMeter;
        public System.Windows.Forms.ComboBox BaudRateMeter;
        public System.Windows.Forms.ComboBox ChannelComMeter;
        public System.Windows.Forms.Button ResetSettingsSupply;
        public System.Windows.Forms.Button OkSettings;
        public System.Windows.Forms.Button CancelSettings;
        public System.Windows.Forms.Button ResetSettingsMeter;
        public System.Windows.Forms.Button TestComSupply;
        public System.Windows.Forms.Button TestComMeter;
        public System.Windows.Forms.Button TestCheckSup;
        public System.Windows.Forms.Button TestCheckMet;
    }
}