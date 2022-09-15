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
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Example reader dds
            DDSImage img = new DDSImage(@"D:\Cliente Doritos-Conquer\data\ItemMinIcon\116100.dds");
            pictureBox1.Image = img.ToBitmap();
        }

        private void BtnSelectPath_Click(object sender, EventArgs e)
        {
            Open = false;
            DialogResult dRes = openFileDialog1.ShowDialog();
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
                string path = openFileDialog1.FileName;
                if (path == null) return;
                CurrentItemtype = new(openFileDialog1.FileName);
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
                        lbxItems.Items.Add(i.Get(Item.Atribute.ID) + $" - [{i.Get(Item.Atribute.Name)}] {sufix}"); Thread.Sleep(0);
                        lblStatus.Text = $"Loaded Item [{i.Get(Item.Atribute.ID)}]";
                    }));
                });
                this.Invoke(new Action(() =>
                {
                    lblStatus.Text = $"{CurrentItemtype.Items.Count} Items loaded.";
                    btnSelectPath.Enabled = true;
                }));
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
    }
}