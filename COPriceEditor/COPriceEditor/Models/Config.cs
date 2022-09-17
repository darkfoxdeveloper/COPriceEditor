using System.ComponentModel;

namespace COPriceEditor.Models
{
    public static class Config
    {
        public static BindingList<ItemAttribute> ItemAttributes { get; set; }
        public static bool EnablePreviewItemIcons = false;
        public static COPriceEditor.Config ConfigForm;
        public static LoginConfig LoginConfigForm;
        public static string RegisteredLicenseId { get; set; }
    }

    public class ItemAttribute
    {
        public string Name { get; set; }
        public uint ItemtypeIndex { get; set; }
        public string TypeField { get; set; }
    }
}
