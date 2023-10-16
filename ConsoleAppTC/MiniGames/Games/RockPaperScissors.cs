using System;
using MiniGames;

namespace MiniGames {
    public class RockPaperScissors : IGame {
        Random m_random = new Random();
        IInputProvider m_inputProvider;
        private string m_computerChoice;  // 컴퓨터의 선택
        string[] choices = { "가위", "바위", "보" };

        public void Init(IInputProvider inputProvider)
        {
            m_inputProvider = inputProvider;
        }

        public void SetComputerChoice(string choice = null)
        {
            m_computerChoice = choice;
        }

        public GameResult Play()
        {
            Console.WriteLine("가위바위보 게임에 오신 것을 환영합니다!");

            do {
                Console.WriteLine("\n가위, 바위, 보 중 하나를 선택하세요. (종료하려면 '종료'를 입력하세요)");

                string userChoice = m_inputProvider.GetInput().Trim();
                if (userChoice != null && userChoice.ToLower() == "종료") {
                    Console.WriteLine("가위바위보 게임을 종료합니다.");
                    return GameResult.Draw;
                }

                if (userChoice != "가위" && userChoice != "바위" && userChoice != "보") {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

                if (string.IsNullOrEmpty(m_computerChoice)) {
                    int computerChoiceNum = m_random.Next(3);
                    m_computerChoice = choices[computerChoiceNum];
                }

                Console.WriteLine($"컴퓨터의 선택: {m_computerChoice}");
                if (userChoice == m_computerChoice) {
                    Console.WriteLine("비겼습니다!");
                    return GameResult.Draw;
                } else if (userChoice == "가위" && m_computerChoice == "보" ||
                           userChoice == "바위" && m_computerChoice == "가위" ||
                           userChoice == "보" && m_computerChoice == "바위") {
                    Console.WriteLine("당신이 이겼습니다!");
                    return GameResult.Win;
                } else {
                    Console.WriteLine("컴퓨터가 이겼습니다!");
                    return GameResult.Lose;
                }
            } while (true);
        }
    }
}
