using System.Text;

namespace MiniGameTC {
    public class TestScenarioReport {
        public TestScenarioReport(string name)
        {
            Name = name;
        }

        private StringBuilder m_history = new StringBuilder();
        public string Name { get; private set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }

        public void AppendHistory(string message)
        {
            m_history.AppendLine(message);
        }

        public string GetFullReport()
        {
            return m_history.ToString();
        }
    }
}

