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
            this.MeterTab = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ResetSettings = new System.Windows.Forms.Button();
            this.DataTerminalReady = new System.Windows.Forms.CheckBox();
            this.OkSettings = new System.Windows.Forms.Button();
            this.CancelSettings = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TestComSupply = new System.Windows.Forms.Button();
            this.TestComMeter = new System.Windows.Forms.Button();
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
            this.SupplyTab.Controls.Add(this.DataTerminalReady);
            this.SupplyTab.Controls.Add(this.ResetSettings);
            this.SupplyTab.Controls.Add(this.comboBox4);
            this.SupplyTab.Controls.Add(this.label5);
            this.SupplyTab.Controls.Add(this.comboBox3);
            this.SupplyTab.Controls.Add(this.label4);
            this.SupplyTab.Controls.Add(this.comboBox2);
            this.SupplyTab.Controls.Add(this.label3);
            this.SupplyTab.Controls.Add(this.comboBox1);
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
            // MeterTab
            // 
            this.MeterTab.Controls.Add(this.TestComMeter);
            this.MeterTab.Controls.Add(this.checkBox1);
            this.MeterTab.Controls.Add(this.button1);
            this.MeterTab.Controls.Add(this.comboBox5);
            this.MeterTab.Controls.Add(this.label6);
            this.MeterTab.Controls.Add(this.comboBox6);
            this.MeterTab.Controls.Add(this.label7);
            this.MeterTab.Controls.Add(this.comboBox7);
            this.MeterTab.Controls.Add(this.label8);
            this.MeterTab.Controls.Add(this.comboBox8);
            this.MeterTab.Controls.Add(this.label9);
            this.MeterTab.Controls.Add(this.comboBox9);
            this.MeterTab.Controls.Add(this.label10);
            this.MeterTab.Location = new System.Drawing.Point(4, 22);
            this.MeterTab.Name = "MeterTab";
            this.MeterTab.Padding = new System.Windows.Forms.Padding(3);
            this.MeterTab.Size = new System.Drawing.Size(172, 204);
            this.MeterTab.TabIndex = 1;
            this.MeterTab.Text = "Meter";
            this.MeterTab.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 21);
            this.comboBox1.TabIndex = 4;
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
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 60);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(79, 21);
            this.comboBox2.TabIndex = 6;
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
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(6, 87);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(79, 21);
            this.comboBox3.TabIndex = 8;
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
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(6, 114);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(79, 21);
            this.comboBox4.TabIndex = 10;
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
            // ResetSettings
            // 
            this.ResetSettings.Location = new System.Drawing.Point(6, 173);
            this.ResetSettings.Name = "ResetSettings";
            this.ResetSettings.Size = new System.Drawing.Size(90, 23);
            this.ResetSettings.TabIndex = 12;
            this.ResetSettings.Text = "Reset settings";
            this.ResetSettings.UseVisualStyleBackColor = true;
            // 
            // DataTerminalReady
            // 
            this.DataTerminalReady.AutoSize = true;
            this.DataTerminalReady.Location = new System.Drawing.Point(7, 143);
            this.DataTerminalReady.Name = "DataTerminalReady";
            this.DataTerminalReady.Size = new System.Drawing.Size(149, 17);
            this.DataTerminalReady.TabIndex = 13;
            this.DataTerminalReady.Text = "Data terminal ready (DTR)";
            this.DataTerminalReady.UseVisualStyleBackColor = true;
            // 
            // OkSettings
            // 
            this.OkSettings.Location = new System.Drawing.Point(6, 239);
            this.OkSettings.Name = "OkSettings";
            this.OkSettings.Size = new System.Drawing.Size(63, 23);
            this.OkSettings.TabIndex = 14;
            this.OkSettings.Text = "OK";
            this.OkSettings.UseVisualStyleBackColor = true;
            // 
            // CancelSettings
            // 
            this.CancelSettings.Location = new System.Drawing.Point(115, 239);
            this.CancelSettings.Name = "CancelSettings";
            this.CancelSettings.Size = new System.Drawing.Size(63, 23);
            this.CancelSettings.TabIndex = 15;
            this.CancelSettings.Text = "Cancel";
            this.CancelSettings.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 143);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "Data terminal ready (DTR)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Reset settings";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(6, 114);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(79, 21);
            this.comboBox5.TabIndex = 22;
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
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(6, 87);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(79, 21);
            this.comboBox6.TabIndex = 20;
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
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(6, 60);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(79, 21);
            this.comboBox7.TabIndex = 18;
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
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(6, 33);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(79, 21);
            this.comboBox8.TabIndex = 16;
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
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(6, 6);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(79, 21);
            this.comboBox9.TabIndex = 14;
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
            // TestComSupply
            // 
            this.TestComSupply.Location = new System.Drawing.Point(118, 173);
            this.TestComSupply.Name = "TestComSupply";
            this.TestComSupply.Size = new System.Drawing.Size(38, 23);
            this.TestComSupply.TabIndex = 14;
            this.TestComSupply.Text = "Test";
            this.TestComSupply.UseVisualStyleBackColor = true;
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
            // ComSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 271);
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

        }

        #endregion

        private System.Windows.Forms.ComboBox CannelComSupply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl SelectSettingsCom;
        private System.Windows.Forms.TabPage SupplyTab;
        private System.Windows.Forms.TabPage MeterTab;
        private System.Windows.Forms.CheckBox DataTerminalReady;
        private System.Windows.Forms.Button ResetSettings;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OkSettings;
        private System.Windows.Forms.Button CancelSettings;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button TestComSupply;
        private System.Windows.Forms.Button TestComMeter;
    }
}