using System.Collections.Generic;

namespace MiniGames {
    public interface IInputProvider {
        string GetInput();
        void SetInputs(params string[] inputs);
        void Reset();
    }
}