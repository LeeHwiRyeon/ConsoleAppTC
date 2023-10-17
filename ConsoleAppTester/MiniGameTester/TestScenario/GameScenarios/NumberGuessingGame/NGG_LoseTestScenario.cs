using MiniGames;

namespace MiniGameTester {
    internal class NGG_LoseTestScenario : NGG_TestScenarioBase {
        public override TestScenarioReport ExecuteScenario()
        {
            m_game.SetSecretNumber(42);
            m_inputProvider.SetInputs("10", "20", "30", "40", "50", "60", "70", "80", "90", "100");
            var gameResult = m_game.Play();
            if (gameResult == GameResult.Lose) {
                Report.Status = "Success";
                Report.AppendHistory("The scenario completed successfully.");
            } else {
                Report.Status = "Failed";
                Report.ErrorMessage = "The game did not result in a loss as expected.";
            }

            return Report;
        }
    }
}
