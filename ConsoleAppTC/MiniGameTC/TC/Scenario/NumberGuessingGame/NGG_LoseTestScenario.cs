using MiniGames;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniGameTC {
    internal class NGG_LoseTestScenario : NGG_TestScenarioBase {
        public override TestScenarioReport ExecuteScenario()
        {
            // 테스트를 위한 숫자 설정 (예: 42)
            m_game.SetSecretNumber(42);

            // 올바르지 않은 숫자를 10번 추측하도록 입력 설정
            m_inputProvider.SetInputs("10", "20", "30", "40", "50", "60", "70", "80", "90", "100");

            var gameResult = m_game.Play();

            if (gameResult == GameResult.Lose) {
                Report.Status = "Success";
            } else {
                Report.Status = "Failed";
                Report.ErrorMessage = "The game did not result in a loss as expected.";
            }

            return Report;
        }
    }
}
