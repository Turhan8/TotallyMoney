using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MarketingReportService
{
    public class MarketingFrequency
    {
        public bool? Never { get; set; }
        public bool? Always { get; set; }
        public List<DayOfWeek> DayInWeek { get; set; }

        [Range(1, 28, ErrorMessage = "Only allowed to choose between 1-28")]
        public int? DayOfMonth { get; set; }

        public bool IsPreferedDay(DateTime d)
        {
            if (Never == true)
            {
                return false;
            }
            else if (Always == true)
            {
                return true;
            }
            else if (DayInWeek != null)
            {
                if (DayInWeek.Any<DayOfWeek>(x => x == d.DayOfWeek))
                {
                    return true;
                }
            }
            else if (DayOfMonth != null)
            {
                if (DayOfMonth == d.Day)
                {
                    return true;
                }
            }

            return false;
        }
    }
}