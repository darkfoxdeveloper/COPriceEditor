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
            this.lbxItems = new Krypton.Toolkit.KryptonListBox();
            this.btnSaveAs = new Krypton.Toolkit.KryptonButton();
            this.btnSave = new Krypton.Toolkit.KryptonButton();
            this.kryptonStatusStrip1 = new Krypton.Toolkit.KryptonStatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainWorker = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbxSearch = new Krypton.Toolkit.KryptonTextBox();
            this.searchWorker = new System.ComponentModel.BackgroundWorker();
            this.cbxDecryptedMode = new Krypton.Toolkit.KryptonCheckBox();
            this.itemtypeDatSelector = new System.Windows.Forms.OpenFileDialog();
            this.btnDelete = new Krypton.Toolkit.KryptonButton();
            this.panelFields = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonStatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(12, 12);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(561, 58);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Values.Text = "Select client path";
            this.btnSelectPath.Click += new System.EventHandler(this.BtnSelectPath_Click);
            // 
            // lbxItems
            // 
            this.lbxItems.Location = new System.Drawing.Point(12, 76);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.Size = new System.Drawing.Size(301, 663);
            this.lbxItems.TabIndex = 1;
            this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.LbxItems_SelectedIndexChanged);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(319, 725);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(254, 52);
            this.btnSaveAs.TabIndex = 6;
            this.btnSaveAs.Values.Text = "Save as...";
            this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(451, 667);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 52);
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
            this.kryptonStatusStrip1.Location = new System.Drawing.Point(0, 789);
            this.kryptonStatusStrip1.Name = "kryptonStatusStrip1";
            this.kryptonStatusStrip1.ProgressBars = null;
            this.kryptonStatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.kryptonStatusStrip1.Size = new System.Drawing.Size(585, 32);
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
            this.pictureBox1.Location = new System.Drawing.Point(451, 543);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tbxSearch
            // 
            this.tbxSearch.CueHint.CueHintText = "Search...";
            this.tbxSearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tbxSearch.Location = new System.Drawing.Point(12, 745);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(301, 32);
            this.tbxSearch.TabIndex = 10;
            this.tbxSearch.TextChanged += new System.EventHandler(this.TbxSearch_TextChanged);
            // 
            // searchWorker
            // 
            this.searchWorker.WorkerReportsProgress = true;
            this.searchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SearchWorker_DoWork);
            // 
            // cbxDecryptedMode
            // 
            this.cbxDecryptedMode.Location = new System.Drawing.Point(319, 76);
            this.cbxDecryptedMode.Name = "cbxDecryptedMode";
            this.cbxDecryptedMode.Size = new System.Drawing.Size(163, 29);
            this.cbxDecryptedMode.TabIndex = 11;
            this.cbxDecryptedMode.Values.Text = "Decrypted Mode";
            this.cbxDecryptedMode.CheckedChanged += new System.EventHandler(this.CbxDecryptedMode_CheckedChanged);
            // 
            // itemtypeDatSelector
            // 
            this.itemtypeDatSelector.FileName = "itemtype.txt";
            this.itemtypeDatSelector.Filter = "Itemtype decrypted|*.txt";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(319, 667);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 52);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Values.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // panelFields
            // 
            this.panelFields.AutoScroll = true;
            this.panelFields.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelFields.Location = new System.Drawing.Point(319, 111);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(254, 426);
            this.panelFields.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 821);
            this.Controls.Add(this.panelFields);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbxDecryptedMode);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kryptonStatusStrip1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveAs);
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
        private Krypton.Toolkit.KryptonListBox lbxItems;
        private Krypton.Toolkit.KryptonButton btnSaveAs;
        private Krypton.Toolkit.KryptonButton btnSave;
        private Krypton.Toolkit.KryptonStatusStrip kryptonStatusStrip1;
        private ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker mainWorker;
        private PictureBox pictureBox1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Krypton.Toolkit.KryptonTextBox tbxSearch;
        private System.ComponentModel.BackgroundWorker searchWorker;
        private Krypton.Toolkit.KryptonCheckBox cbxDecryptedMode;
        private OpenFileDialog itemtypeDatSelector;
        private Krypton.Toolkit.KryptonButton btnDelete;
        private FlowLayoutPanel panelFields;
    }
}