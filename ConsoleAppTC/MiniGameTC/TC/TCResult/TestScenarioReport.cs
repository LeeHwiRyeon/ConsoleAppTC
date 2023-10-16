using System.Text;

namespace MiniGameTC {
    public class TestScenarioReport {
        private StringBuilder m_history = new StringBuilder();
        public string Status { get; set; }
        public string ErrorMessage { get; set; }

        public void AppendHistory(string message)
        {
            m_history.AppendLine(message);
        }

        public string GetRecords()
        {
            return m_history.ToString();
        }
    }
}

