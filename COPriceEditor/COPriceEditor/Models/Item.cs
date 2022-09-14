namespace COPriceEditor.Models
{
    public class Item
    {
        private string ItemLine;
        public string[] ItemLineData;

        public Item(string ItemLine, bool AutoImport = true)
        {
            this.ItemLineData = Array.Empty<string>();
            this.ItemLine = ItemLine;
            if (AutoImport)
            {
                this.Import();
            }
        }

        public void Import(string Separator = "@@")
        {
            ItemLineData = ItemLine.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Export()
        {
            this.ItemLine = string.Join("@@", this.ItemLineData);
        }

        public string Get(Item.Atribute atribute)
        {
            return ItemLineData[(int)atribute];
        }

        public void ChangePrice(int type = 0, uint value = 0)//0=money/1=conquerpoints
        {
            switch (type)
            {
                case 0:
                    {
                        ItemLineData[(int)Atribute.GoldWorth] = value.ToString();
                        break;
                    }
                case 1:
                    {
                        ItemLineData[(int)Atribute.ConquerPointsWorth] = value.ToString();
                        break;
                    }
            }
        }

        public override string ToString()
        {
            return this.ItemLine;
        }

        public enum Atribute
        {
            ID = 0,
            Name = 1,
            GoldWorth = 12,
            ConquerPointsWorth = 37
        }
    }
}
