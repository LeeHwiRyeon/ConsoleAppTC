using MiniGames;
using System;

namespace MiniGameTester {
    public class NGG_WinTestScenario : NGG_TestScenarioBase {
        public override TestScenarioReport ExecuteScenario()
        {
            try {
                m_game.SetSecretNumber(50);
                m_inputProvider.SetInputs("50");

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