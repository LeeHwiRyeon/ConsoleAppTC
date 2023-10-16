using System;
using MiniGames;

namespace ConsoleApp {
    internal class Program {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning) {
                Console.WriteLine("어떤 게임을 하시겠습니까?");
                Console.WriteLine("1: TC 시작");
                Console.WriteLine("2: 가위바위보");
                Console.WriteLine("3: 숫자 추측 게임");
                Console.WriteLine("0: 종료");
                Console.WriteLine("");

                switch (Console.ReadLine()) {
                    case "1":
                        break;

                    case "2":
                        var rpsGame = new RockPaperScissors();
                        rpsGame.Init(new ConsoleInputProvider());
                        rpsGame.Play();
                        break;

                    case "3":
                        var numberGame = new NumberGuessingGame();
                        numberGame.Init(new ConsoleInputProvider());
                        numberGame.Play();
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("게임을 종료합니다.");
                        break;

                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                        break;
                }
                Console.WriteLine("");
            }
        }
    }
}
