namespace COPriceEditor.Models
{
    public class Item
    {
        private string ItemLine;
        public string[] ItemLineData;
        private string ItemAttrSeparator;

        public Item(string ItemLine, bool AutoImport = true)
        {
            this.ItemLineData = Array.Empty<string>();
            this.ItemLine = ItemLine;
            if (AutoImport)
            {
                this.Import();
            }
        }

        public void Import()
        {
            // Smart detection of the Separator pattern in itemtypes
            string Separator = "@@";
            if (!ItemLine.Contains(Separator))
            {
                Separator = " ";
            }
            ItemAttrSeparator = Separator;
            ItemLineData = ItemLine.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Export()
        {
            this.ItemLine = string.Join(ItemAttrSeparator, this.ItemLineData);
        }

        public string Get(Item.Atribute atribute)
        {
            return ItemLineData[(uint)atribute];
        }

        public string Get(uint index)
        {
            if (ItemLineData.Length >= index)
            {
                return ItemLineData[index];
            } else
            {
                return String.Empty;
            }
        }

        public string Set(Item.Atribute atribute, string value)
        {
            return ItemLineData[(uint)atribute] = value;
        }

        public string Set(uint index, string value)
        {
            return ItemLineData[index] = value;
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
