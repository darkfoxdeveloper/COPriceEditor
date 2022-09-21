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

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (tbxLicenseId.Text == Models.Config.LicenseManager.RegisteredLicense.LicenseId)
            {
                if (Models.Config.ConfigForm.IsDisposed)
                {
                    Models.Config.ConfigForm = new Config();
                }
                if (Models.Config.LicenseManager.RegisteredLicense != null && Models.Config.LicenseManager.RegisteredLicense.Type == Models.LicenseType.Premium) {
                    Krypton.Toolkit.KryptonMessageBox.Show("Login successfully", "Login OK", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.EXCLAMATION);
                    Models.Config.ConfigForm.Show(this);
                } else
                {
                    Krypton.Toolkit.KryptonMessageBox.Show("Your license is not PREMIUM", "Login OK", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.EXCLAMATION);
                }
            } else
            {
                Krypton.Toolkit.KryptonMessageBox.Show("Invalid LicenseId", "Login FAIL", MessageBoxButtons.OK, Krypton.Toolkit.KryptonMessageBoxIcon.ERROR);
            }
        }
    }
}
