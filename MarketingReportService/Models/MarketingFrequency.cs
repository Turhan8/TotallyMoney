using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketingReportService
{
    public class MarketingFrequency
    {
        public bool? Never { get; set; }
        public bool? Always { get; set; }
        public List<DayOfWeek> DayInWeek { get; set; }

        [Range(1, 28, ErrorMessage = "Only allowed to choose between 1-28")]
        public int? DayOfMonth { get; set; }
    }
}