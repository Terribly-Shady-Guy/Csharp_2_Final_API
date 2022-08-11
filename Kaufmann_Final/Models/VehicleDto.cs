namespace Kaufmann_Final.Models
{
    public class VehicleDto
    {
        public string LicensePlateNumber { get; set; }
        public List<string> DriverLicenseNumbers { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public DateTime TitleDateIssued { get; set; }
    }
}
