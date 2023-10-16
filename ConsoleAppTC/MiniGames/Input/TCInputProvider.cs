using System;

namespace MiniGames {
    public class TCInputProvider : IInputProvider {
        public string Input;
        public void SetInput(string input)
        {
            Input = input;
        }

        public string GetInput()
        {
            return Input;
        }
    }

}