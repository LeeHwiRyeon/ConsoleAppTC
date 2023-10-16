using MiniGames;

namespace MiniGameTC {
    internal class RPS_UserWinTestScenario : RPS_TestScenarioBase {
        public override TestScenarioReport ExecuteScenario()
        {
            m_inputProvider.SetInputs("가위");
            m_miniGame.SetComputerChoice("보");
            if (m_miniGame.Play() != GameResult.Win) {
                Report.Status = "Failed";
                Report.ErrorMessage = "Scenario 1: User Win failed!";
                return Report;
            }

            m_inputProvider.SetInputs("바위");
            m_miniGame.SetComputerChoice("가위");
            if (m_miniGame.Play() != GameResult.Win) {
                Report.Status = "Failed";
                Report.ErrorMessage = "Scenario 2: User Win failed!";
                return Report;
            }

            m_inputProvider.SetInputs("보");
            m_miniGame.SetComputerChoice("바위");
            if (m_miniGame.Play() != GameResult.Win) {
                Report.Status = "Failed";
                Report.ErrorMessage = "Scenario 3: User Win failed!";
                return Report;
            }

            Report.Status = "Success";
            return Report;
        }
    }
}
