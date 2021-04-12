using System;

namespace MarketingReportService
{
    public interface IReport
    {
        void Initialise(DateTime reportStartDate, int days = 90);
        void Build(String customerName, MarketingFrequency marketingFrequenceyChoice);
    }
}