using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketingReportService
{
    public class Report : IReport
    {
        private Dictionary<DateTime, List<string>> reportDictionary;

        public Report()
        {
            reportDictionary = new();
        }

        public void Initialise(DateTime start, int days = 90)
        {
            DateTime end = start.AddDays(days);

            for (DateTime d = start; d < end; d = d.AddDays(1))
            {
                reportDictionary.Add(d, new List<string>());
            }
        }

        public void Build(String customerName, MarketingFrequency marketingFrequencyChoice)
        {
            if (marketingFrequencyChoice.Never == true)
            {
                return;
            }
            else if (marketingFrequencyChoice.Always == true)
            {
                foreach (List<string> names in reportDictionary.Values)
                {
                    names.Add(customerName);
                }
            }
            else if (marketingFrequencyChoice.DayInWeek != null)
            {
                foreach (DateTime d in reportDictionary.Keys)
                {
                    if (marketingFrequencyChoice.DayInWeek.Any<DayOfWeek>(x => x == d.DayOfWeek))
                    {
                        reportDictionary[d].Add(customerName);
                    }
                }
            }
            else if (marketingFrequencyChoice.DayOfMonth != null)
            {
                foreach (DateTime d in reportDictionary.Keys)
                {
                    if (marketingFrequencyChoice.DayOfMonth == d.Day)
                    {
                        reportDictionary[d].Add(customerName);
                    }
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DateTime d in reportDictionary.Keys)
            {
                sb.AppendLine($"{d.ToString("ddd dd-MMMM-yyyy")} {string.Join(",", reportDictionary[d])}");
            }
            return sb.ToString();
        }
    }
}