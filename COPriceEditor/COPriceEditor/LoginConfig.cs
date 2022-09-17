namespace COPriceEditor
{
    public partial class LoginConfig : Krypton.Toolkit.KryptonForm
    {
        public LoginConfig()
        {
            InitializeComponent();
        }

        private void LoginConfig_Load(object sender, EventArgs e)
        {
            //List<Models.License> licenses = new();
            //licenses.Add(new Models.License() { LicenseId = Guid.NewGuid().ToString(), LicenseExpiration = DateTime.Now.AddYears(1), Enabled = true });
            //File.WriteAllText("Licenses.json", Newtonsoft.Json.JsonConvert.SerializeObject(licenses));//
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (tbxLicenseId.Text == Models.Config.RegisteredLicenseId)
            {
                if (Models.Config.ConfigForm.IsDisposed)
                {
                    Models.Config.ConfigForm = new Config();
                }
                Krypton.Toolkit.KryptonMessageBox.Show("Login successfully", "Login OK", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.EXCLAMATION);
                Models.Config.ConfigForm.Show(this);
            } else
            {
                Krypton.Toolkit.KryptonMessageBox.Show("Invalid LicenseId", "Login FAIL", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.ERROR);
            }
        }
    }
}
