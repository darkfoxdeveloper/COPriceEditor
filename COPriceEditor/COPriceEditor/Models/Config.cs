namespace COPriceEditor.Models
{
    public static class Config
    {
        public static List<ItemAttribute> ItemAttributes { get; set; }
        public static bool EnablePreviewItemIcons = false;
    }

    public class ItemAttribute
    {
        public string Name { get; set; }
        public uint ItemtypeIndex { get; set; }
        public string TypeField { get; set; }
    }
}
