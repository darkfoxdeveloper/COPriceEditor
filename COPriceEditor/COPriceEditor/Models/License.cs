namespace COPriceEditor.Models
{
    public class License
    {
        public string LicenseId { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public bool Enabled { get; set; }
        public LicenseType Type { get; set; }
    }
    public enum LicenseType
    {
        Free,
        Premium
    }
    public class LicenseManager
    {
        public LicenseManager(string Id)
        {
            RegisteredLicense = GetLicenseFromId(Id);

        }
        private License _RegisteredLicense;

        public License RegisteredLicense { get => _RegisteredLicense; set => _RegisteredLicense = value; }

        public bool IsEnabledLicense()
        {
            return RegisteredLicense.Enabled;
        }
        public bool IsExpired()
        {
            return DateTime.Now > RegisteredLicense.LicenseExpiration;
        }
        public License GetLicenseFromId(string Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://pastebin.com/raw/cCdbhkrX").Result;
            string JSON = response.Content.ReadAsStringAsync().Result;
            List<License> validLicenses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<License>>(JSON);
            return validLicenses.Where(x => x.LicenseId == Id).FirstOrDefault();
        }
    }
}
