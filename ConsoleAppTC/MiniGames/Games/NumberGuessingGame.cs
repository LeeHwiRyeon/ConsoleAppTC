using System;
using MiniGames;

namespace MiniGames {
    public class NumberGuessingGame : IGame {
        Random m_random = new Random();
        IInputProvider m_inputProvider;
        public void Init(IInputProvider inputProvider)
        {
            m_inputProvider = inputProvider;
        }

        public void Play()
        {
            Console.WriteLine("숫자 추측 게임에 오신 것을 환영합니다!");
            Console.WriteLine("1부터 100 사이의 숫자를 생각하겠습니다. 당신은 그 숫자를 맞혀야 합니다.");

            int secretNumber = m_random.Next(1, 101);
            int userGuess;
            int attempts = 0;

            do {
                Console.Write("당신의 추측을 입력하세요: ");
                var input = m_inputProvider.GetInput();
                if (input?.ToLower() == "종료") {
                    Console.WriteLine("숫자 추측 게임을 종료합니다.");
                    return;
                }

                var isNumber = int.TryParse(input, out userGuess);
                if (!isNumber) {
                    Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                    continue;
                }

                attempts++;

                if (userGuess < secretNumber) {
                    Console.WriteLine("높게!");
                } else if (userGuess > secretNumber) {
                    Console.WriteLine("낮게!");
                } else if (input.ToLower() == "종료") {
                    Console.WriteLine("숫자 추측 게임을 종료합니다.");
                    return;
                }

            } while (userGuess != secretNumber);

            Console.WriteLine($"축하합니다! {attempts}번 만에 맞혔습니다.");
        }
    }
}
