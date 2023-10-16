using System.Collections.Generic;

namespace MiniGames {
    public interface IOutputProvider {
        void WriteLine(string message);
        List<string> GetOutputHistory();
    }
}