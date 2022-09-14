using COPriceEditor.Models;

namespace COPriceEditor
{
    public partial class Main : Krypton.Toolkit.KryptonForm
    {
        private Itemtype CurrentItemtype;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSelectPath_Click(object sender, EventArgs e)
        {
            DialogResult dRes = openFileDialog1.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                if (path == null) return;
                CurrentItemtype = new(openFileDialog1.FileName);
                CurrentItemtype.Decrypt();
                CurrentItemtype.LoadItems();
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
                    lbxItems.Items.Add(i.Get(Item.Atribute.ID) + $" - [{i.Get(Item.Atribute.Name)}] {sufix}"); Thread.Sleep(0);
                });
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
    }
}