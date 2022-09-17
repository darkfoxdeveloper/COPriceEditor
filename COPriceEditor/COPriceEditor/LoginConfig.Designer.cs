namespace COPriceEditor
{
    partial class LoginConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginConfig));
            this.tbxLicenseId = new Krypton.Toolkit.KryptonTextBox();
            this.btnLogin = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // tbxLicenseId
            // 
            this.tbxLicenseId.CueHint.CueHintText = "LicenseId";
            this.tbxLicenseId.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tbxLicenseId.Location = new System.Drawing.Point(12, 21);
            this.tbxLicenseId.Name = "tbxLicenseId";
            this.tbxLicenseId.Size = new System.Drawing.Size(384, 31);
            this.tbxLicenseId.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 68);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(384, 61);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Values.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LoginConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 139);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxLicenseId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginConfig";
            this.Text = "License Required for Settings";
            this.Load += new System.EventHandler(this.LoginConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox tbxLicenseId;
        private Krypton.Toolkit.KryptonButton btnLogin;
    }
}