using System;
using System.Collections.Generic;

namespace MiniGames {
    public class MockOutputProvider : IOutputProvider {
        private List<string> m_outputHistory = new List<string>();
        public delegate void ReportCallback(string message);
        public ReportCallback OnWriteLineCalled { get; set; }

        public void WriteLine(string message)
        {
            m_outputHistory.Add(message);
            OnWriteLineCalled?.Invoke(message);
        }

        public List<string> GetOutputHistory()
        {
            return m_outputHistory;
        }
    }
}
