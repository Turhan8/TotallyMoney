using System.ComponentModel.DataAnnotations;

namespace MarketingReportService
{
    public class CustomerReportPreference
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public MarketingFrequency Frequency { get; set; }
    }
}