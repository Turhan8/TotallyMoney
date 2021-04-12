using System;
using System.Collections.Generic;
using MarketingReportService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace demoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarkettingReportController : ControllerBase
    {
        private readonly ILogger<MarkettingReportController> logger;
        private readonly IReport report;

        public MarkettingReportController(ILogger<MarkettingReportController> l, IReport r)
        {
            logger = l;
            report = r;
        }

        [HttpPost]
        public IActionResult Post(List<CustomerReportPreference> customerReportFrequencyChoices)
        {
            if (ModelState.IsValid)
            {
                report.Initialise(reportStartDate: DateTime.Today);
                foreach (CustomerReportPreference choice in customerReportFrequencyChoices)
                {
                    report.Build(choice.Name, choice.Frequency);
                }
                return Ok(report.ToString());
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}