using System;
using MiniGames;

namespace MiniGames {
    public class RockPaperScissors : IGame {
        Random m_random = new Random();
        public IInputProvider InputProvider { get; private set; }
        public IOutputProvider OutputProvider { get; private set; }
        private string m_computerChoice;  // 컴퓨터의 선택
        string[] choices = { "가위", "바위", "보" };

        public void Init(IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            InputProvider = inputProvider;
            OutputProvider = outputProvider;
        }

        public void SetComputerChoice(string choice = null)
        {
            m_computerChoice = choice;
        }
        public void Print(string message)
        {
            OutputProvider.WriteLine(message);
        }

        public GameResult Play()
        {
            Print("가위바위보 게임에 오신 것을 환영합니다!");

            do {
                Print("\n가위, 바위, 보 중 하나를 선택하세요. (종료하려면 '종료'를 입력하세요)");

                string userChoice = InputProvider.GetInput().Trim();
                if (userChoice.ToLower() == "종료") {
                    Print("가위바위보 게임을 종료합니다.");
                    return GameResult.Draw;
                }

                if (userChoice != "가위" && userChoice != "바위" && userChoice != "보") {
                    Print("잘못된 입력입니다.");
                    continue;
                }

                if (string.IsNullOrEmpty(m_computerChoice)) {
                    int computerChoiceNum = m_random.Next(3);
                    m_computerChoice = choices[computerChoiceNum];
                }

                Print($"컴퓨터의 선택: {m_computerChoice}");
                if (userChoice == m_computerChoice) {
                    Print("비겼습니다!");
                    return GameResult.Draw;
                }

                if (userChoice == "가위" && m_computerChoice == "보" ||
                    userChoice == "바위" && m_computerChoice == "가위" ||
                    userChoice == "보" && m_computerChoice == "바위") {
                    Print("당신이 이겼습니다!");
                    return GameResult.Win;
                }

                Print("컴퓨터가 이겼습니다!");
                return GameResult.Lose;
            } while (true);
        }
    }
}
