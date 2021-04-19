using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingReportService.Tests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void MarketingScheduleReportNeverTest()
        {
            CustomerReportPreference c = new()
            {
                Name = "Ali",
                Frequency = new MarketingFrequency()
                {
                    Never = true
                }
            };

            IReport r = new Report();
            DateTime reportStartDate = new DateTime(2020, 6, 1);
            r.Initialise(reportStartDate, 1);
            r.Build(c.Name, c.Frequency);


            StringBuilder sb = new();
            sb.AppendLine($"{reportStartDate.ToString("ddd dd-MMMM-yyyy")} ");
            string expectedValue = sb.ToString();

            Assert.AreEqual(expectedValue, r.ToString());
        }

        [TestMethod]
        public void MarketingScheduleReportEverydayTest()
        {
            CustomerReportPreference c = new()
            {
                Name = "Ali",
                Frequency = new MarketingFrequency()
                {
                    Always = true
                }
            };

            IReport r = new Report();
            DateTime reportStartDate = new DateTime(2020, 6, 1);
            r.Initialise(reportStartDate, 1);
            r.Build(c.Name, c.Frequency);


            StringBuilder sb = new();
            sb.AppendLine($"{reportStartDate.ToString("ddd dd-MMMM-yyyy")} {c.Name}");
            string expectedValue = sb.ToString();

            Assert.AreEqual(expectedValue, r.ToString());
        }

        [TestMethod]
        public void MarketingScheduleReportWeekDaysTest()
        {
            CustomerReportPreference c = new()
            {
                Name = "Ali",
                Frequency = new MarketingFrequency()
                {
                    DayInWeek = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday }
                }
            };

            DateTime reportStartDate = new DateTime(2020, 6, 1);
            DateTime dayTwo = reportStartDate.AddDays(1);
            DateTime dayThree = dayTwo.AddDays(1);

            IReport r = new Report();
            r.Initialise(reportStartDate, 3);
            r.Build(c.Name, c.Frequency);

            StringBuilder sb = new();
            sb.AppendLine($"{reportStartDate.ToString("ddd dd-MMMM-yyyy")} {c.Name}");
            sb.AppendLine($"{dayTwo.ToString("ddd dd-MMMM-yyyy")} ");
            sb.AppendLine($"{dayThree.ToString("ddd dd-MMMM-yyyy")} {c.Name}");

            string expectedValue = sb.ToString();

            Assert.AreEqual(expectedValue, r.ToString());
        }

        [TestMethod]
        public void MarketingScheduleReportDayOfMonthTest()
        {
            CustomerReportPreference c = new()
            {
                Name = "Ali",
                Frequency = new MarketingFrequency()
                {
                    DayOfMonth = 3
                }
            };

            DateTime reportStartDate = new DateTime(2020, 6, 1);
            DateTime dayTwo = reportStartDate.AddDays(1);
            DateTime dayThree = dayTwo.AddDays(1);

            IReport r = new Report();
            r.Initialise(reportStartDate, 3);
            r.Build(c.Name, c.Frequency);

            StringBuilder sb = new();
            sb.AppendLine($"{reportStartDate.ToString("ddd dd-MMMM-yyyy")} ");
            sb.AppendLine($"{dayTwo.ToString("ddd dd-MMMM-yyyy")} ");
            sb.AppendLine($"{dayThree.ToString("ddd dd-MMMM-yyyy")} {c.Name}");

            string expectedValue = sb.ToString();

            Assert.AreEqual(expectedValue, r.ToString());
        }
    }
}