using System;
using System.Collections.Generic;
using System.IO;

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
                Console.WriteLine(report.GetFullReport());
                Console.WriteLine();
            }
        }

        public string GenerateReport()
        {
            string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string baseDirectory = "path_to_reports_directory";
            if (!Directory.Exists(baseDirectory)) {
                Directory.CreateDirectory(baseDirectory);
            }
            foreach (var report in reports) {
                string successIndicator = report.Status == "Success" ? "O" : "X";
                string fileName = $"Report_{report.Name}_{currentDateTime}_{successIndicator}.txt";
                string fullPath = Path.Combine(baseDirectory, fileName);
                File.WriteAllText(fullPath, report.GetFullReport());
            }

            return baseDirectory;
        }
    }
}