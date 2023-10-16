using System;

namespace MiniGames {
    public class ConsoleInputProvider : IInputProvider {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
