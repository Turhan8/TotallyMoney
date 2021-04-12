using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MarketingReportService.Tests
{
    [TestClass]
    public class MarketingFrequencyTests
    {
        [TestMethod]
        public void MarketingFrequencyNeverTest()
        {
            DateTime d = new DateTime(2020, 6, 1);
            MarketingFrequency marketingFrequency = new() { Never = true };
            bool isPreferedDay = marketingFrequency.IsPreferedDay(d);
            Assert.IsFalse(isPreferedDay);
        }

        [TestMethod]
        public void MarketingFrequencyEverydayTest()
        {
            DateTime d = new DateTime(2020, 6, 1);
            MarketingFrequency marketingFrequency = new() { Always = true };
            bool isPreferedDay = marketingFrequency.IsPreferedDay(d);
            Assert.IsTrue(isPreferedDay);
        }

        [TestMethod]
        public void MarketingFrequencyWeekdaysTest()
        {
            DateTime monday = new DateTime(2020, 6, 1);
            DateTime tuesday = monday.AddDays(1);
            DateTime wednesday = tuesday.AddDays(1);

            MarketingFrequency marketingFrequency = new() { DayInWeek = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday } };

            Assert.IsTrue(marketingFrequency.IsPreferedDay(monday));
            Assert.IsFalse(marketingFrequency.IsPreferedDay(tuesday));
            Assert.IsTrue(marketingFrequency.IsPreferedDay(wednesday));
        }

        [TestMethod]
        public void MarketingScheduleReportDayOfMonthTest()
        {
            DateTime d1 = new DateTime(2020, 6, 1);
            DateTime d2 = d1.AddDays(1);
            DateTime d3 = d2.AddDays(1);

            MarketingFrequency marketingFrequency = new() { DayOfMonth = 3 };

            Assert.IsFalse(marketingFrequency.IsPreferedDay(d1));
            Assert.IsFalse(marketingFrequency.IsPreferedDay(d2));
            Assert.IsTrue(marketingFrequency.IsPreferedDay(d3));
        }
    }
}