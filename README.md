# Customer Marketing Frequency Report Generator

An implementation of API to create marketing report showing on which days each customer will receive marketting.

Application is developed in Visual Studio Code using C# targetting dotnet core 5

### MarketingReportService

Contains API code that received report request as post. The input is validated, marketing report for the next 90 days is generated and posted back as a string.

The report generation logic is carried out in build method of the Report class.

### MarketingReportService.Tests

Contains unit tests for Report generation logic.
