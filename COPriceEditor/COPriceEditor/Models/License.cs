namespace COPriceEditor.Models
{
    public class License
    {
        public string LicenseId { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public bool Enabled { get; set; }
    }
    public class LicenseManager
    {
        public LicenseManager()
        {

        }
        public bool IsValidLicense(string Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://pastebin.com/raw/cCdbhkrX").Result;
            string JSON = response.Content.ReadAsStringAsync().Result;
            List<License> validLicenses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<License>>(JSON);
            bool valid = validLicenses != null && validLicenses.Count > 0 && validLicenses.Where(x => x.LicenseId == Id && x.Enabled).Any();
            return valid;
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
