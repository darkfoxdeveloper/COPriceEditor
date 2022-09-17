using System.Globalization;

namespace COPriceEditor.Models
{
    public class Itemtype
    {
        private byte[] key = new byte[0x80];
        public List<Item> Items;
        public string SourceFile;
        public string TargetFile;
        private IniFile ItemMinIcon;
        private string ClientPath;
        private bool DecryptedMode;

        public Itemtype(string SourceFile, string ClientPath)
        {
            this.ClientPath = ClientPath;
            this.Items = new List<Item>();
            this.TargetFile = Path.GetDirectoryName(SourceFile) + "/" + Path.GetFileNameWithoutExtension(SourceFile) + ".txt";
            if (Config.EnablePreviewItemIcons)
            {
                this.ItemMinIcon = new IniFile(Path.Combine(this.ClientPath, "ani", "ItemMinIcon.Ani"));
            }
            if (!SourceFile.EndsWith(".txt"))
            {
                this.SourceFile = SourceFile;
                if (!int.TryParse("2537", NumberStyles.HexNumber, null, out int seed))
                {
                    return;
                }
                MSRandom r = new(seed);
                for (int i = 0; i < key.Length; i++)
                {
                    key[i] = (byte)(r.Next() % 0x100);
                }
                this.Decrypt();
            }
            this.LoadItems();
        }

        public Itemtype(string SourceFile, string ClientPath, bool DecryptedMode)
        {
            this.ClientPath = ClientPath;
            this.DecryptedMode = DecryptedMode;
            this.Items = new List<Item>();
            this.TargetFile = Path.GetDirectoryName(SourceFile) + "/" + Path.GetFileNameWithoutExtension(SourceFile) + ".txt";
            if (Config.EnablePreviewItemIcons)
            {
                this.ItemMinIcon = new IniFile(Path.Combine(this.ClientPath, "ani", "ItemMinIcon.Ani"));
            }
            if (!SourceFile.EndsWith(".txt"))
            {
                this.SourceFile = SourceFile;
                if (!int.TryParse("2537", NumberStyles.HexNumber, null, out int seed))
                {
                    return;
                }
                MSRandom r = new(seed);
                for (int i = 0; i < key.Length; i++)
                {
                    key[i] = (byte)(r.Next() % 0x100);
                }
                this.Decrypt();
            }
            this.LoadItems();
        }
        public void LoadItems()
        {
            string[] ItemsTxt = File.ReadAllLines(this.TargetFile);
            this.Items = new List<Item>();
            for (int i = 0; i < ItemsTxt.Length; i++)
            {
                this.Items.Add(new Item(ItemsTxt[i], true));
            }
        }

        public void SaveItems()
        {
            Item[] items = this.Items.ToArray();
            string[] lines = new string[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                this.Items[i].Export();
                lines[i] = this.Items[i].ToString();
            }
            File.WriteAllLines(this.TargetFile, lines);
            if (!this.DecryptedMode)
            {
                this.Encrypt();
            }
        }

        public string SaveItemsAs(string OutputFile)
        {
            Item[] items = this.Items.ToArray();
            string[] lines = new string[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                this.Items[i].Export();
                lines[i] = this.Items[i].ToString();
            }
            string saveAsPath = Path.GetDirectoryName(OutputFile) + "/" + Path.GetFileNameWithoutExtension(OutputFile) + ".tmp"; // force save unencrypted and .tmp extension
            string saveAsPathEncrypted = Path.GetDirectoryName(OutputFile) + "/" + Path.GetFileNameWithoutExtension(OutputFile) + ".dat"; // force save encrypted and .dat extension
            if (this.DecryptedMode)
            {
                saveAsPath = Path.GetDirectoryName(OutputFile) + "/" + Path.GetFileNameWithoutExtension(OutputFile) + ".txt"; // force save unencrypted and .tmp extension
                File.WriteAllLines(saveAsPath, lines);
            } else
            {
                File.WriteAllLines(saveAsPath, lines);
                key = new byte[0x80];
                if (!int.TryParse("2537", NumberStyles.HexNumber, null, out int seed))
                {
                    return "[ERROR]";
                }
                MSRandom r = new(seed);
                for (int i = 0; i < key.Length; i++)
                {
                    key[i] = (byte)(r.Next() % 0x100);
                }
                byte[] b = File.ReadAllBytes(saveAsPath);
                for (int i = 0; i < b.Length; i++)
                {
                    int bits = i % 8;
                    int num = (byte)((b[i] >> (8 - bits)) + (b[i] << bits));
                    b[i] = (byte)(num ^ key[i % 0x80]);
                }
                File.WriteAllBytes(saveAsPathEncrypted, b);
            }
            return this.DecryptedMode ? saveAsPath : saveAsPathEncrypted;
        }
        public void RemoveItem(Item item)
        {
            this.Items.Remove(item);
        }
        public void RemoveItemByID(uint ID)
        {
            Item i = this.Items.Where(x => x.Get(Item.Atribute.ID) == ID.ToString()).FirstOrDefault();
            if (i != null)
            {
                this.RemoveItem(i);
            }
        }
        public string GetImagePath(Item item)
        {
            string DDS = ItemMinIcon.GetValue("ItemDefault", "Frame0").Replace('/', Path.DirectorySeparatorChar);
            string imagePath = Path.Combine(ClientPath, DDS);
            try
            {
                DDS = ItemMinIcon.GetValue("Item" + item.Get(Item.Atribute.ID), "Frame0").Replace('/', Path.DirectorySeparatorChar);
                string ddsPath = Path.Combine(ClientPath, DDS);
                if (File.Exists(ddsPath))
                {
                    imagePath = ddsPath;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return imagePath;
        }
        public void Decrypt()
        {
            byte[] b = File.ReadAllBytes(SourceFile);
            for (int i = 0; i < b.Length; i++)
            {
                int num = b[i] ^ key[i % 0x80];
                int bits = i % 8;
                b[i] = (byte)((num << (8 - bits)) + (num >> bits));
            }
            this.TargetFile = Path.GetDirectoryName(SourceFile) + "/" + Path.GetFileNameWithoutExtension(SourceFile) + ".txt";
            File.WriteAllBytes(this.TargetFile, b);
        }

        public void Encrypt()
        {
            byte[] b = File.ReadAllBytes(this.TargetFile);
            for (int i = 0; i < b.Length; i++)
            {
                int bits = i % 8;
                int num = (byte)((b[i] >> (8 - bits)) + (b[i] << bits));
                b[i] = (byte)(num ^ key[i % 0x80]);
            }
            File.WriteAllBytes(SourceFile, b);
        }

        public class MSRandom
        {
            public long Seed;
            public MSRandom(int seed)
            {
                Seed = seed;
            }
            public int Next()
            {
                return (int)(((Seed = Seed * 214013L + 2531011L) >> 16) & 0x7fff);
            }
        }
    }
}
