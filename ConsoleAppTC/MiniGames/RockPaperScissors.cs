using System;

namespace MiniGames {
    public class RockPaperScissors : IGame {
        Random m_random = new Random();

        public void Play()
        {
            Console.WriteLine("가위바위보 게임에 오신 것을 환영합니다!");

            while (true) {
                Console.WriteLine("\n가위, 바위, 보 중 하나를 선택하세요. (종료하려면 '종료'를 입력하세요)");

                string userChoice = Console.ReadLine()?.Trim();
                if (userChoice != null && userChoice.ToLower() == "종료") {
                    Console.WriteLine("가위바위보 게임을 종료합니다.");
                    return;
                }

                if (userChoice != "가위" && userChoice != "바위" && userChoice != "보") {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

                int computerChoiceNum = m_random.Next(3);
                string[] choices = { "가위", "바위", "보" };
                string computerChoice = choices[computerChoiceNum];

                Console.WriteLine($"컴퓨터의 선택: {computerChoice}");

                if (userChoice == computerChoice) {
                    Console.WriteLine("비겼습니다!");
                } else if (userChoice == "가위" && computerChoice == "보" ||
                             userChoice == "바위" && computerChoice == "가위" ||
                             userChoice == "보" && computerChoice == "바위") {
                    Console.WriteLine("당신이 이겼습니다!");
                } else {
                    Console.WriteLine("컴퓨터가 이겼습니다!");
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
