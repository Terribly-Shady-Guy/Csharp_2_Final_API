namespace Kaufmann_Final.Models
{
    public class InfractionDto
    {
        public string DriverLicenseNumber { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Offence { get; set; }
        public DateTime InfractionDate { get; set; }
        public decimal FineAmount { get; set; }
    }
}
