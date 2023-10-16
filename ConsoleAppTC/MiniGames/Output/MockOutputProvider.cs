using System.Collections.Generic;

namespace MiniGames {
    public class MockOutputProvider : IOutputProvider {
        private List<string> m_outputHistory = new List<string>();

        public void WriteLine(string message)
        {
            m_outputHistory.Add(message);
        }

        public List<string> GetOutputHistory()
        {
            return m_outputHistory;
        }
    }
}
