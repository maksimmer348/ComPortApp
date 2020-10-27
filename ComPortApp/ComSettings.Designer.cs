namespace ComPortApp
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
            this.CannelComSupply = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectSettingsCom = new System.Windows.Forms.TabControl();
            this.SupplyTab = new System.Windows.Forms.TabPage();
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
            this.CannelComMeter = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.OkSettings = new System.Windows.Forms.Button();
            this.CancelSettings = new System.Windows.Forms.Button();
            this.SendToCom = new System.Windows.Forms.TextBox();
            this.ReceivingInformation = new System.Windows.Forms.RichTextBox();
            this.Recieve = new System.Windows.Forms.Button();
            this.SelectSettingsCom.SuspendLayout();
            this.SupplyTab.SuspendLayout();
            this.MeterTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CannelComSupply
            // 
            this.CannelComSupply.FormattingEnabled = true;
            this.CannelComSupply.Location = new System.Drawing.Point(6, 6);
            this.CannelComSupply.Name = "CannelComSupply";
            this.CannelComSupply.Size = new System.Drawing.Size(79, 21);
            this.CannelComSupply.TabIndex = 1;
            this.CannelComSupply.SelectedIndexChanged += new System.EventHandler(this.CannelComSupply_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cannel com";
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
            this.SupplyTab.Controls.Add(this.CannelComSupply);
            this.SupplyTab.Controls.Add(this.label1);
            this.SupplyTab.Location = new System.Drawing.Point(4, 22);
            this.SupplyTab.Name = "SupplyTab";
            this.SupplyTab.Padding = new System.Windows.Forms.Padding(3);
            this.SupplyTab.Size = new System.Drawing.Size(172, 204);
            this.SupplyTab.TabIndex = 0;
            this.SupplyTab.Text = "Supply";
            this.SupplyTab.UseVisualStyleBackColor = true;
            // 
            // TestComSupply
            // 
            this.TestComSupply.Location = new System.Drawing.Point(118, 173);
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
            this.DtrSupply.CheckedChanged += new System.EventHandler(this.DtrSupply_CheckedChanged);
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
            this.StopBitsSupply.Location = new System.Drawing.Point(6, 87);
            this.StopBitsSupply.Name = "StopBitsSupply";
            this.StopBitsSupply.Size = new System.Drawing.Size(79, 21);
            this.StopBitsSupply.TabIndex = 8;
            this.StopBitsSupply.SelectedIndexChanged += new System.EventHandler(this.StopBitsSupply_SelectedIndexChanged);
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
            this.ParityBitSupply.Location = new System.Drawing.Point(6, 60);
            this.ParityBitSupply.Name = "ParityBitSupply";
            this.ParityBitSupply.Size = new System.Drawing.Size(79, 21);
            this.ParityBitSupply.TabIndex = 6;
            this.ParityBitSupply.SelectedIndexChanged += new System.EventHandler(this.ParityBitSupply_SelectedIndexChanged);
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
            this.BaudRateSupply.Location = new System.Drawing.Point(6, 33);
            this.BaudRateSupply.Name = "BaudRateSupply";
            this.BaudRateSupply.Size = new System.Drawing.Size(79, 21);
            this.BaudRateSupply.TabIndex = 4;
            this.BaudRateSupply.SelectedIndexChanged += new System.EventHandler(this.BaudRateSupply_SelectedIndexChanged);
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
            this.MeterTab.Controls.Add(this.CannelComMeter);
            this.MeterTab.Controls.Add(this.label10);
            this.MeterTab.Location = new System.Drawing.Point(4, 22);
            this.MeterTab.Name = "MeterTab";
            this.MeterTab.Padding = new System.Windows.Forms.Padding(3);
            this.MeterTab.Size = new System.Drawing.Size(172, 204);
            this.MeterTab.TabIndex = 1;
            this.MeterTab.Text = "Meter";
            this.MeterTab.UseVisualStyleBackColor = true;
            // 
            // TestComMeter
            // 
            this.TestComMeter.Location = new System.Drawing.Point(118, 173);
            this.TestComMeter.Name = "TestComMeter";
            this.TestComMeter.Size = new System.Drawing.Size(38, 23);
            this.TestComMeter.TabIndex = 26;
            this.TestComMeter.Text = "Test";
            this.TestComMeter.UseVisualStyleBackColor = true;
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
            this.DtrMeter.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            this.FlowControlMeter.Location = new System.Drawing.Point(6, 114);
            this.FlowControlMeter.Name = "FlowControlMeter";
            this.FlowControlMeter.Size = new System.Drawing.Size(79, 21);
            this.FlowControlMeter.TabIndex = 22;
            this.FlowControlMeter.SelectedIndexChanged += new System.EventHandler(this.FlowControlMeter_SelectedIndexChanged);
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
            this.StopBitsMeter.Location = new System.Drawing.Point(6, 87);
            this.StopBitsMeter.Name = "StopBitsMeter";
            this.StopBitsMeter.Size = new System.Drawing.Size(79, 21);
            this.StopBitsMeter.TabIndex = 20;
            this.StopBitsMeter.SelectedIndexChanged += new System.EventHandler(this.StopBitsMeter_SelectedIndexChanged);
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
            this.ParityBitMeter.Location = new System.Drawing.Point(6, 60);
            this.ParityBitMeter.Name = "ParityBitMeter";
            this.ParityBitMeter.Size = new System.Drawing.Size(79, 21);
            this.ParityBitMeter.TabIndex = 18;
            this.ParityBitMeter.SelectedIndexChanged += new System.EventHandler(this.ParityBitMeter_SelectedIndexChanged);
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
            this.BaudRateMeter.Location = new System.Drawing.Point(6, 33);
            this.BaudRateMeter.Name = "BaudRateMeter";
            this.BaudRateMeter.Size = new System.Drawing.Size(79, 21);
            this.BaudRateMeter.TabIndex = 16;
            this.BaudRateMeter.SelectedIndexChanged += new System.EventHandler(this.BaudRateMeter_SelectedIndexChanged);
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
            // CannelComMeter
            // 
            this.CannelComMeter.FormattingEnabled = true;
            this.CannelComMeter.Location = new System.Drawing.Point(6, 6);
            this.CannelComMeter.Name = "CannelComMeter";
            this.CannelComMeter.Size = new System.Drawing.Size(79, 21);
            this.CannelComMeter.TabIndex = 14;
            this.CannelComMeter.SelectedIndexChanged += new System.EventHandler(this.CannelComMeter_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Cannel com";
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
            // SendToCom
            // 
            this.SendToCom.Location = new System.Drawing.Point(2, 369);
            this.SendToCom.Name = "SendToCom";
            this.SendToCom.Size = new System.Drawing.Size(176, 20);
            this.SendToCom.TabIndex = 16;
            this.SendToCom.TextChanged += new System.EventHandler(this.SendToCom_TextChanged);
            // 
            // ReceivingInformation
            // 
            this.ReceivingInformation.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReceivingInformation.Location = new System.Drawing.Point(2, 278);
            this.ReceivingInformation.Name = "ReceivingInformation";
            this.ReceivingInformation.Size = new System.Drawing.Size(176, 85);
            this.ReceivingInformation.TabIndex = 17;
            this.ReceivingInformation.Text = "";
            this.ReceivingInformation.TextChanged += new System.EventHandler(this.ReceivingInformation_TextChanged);
            // 
            // Recieve
            // 
            this.Recieve.Location = new System.Drawing.Point(2, 395);
            this.Recieve.Name = "Recieve";
            this.Recieve.Size = new System.Drawing.Size(63, 23);
            this.Recieve.TabIndex = 18;
            this.Recieve.Text = "Recieve";
            this.Recieve.UseVisualStyleBackColor = true;
            this.Recieve.Click += new System.EventHandler(this.Recieve_Click);
            // 
            // ComSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 461);
            this.Controls.Add(this.Recieve);
            this.Controls.Add(this.ReceivingInformation);
            this.Controls.Add(this.SendToCom);
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

        private System.Windows.Forms.ComboBox CannelComSupply;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabControl SelectSettingsCom;
        private System.Windows.Forms.TabPage SupplyTab;
        private System.Windows.Forms.TabPage MeterTab;
        private System.Windows.Forms.CheckBox DtrSupply;
        private System.Windows.Forms.Button ResetSettingsSupply;
        private System.Windows.Forms.ComboBox FlowControlSupply;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox StopBitsSupply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ParityBitSupply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BaudRateSupply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OkSettings;
        private System.Windows.Forms.Button CancelSettings;
        private System.Windows.Forms.CheckBox DtrMeter;
        private System.Windows.Forms.Button ResetSettingsMeter;
        private System.Windows.Forms.ComboBox FlowControlMeter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox StopBitsMeter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ParityBitMeter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox BaudRateMeter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CannelComMeter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button TestComSupply;
        private System.Windows.Forms.Button TestComMeter;
        private System.Windows.Forms.TextBox SendToCom;
        private System.Windows.Forms.RichTextBox ReceivingInformation;
        private System.Windows.Forms.Button Recieve;
    }
}