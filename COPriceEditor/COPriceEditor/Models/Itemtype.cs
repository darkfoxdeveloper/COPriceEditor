using System.Globalization;

namespace COPriceEditor.Models
{
    public class Itemtype
    {
        private readonly byte[] key = new byte[0x80];
        public List<Item> Items;
        public string SourceFile;
        public string TargetFile;
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
            this.Encrypt();
        }

        public Itemtype(string SourceFile)
        {
            this.Items = new List<Item>();
            this.TargetFile = Path.GetDirectoryName(SourceFile) + "/" + Path.GetFileNameWithoutExtension(SourceFile) + ".txt";
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
