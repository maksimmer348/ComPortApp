namespace ComPortSettings
{
    partial class MainForm
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
            this.openSettingsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openSettingsBtn
            // 
            this.openSettingsBtn.Location = new System.Drawing.Point(25, 41);
            this.openSettingsBtn.Name = "openSettingsBtn";
            this.openSettingsBtn.Size = new System.Drawing.Size(125, 23);
            this.openSettingsBtn.TabIndex = 0;
            this.openSettingsBtn.Text = "Open Settings";
            this.openSettingsBtn.UseVisualStyleBackColor = true;
            this.openSettingsBtn.Click += new System.EventHandler(this.openSettingsBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openSettingsBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button openSettingsBtn;

        #endregion
    }
}

