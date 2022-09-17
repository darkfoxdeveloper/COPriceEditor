namespace COPriceEditor
{
    public partial class Config : Krypton.Toolkit.KryptonForm
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (File.Exists("Config.json"))
            {
                Models.Config.ItemAttributes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.ItemAttribute>>(File.ReadAllText("Config.json"));
                btnCreateConfig.Enabled = false;
            } else
            {
                btnCreateConfig.Enabled = true;
            }
            btnPreviewIcons.Enabled = !Models.Config.EnablePreviewItemIcons;
            gridConfigs.DataSource = Models.Config.ItemAttributes;
            if (Models.Config.ItemAttributes == null)
            {
                btnSaveConfig.Enabled = false;
            }
        }

        private void BtnCreateConfig_Click(object sender, EventArgs e)
        {
            Models.Config.ItemAttributes = new List<Models.ItemAttribute>();
            Models.Config.ItemAttributes.Add(new Models.ItemAttribute() { Name = "Name", ItemtypeIndex = 1, TypeField = "Text" });
            Models.Config.ItemAttributes.Add(new Models.ItemAttribute() { Name = "Description", ItemtypeIndex = 54, TypeField = "Text" });
            Models.Config.ItemAttributes.Add(new Models.ItemAttribute() { Name = "Class", ItemtypeIndex = 2, TypeField = "Number" });
            Models.Config.ItemAttributes.Add(new Models.ItemAttribute() { Name = "Gold", ItemtypeIndex = 12, TypeField = "Number" });
            Models.Config.ItemAttributes.Add(new Models.ItemAttribute() { Name = "CPs", ItemtypeIndex = 37, TypeField = "Number" });
            File.WriteAllText("Config.json", Newtonsoft.Json.JsonConvert.SerializeObject(Models.Config.ItemAttributes));
        }

        private void BtnPreviewIcons_Click(object sender, EventArgs e)
        {
            Models.Config.EnablePreviewItemIcons = true;
            btnPreviewIcons.Enabled = !Models.Config.EnablePreviewItemIcons;
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            if (Models.Config.ItemAttributes != null)
            {
                File.WriteAllText("Config.json", Newtonsoft.Json.JsonConvert.SerializeObject(Models.Config.ItemAttributes));
            }
        }
    }
}
