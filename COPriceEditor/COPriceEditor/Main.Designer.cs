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
            this.SuspendLayout();
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(12, 12);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(457, 58);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Values.Text = "Select Itemtype.dat";
            this.btnSelectPath.Click += new System.EventHandler(this.BtnSelectPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "itemtype.dat";
            this.openFileDialog1.Filter = "Itemtype file|itemtype.dat";
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
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 626);
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
    }
}