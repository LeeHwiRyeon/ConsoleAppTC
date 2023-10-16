using System;

namespace MiniGames {
    public class NumberGuessingGame : IGame {
        Random m_random = new Random();
        public IInputProvider InputProvider { get; private set; }
        public IOutputProvider OutputProvider { get; private set; }
        private const int MAX_ATTEMPTS = 10;
        private int m_secretNumber;

        public void Init(IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            InputProvider = inputProvider;
            OutputProvider = outputProvider;
            SetRandomNumber(); // 게임 초기화 시 랜덤 숫자 설정
        }

        // 숫자 설정을 위한 별도의 메서드
        public void SetRandomNumber()
        {
            m_secretNumber = m_random.Next(1, 101);
        }

        // 테스트를 위한 숫자 설정 메서드
        public void SetSecretNumber(int number)
        {
            m_secretNumber = number;
        }
        public void Print(string message)
        {
            OutputProvider.WriteLine(message);
        }

        public GameResult Play()
        {
            OutputProvider.WriteLine("숫자 추측 게임에 오신 것을 환영합니다!");
            OutputProvider.WriteLine($"1부터 100 사이의 숫자를 생각하겠습니다. 당신은 그 숫자를 {MAX_ATTEMPTS}회 동안 맞혀야 합니다.");

            int userGuess;
            int attempts = 0;

            do {
                Print("당신의 추측을 입력하세요: ");
                var input = InputProvider.GetInput();
                if (input.ToLower() == "종료") {
                    Print("숫자 추측 게임을 종료합니다.");
                    return GameResult.Lose;
                }

                var isNumber = int.TryParse(input, out userGuess);
                if (!isNumber) {
                    Print("잘못된 입력입니다. 숫자를 입력해주세요.");
                    continue;
                }

                attempts++;

                if (userGuess < m_secretNumber) {
                    Print("높게!");
                } else if (userGuess > m_secretNumber) {
                    Print("낮게!");
                }

                if (attempts >= MAX_ATTEMPTS) {
                    Print($"최대 시도 횟수 ({MAX_ATTEMPTS}회)를 초과했습니다. 게임에서 패배하셨습니다.");
                    return GameResult.Lose;
                }

            } while (userGuess != m_secretNumber);

            Print($"축하합니다! {attempts}번 만에 맞혔습니다.");
            return GameResult.Win;
        }
    }
}
