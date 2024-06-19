using COPriceEditor.Models;
using DDSReader;
using System.ComponentModel;

namespace COPriceEditor
{
    public partial class Main : Krypton.Toolkit.KryptonForm
    {
        private Itemtype CurrentItemtype;
        private bool SaveAs = false;
        private string SaveAsPath = "";
        private bool Open = false;
        private bool CanSearch = false;
        private List<string> OriginalItemList;
        public Main()
        {
            InitializeComponent();
            Models.Config.ConfigForm = new();
            Models.Config.LoginConfigForm = new();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OriginalItemList = new List<string>();
            if (File.Exists("Config.json"))
            {
                Models.Config.ItemAttributes = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<ItemAttribute>>(File.ReadAllText("Config.json"));
                ReloadFields();
            }
            ReloadFieldsDesign();
            //Models.Config.LicenseManager = new("304b78f8-6cc5-4e75-ac41-c1546af055af");
            //if (!Models.Config.LicenseManager.IsEnabledLicense())
            //{
            //    Krypton.Toolkit.KryptonMessageBox.Show($"Your LicenseId is not valid and cannot run this App. {System.Environment.NewLine} License Expiration: {Models.Config.LicenseManager.RegisteredLicense.LicenseExpiration} {System.Environment.NewLine} Enabled: {Models.Config.LicenseManager.RegisteredLicense.Enabled}", "License not valid - COPriceEditor", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.ERROR);
            //    Application.Exit();
            //} else
            //{
            //    if (Models.Config.LicenseManager.IsExpired())
            //    {
            //        Krypton.Toolkit.KryptonMessageBox.Show($"Your LicenseId is expired. {System.Environment.NewLine} License Expiration: {Models.Config.LicenseManager.RegisteredLicense.LicenseExpiration} {System.Environment.NewLine}", "License not valid - COPriceEditor", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.ERROR);
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        lblStatus.Text = $"License {Models.Config.LicenseManager.RegisteredLicense.Type} [Expires {Models.Config.LicenseManager.RegisteredLicense.LicenseExpiration}]";
            //    }
            //}
        }

        public void ReloadFieldsDesign()
        {
            if (!Models.Config.EnablePreviewItemIcons)
            {
                panelFields.Size = new Size(254, 550);
            } else
            {
                panelFields.Size = new Size(254, 426);
            }
        }

        public void ReloadFields()
        {
            panelFields.Controls.Clear();
            foreach (ItemAttribute itemAttr in Models.Config.ItemAttributes)
            {
                Krypton.Toolkit.KryptonLabel newLbl = new();
                newLbl.Text = itemAttr.Name;
                Krypton.Toolkit.KryptonTextBox newTbx = new();
                newTbx.Name = "Attr" + itemAttr.Name;
                panelFields.Controls.Add(newLbl);
                panelFields.Controls.Add(newTbx);
                newTbx.Tag = itemAttr;
                newTbx.TextChanged += NewTbx_TextChanged;
            }
        }

        private void NewTbx_TextChanged(object? sender, EventArgs e)
        {

            if (lbxItems.SelectedItem == null) return;
            Krypton.Toolkit.KryptonTextBox input = ((Krypton.Toolkit.KryptonTextBox)sender);
            bool validInputValue = true;
            ItemAttribute iAttr = ((ItemAttribute)input.Tag);
            if (iAttr.TypeField == "text")
            {
                validInputValue = true;
            }
            if (iAttr.TypeField == "number")
            {
                validInputValue = int.TryParse(input.Text, out int r);
            }
            if (validInputValue)
            {
                string ID = lbxItems.SelectedItem.ToString().Split("-")[0];
                Item it = CurrentItemtype.Items.Where(x => x.Get(Item.Atribute.ID) == ID.Trim()).FirstOrDefault();
                uint index = ((ItemAttribute)input.Tag).ItemtypeIndex;
                it.Set(index, input.Text);
            }
        }

        private void BtnSelectPath_Click(object sender, EventArgs e)
        {
            Open = false;
            if (cbxDecryptedMode.Checked)
            {
                DialogResult dResItemtype = itemtypeDatSelector.ShowDialog();
                if (dResItemtype == DialogResult.OK)
                {
                    if (Models.Config.EnablePreviewItemIcons)
                    {
                        DialogResult dRes = folderBrowserDialog1.ShowDialog();
                        if (dRes == DialogResult.OK)
                        {
                            Open = true;
                            btnSave.Enabled = false;
                            btnSaveAs.Enabled = false;
                            btnDelete.Enabled = false;
                            btnSearch.Enabled = false;
                            this.mainWorker.RunWorkerAsync();
                        }
                    } else
                    {
                        Open = true;
                        btnSave.Enabled = false;
                        btnSaveAs.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSearch.Enabled = false;
                        this.mainWorker.RunWorkerAsync();
                    }
                }
            } else
            {
                DialogResult dRes = folderBrowserDialog1.ShowDialog();
                if (dRes == DialogResult.OK)
                {
                    Open = true;
                    btnSave.Enabled = false;
                    btnSaveAs.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSearch.Enabled = false;
                    this.mainWorker.RunWorkerAsync();
                }
            }
        }

        private void LbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Krypton.Toolkit.KryptonListBox lbox = (Krypton.Toolkit.KryptonListBox)sender;
            if (lbox.SelectedItem == null) return;
            string ID = lbox.SelectedItem.ToString().Split("-")[0];
            Item it = CurrentItemtype.Items.Where(x => x.Get(Item.Atribute.ID) == ID.Trim()).FirstOrDefault();

