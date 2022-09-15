namespace COPriceEditor
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnSelectPath = new Krypton.Toolkit.KryptonButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbxItems = new Krypton.Toolkit.KryptonListBox();
            this.tbxCPs = new Krypton.Toolkit.KryptonTextBox();
            this.lblCPs = new Krypton.Toolkit.KryptonLabel();
            this.lblMoney = new Krypton.Toolkit.KryptonLabel();
            this.tbxMoney = new Krypton.Toolkit.KryptonTextBox();
            this.btnSaveAs = new Krypton.Toolkit.KryptonButton();
            this.btnSave = new Krypton.Toolkit.KryptonButton();
            this.kryptonStatusStrip1 = new Krypton.Toolkit.KryptonStatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainWorker = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonStatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(12, 12);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(457, 58);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Values.Text = "Select Itemtype";
            this.btnSelectPath.Click += new System.EventHandler(this.BtnSelectPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "itemtype.dat";
            this.openFileDialog1.Filter = "Itemtype file|*.dat|Itemtype file decrypted|*.txt";
            // 
            // lbxItems
            // 
            this.lbxItems.Location = new System.Drawing.Point(12, 86);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.Size = new System.Drawing.Size(301, 528);
            this.lbxItems.TabIndex = 1;
            this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.LbxItems_SelectedIndexChanged);
            // 
            // tbxCPs
            // 
            this.tbxCPs.Location = new System.Drawing.Point(332, 121);
            this.tbxCPs.Name = "tbxCPs";
            this.tbxCPs.Size = new System.Drawing.Size(137, 32);
            this.tbxCPs.TabIndex = 2;
            this.tbxCPs.Text = "0";
            this.tbxCPs.TextChanged += new System.EventHandler(this.TbxCPs_TextChanged);
            // 
            // lblCPs
            // 
            this.lblCPs.Location = new System.Drawing.Point(332, 86);
            this.lblCPs.Name = "lblCPs";
            this.lblCPs.Size = new System.Drawing.Size(84, 29);
            this.lblCPs.TabIndex = 3;
            this.lblCPs.Values.Text = "CPs Cost";
            // 
            // lblMoney
            // 
            this.lblMoney.Location = new System.Drawing.Point(332, 183);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(111, 29);
            this.lblMoney.TabIndex = 5;
            this.lblMoney.Values.Text = "Money Cost";
            // 
            // tbxMoney
            // 
            this.tbxMoney.Location = new System.Drawing.Point(332, 218);
            this.tbxMoney.Name = "tbxMoney";
            this.tbxMoney.Size = new System.Drawing.Size(137, 32);
            this.tbxMoney.TabIndex = 4;
            this.tbxMoney.Text = "0";
            this.tbxMoney.TextChanged += new System.EventHandler(this.tbxMoney_TextChanged);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(319, 503);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(153, 52);
            this.btnSaveAs.TabIndex = 6;
            this.btnSaveAs.Values.Text = "Save as...";
            this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(319, 562);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 52);
            this.btnSave.TabIndex = 7;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // kryptonStatusStrip1
            // 
            this.kryptonStatusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kryptonStatusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.kryptonStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.kryptonStatusStrip1.Location = new System.Drawing.Point(0, 626);
            this.kryptonStatusStrip1.Name = "kryptonStatusStrip1";
            this.kryptonStatusStrip1.ProgressBars = null;
            this.kryptonStatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.kryptonStatusStrip1.Size = new System.Drawing.Size(484, 32);
            this.kryptonStatusStrip1.TabIndex = 8;
            this.kryptonStatusStrip1.Text = "kryptonStatusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 25);
            this.lblStatus.Text = "Ready";
            // 
            // mainWorker
            // 
            this.mainWorker.WorkerReportsProgress = true;
            this.mainWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MainWorker_DoWork);
            this.mainWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MainWorker_ProgressChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(319, 366);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 658);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kryptonStatusStrip1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.tbxMoney);
            this.Controls.Add(this.lblCPs);
            this.Controls.Add(this.tbxCPs);
            this.Controls.Add(this.lbxItems);
            this.Controls.Add(this.btnSelectPath);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "COPriceEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.kryptonStatusStrip1.ResumeLayout(false);
            this.kryptonStatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonButton btnSelectPath;
        private OpenFileDialog openFileDialog1;
        private Krypton.Toolkit.KryptonListBox lbxItems;
        private Krypton.Toolkit.KryptonTextBox tbxCPs;
        private Krypton.Toolkit.KryptonLabel lblCPs;
        private Krypton.Toolkit.KryptonLabel lblMoney;
        private Krypton.Toolkit.KryptonTextBox tbxMoney;
        private Krypton.Toolkit.KryptonButton btnSaveAs;
        private Krypton.Toolkit.KryptonButton btnSave;
        private Krypton.Toolkit.KryptonStatusStrip kryptonStatusStrip1;
        private ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker mainWorker;
        private PictureBox pictureBox1;
    }
}