namespace COPriceEditor
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.btnCreateConfig = new Krypton.Toolkit.KryptonButton();
            this.btnPreviewIcons = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // btnCreateConfig
            // 
            this.btnCreateConfig.Location = new System.Drawing.Point(12, 12);
            this.btnCreateConfig.Name = "btnCreateConfig";
            this.btnCreateConfig.Size = new System.Drawing.Size(567, 51);
            this.btnCreateConfig.TabIndex = 0;
            this.btnCreateConfig.Values.Text = "Create Default Config";
            this.btnCreateConfig.Click += new System.EventHandler(this.BtnCreateConfig_Click);
            // 
            // btnPreviewIcons
            // 
            this.btnPreviewIcons.Location = new System.Drawing.Point(12, 69);
            this.btnPreviewIcons.Name = "btnPreviewIcons";
            this.btnPreviewIcons.Size = new System.Drawing.Size(567, 51);
            this.btnPreviewIcons.TabIndex = 1;
            this.btnPreviewIcons.Values.Text = "Enable Preview Icons";
            this.btnPreviewIcons.Click += new System.EventHandler(this.BtnPreviewIcons_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 127);
            this.Controls.Add(this.btnPreviewIcons);
            this.Controls.Add(this.btnCreateConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonButton btnCreateConfig;
        private Krypton.Toolkit.KryptonButton btnPreviewIcons;
    }
}