            foreach(ItemAttribute itemAttr in Models.Config.ItemAttributes)
            {
                foreach(Control c in panelFields.Controls)
                {
                    if (c.Name == "Attr" + itemAttr.Name)
                    {
                        c.Text = it.Get(itemAttr.ItemtypeIndex);
                    }
                }
            }

            if (Models.Config.EnablePreviewItemIcons)
            {
                DDSImage img = new DDSImage(CurrentItemtype.GetImagePath(it));
                pictureBox1.Image = img.ToBitmap();
            }
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            Open = false;
            if (CurrentItemtype == null)
            {
                Krypton.Toolkit.KryptonMessageBox.Show("No itemtype loaded!", "COPriceEditor", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.WARNING);
            }
            else
            {
                SaveFileDialog sDialog = new();
                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveAs = true;
                    SaveAsPath = sDialog.FileName;
                    this.mainWorker.RunWorkerAsync();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Open = false;
            if (CurrentItemtype == null)
            {
                Krypton.Toolkit.KryptonMessageBox.Show("No itemtype loaded!", "COPriceEditor", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.WARNING);
            } else
            {
                SaveAs = false;
                SaveAsPath = "";
                this.mainWorker.RunWorkerAsync();
            }
        }

        private void MainWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (Open)
            {
                this.Invoke(new Action(() =>
                {
                    lblStatus.Text = "Loading...";
                    lbxItems.Items.Clear();
                    btnSelectPath.Enabled = false;
                }));
                string path = Path.Combine(folderBrowserDialog1.SelectedPath, "ini", "itemtype.dat");
                if (cbxDecryptedMode.Checked)
                {
                    path = itemtypeDatSelector.FileName;
                }
                if (path == null) return;
                if (File.Exists(path))
                {
                    CurrentItemtype = new(path, folderBrowserDialog1.SelectedPath, cbxDecryptedMode.Checked);
                }
                CurrentItemtype.Items.ForEach(i => {
                    string sufix = "";
                    if (i.Get(Item.Atribute.ID).EndsWith("9"))
                    {
                        sufix = "[S]";
                    }
                    if (i.Get(Item.Atribute.ID).EndsWith("8"))
                    {
                        sufix = "[E]";
                    }
                    if (i.Get(Item.Atribute.ID).EndsWith("7"))
                    {
                        sufix = "[U]";
                    }
                    if (i.Get(Item.Atribute.ID).EndsWith("6"))
                    {
                        sufix = "[R]";
                    }
                    if (i.Get(Item.Atribute.ID).EndsWith("5"))
                    {
                        sufix = "[N]";
                    }
                    this.Invoke(new Action(() =>
                    {
                        string itemStr = i.Get(Item.Atribute.ID) + $" - [{i.Get(Item.Atribute.Name)}] {sufix}";
                        OriginalItemList.Add(itemStr);
                        lbxItems.Items.Add(itemStr);
                        lblStatus.Text = $"Loaded Item [{i.Get(Item.Atribute.ID)}]";
                    }));
                    Thread.Sleep(0);
                });
                this.Invoke(new Action(() =>
                {
                    lblStatus.Text = $"{CurrentItemtype.Items.Count} Items loaded.";
                    btnSelectPath.Enabled = true;
                    btnSave.Enabled = true;
                    btnSaveAs.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSearch.Enabled = true;
                }));
                CanSearch = true;
            } else
            {
                if (SaveAs)
                {
                    string path = CurrentItemtype.SaveItemsAs(SaveAsPath);
                    lblStatus.Text = $"Saved in {path}";
                }
                else
                {
                    CurrentItemtype.SaveItems();
                    lblStatus.Text = "Saved";
                }
            }
        }

        private void MainWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblStatus.Text = "Loading... " + e.ProgressPercentage;
        }

        private void SearchWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                List<string> itemStrsAdd = new List<string>();
                if (tbxSearch.Text.Length <= 0)
                {
                    lbxItems.Items.Clear();
                    foreach (string itemStr in OriginalItemList)
                    {
                        lbxItems.Items.Add(itemStr);
                        Thread.Sleep(0);
                    }
                }
                else
                {
                    foreach (string itemStr in OriginalItemList)
                    {
                        if (itemStr.Contains(tbxSearch.Text))
                        {
                            itemStrsAdd.Add(itemStr);
                            Thread.Sleep(0);
                        }
                    }
                    lbxItems.Items.Clear();
                    foreach (string itemStr in itemStrsAdd)
                    {
                        lbxItems.Items.Add(itemStr);
                        Thread.Sleep(0);
                    }
                }
                CanSearch = true;
            }));
        }

        private void CbxDecryptedMode_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectPath.Text = cbxDecryptedMode.Checked ? "Select Itemtype.txt" : "Select client path";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                //if (Models.Config.LoginConfigForm.IsDisposed)
                //{
                //Models.Config.LoginConfigForm = new LoginConfig();
                //}
                //Models.Config.LoginConfigForm.Show();
                if (Models.Config.ConfigForm == null || Models.Config.ConfigForm.IsDisposed)
                {
                    Models.Config.ConfigForm = new Config();
                }
                if (!Models.Config.ConfigForm.Visible)
                {
                    Models.Config.ConfigForm.Show(this);
                }
                return true;
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (CanSearch)
            {
                string ID = lbxItems.SelectedItem.ToString().Split("-")[0];
                Item it = CurrentItemtype.Items.Where(x => x.Get(Item.Atribute.ID) == ID.Trim()).FirstOrDefault();
                lbxItems.Items.Remove(lbxItems.SelectedItem);
                CurrentItemtype.RemoveItemByID(uint.Parse(ID));
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CanSearch)
            {
                CanSearch = false;
                searchWorker.RunWorkerAsync();
            }
        }
    }
}