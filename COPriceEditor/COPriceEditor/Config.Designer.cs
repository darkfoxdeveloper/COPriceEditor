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
            this.gridConfigs = new Krypton.Toolkit.KryptonDataGridView();
            this.btnSaveConfig = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridConfigs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateConfig
            // 
            this.btnCreateConfig.Location = new System.Drawing.Point(12, 12);
            this.btnCreateConfig.Name = "btnCreateConfig";
            this.btnCreateConfig.Size = new System.Drawing.Size(598, 51);
            this.btnCreateConfig.TabIndex = 0;
            this.btnCreateConfig.Values.Text = "Create Default Config";
            this.btnCreateConfig.Click += new System.EventHandler(this.BtnCreateConfig_Click);
            // 
            // btnPreviewIcons
            // 
            this.btnPreviewIcons.Location = new System.Drawing.Point(12, 69);
            this.btnPreviewIcons.Name = "btnPreviewIcons";
            this.btnPreviewIcons.Size = new System.Drawing.Size(598, 51);
            this.btnPreviewIcons.TabIndex = 1;
            this.btnPreviewIcons.Values.Text = "Enable Preview Icons";
            this.btnPreviewIcons.Click += new System.EventHandler(this.BtnPreviewIcons_Click);
            // 
            // gridConfigs
            // 
            this.gridConfigs.ColumnHeadersHeight = 51;
            this.gridConfigs.Location = new System.Drawing.Point(12, 136);
            this.gridConfigs.Name = "gridConfigs";
            this.gridConfigs.RowHeadersWidth = 62;
            this.gridConfigs.RowTemplate.Height = 33;
            this.gridConfigs.Size = new System.Drawing.Size(598, 456);
            this.gridConfigs.TabIndex = 2;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(12, 598);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(598, 51);
            this.btnSaveConfig.TabIndex = 3;
            this.btnSaveConfig.Values.Text = "Save Config";
            this.btnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 661);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.gridConfigs);
            this.Controls.Add(this.btnPreviewIcons);
            this.Controls.Add(this.btnCreateConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridConfigs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonButton btnCreateConfig;
        private Krypton.Toolkit.KryptonButton btnPreviewIcons;
        private Krypton.Toolkit.KryptonDataGridView gridConfigs;
        private Krypton.Toolkit.KryptonButton btnSaveConfig;
    }
}