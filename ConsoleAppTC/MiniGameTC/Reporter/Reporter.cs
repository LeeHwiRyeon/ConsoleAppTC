using System;
using System.Collections.Generic;

namespace MiniGameTC {
    internal class Reporter {
        private List<TestScenarioReport> reports = new List<TestScenarioReport>();

        public void AddReport(TestScenarioReport report)
        {
            reports.Add(report);
        }

        public void PrintAllReports()
        {
            foreach (var report in reports) {
                Console.WriteLine($"=== {report.Name} Report ===");
                Console.WriteLine($"Status: {report.Status}");
                Console.WriteLine($"Error Message: {report.ErrorMessage}");
                Console.WriteLine("Details:");
                Console.WriteLine(report.GetRecords());
                Console.WriteLine();
            }
        }

        // ... (추후 추가될 다른 메서드들)
    }
}