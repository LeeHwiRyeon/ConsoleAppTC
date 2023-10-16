using System;
using System.Collections.Generic;

namespace MiniGames {
    public class ConsoleInputProvider : IInputProvider {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void SetInputs(params string[] inputs)
        {
        }

        public void Reset()
        {
        }
    }
}
