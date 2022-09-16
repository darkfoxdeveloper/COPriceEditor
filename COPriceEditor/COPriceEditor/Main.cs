using COPriceEditor.Models;
using DDSReader;

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OriginalItemList = new List<string>();
        }

        private void BtnSelectPath_Click(object sender, EventArgs e)
        {
            Open = false;
            DialogResult dRes = folderBrowserDialog1.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                Open = true;
                this.mainWorker.RunWorkerAsync();
            }
        }

        private void LbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Krypton.Toolkit.KryptonListBox lbox = (Krypton.Toolkit.KryptonListBox)sender;
            string ID = lbox.SelectedItem.ToString().Split("-")[0];
            Item it = CurrentItemtype.Items.Where(x => x.Get(Item.Atribute.ID) == ID.Trim()).FirstOrDefault();
            tbxCPs.Text = it.Get(Item.Atribute.ConquerPointsWorth);
            tbxMoney.Text = it.Get(Item.Atribute.GoldWorth);

            DDSImage img = new DDSImage(CurrentItemtype.GetImagePath(it));
            pictureBox1.Image = img.ToBitmap();
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

        private void TbxCPs_TextChanged(object sender, EventArgs e)
        {
            if (lbxItems.SelectedItem == null) return;
            Krypton.Toolkit.KryptonTextBox input = ((Krypton.Toolkit.KryptonTextBox)sender);
            if (int.TryParse(input.Text, out int r))
            {
                string ID = lbxItems.SelectedItem.ToString().Split("-")[0];
                Item it = CurrentItemtype.Items.Where(x => x.Get(Item.Atribute.ID) == ID.Trim()).FirstOrDefault();
                it.ChangePrice(1, uint.Parse(input.Text));
            }
        }

        private void tbxMoney_TextChanged(object sender, EventArgs e)
        {
            if (lbxItems.SelectedItem == null) return;
            Krypton.Toolkit.KryptonTextBox input = ((Krypton.Toolkit.KryptonTextBox)sender);
            if (int.TryParse(input.Text, out int r))
            {
                string ID = lbxItems.SelectedItem.ToString().Split("-")[0];
                Item it = CurrentItemtype.Items.Where(x => x.Get(Item.Atribute.ID) == ID.Trim()).FirstOrDefault();
                it.ChangePrice(0, uint.Parse(input.Text));
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
                if (path == null) return;
                if (File.Exists(path))
                {
                    CurrentItemtype = new(path, folderBrowserDialog1.SelectedPath);
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
                });
                this.Invoke(new Action(() =>
                {
                    lblStatus.Text = $"{CurrentItemtype.Items.Count} Items loaded.";
                    btnSelectPath.Enabled = true;
                }));
                CanSearch = true;
            } else
            {

                if (SaveAs)
                {
                    CurrentItemtype.SaveItemsAs(SaveAsPath);
                }
                else
                {
                    CurrentItemtype.SaveItems();
                }
            }
        }

        private void MainWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblStatus.Text = "Loading... " + e.ProgressPercentage;
        }

        private void TbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (CanSearch)
            {
                CanSearch = false;
                searchWorker.RunWorkerAsync();
            }
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
                    }
                }
                else
                {
                    foreach (string itemStr in OriginalItemList)
                    {
                        if (itemStr.Contains(tbxSearch.Text))
                        {
                            itemStrsAdd.Add(itemStr);
                        }
                    }
                    lbxItems.Items.Clear();
                    foreach (string itemStr in itemStrsAdd)
                    {
                        lbxItems.Items.Add(itemStr);
                    }
                }
                CanSearch = true;
            }));
        }
    }
}