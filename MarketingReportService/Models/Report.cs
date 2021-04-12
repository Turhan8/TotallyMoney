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
            foreach (DateTime d in reportDictionary.Keys)
            {
                if (marketingFrequencyChoice.IsPreferedDay(d))
                {
                    reportDictionary[d].Add(customerName);
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