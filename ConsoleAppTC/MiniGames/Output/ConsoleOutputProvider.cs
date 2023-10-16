using System;
using System.Collections.Generic;
using System.Text;

namespace MiniGames.Output {
    public class ConsoleOutputProvider : IOutputProvider {
        private List<string> m_outputHistory = new List<string>();

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
            m_outputHistory.Add(message);
        }

        public List<string> GetOutputHistory()
        {
            return m_outputHistory;
        }
    }
}
