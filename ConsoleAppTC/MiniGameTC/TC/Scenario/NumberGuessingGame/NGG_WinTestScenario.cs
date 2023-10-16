using MiniGames;
using System;

namespace MiniGameTC {
    public class NGG_WinTestScenario : NGG_TestScenarioBase {
        public override TestScenarioReport ExecuteScenario()
        {
            try {
                m_game.Init(new MockInputProvider(), new MockOutputProvider());
                m_game.SetSecretNumber(50); // 예를 들면, 우리가 원하는 승리 숫자를 설정합니다.
                
                var result = m_game.Play();
                if (result == GameResult.Win) {
                    Report.Status = "Success";
                    Report.ErrorMessage = "";
                    Report.AppendHistory("The scenario completed successfully.");
                } else {
                    Report.Status = "Failed";
                    Report.ErrorMessage = "Expected a win but got a loss.";
                    Report.AppendHistory("The scenario did not produce the expected result.");
                }
            } catch (Exception ex) {
                Report.Status = "Error";
                Report.ErrorMessage = ex.Message;
                Report.AppendHistory($"An error occurred: {ex.Message}");
            }

            return Report;
        }
    }
}