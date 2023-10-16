using MiniGames;

namespace MiniGameTC {
    internal class RPSTC_DrawTestCase : RockPaperScissorsTestCaseBase {
        public override TCResult OnUpdate()
        {
            m_inputProvider.SetInput("가위");
            m_miniGame.SetComputerChoice("가위");
            if (m_miniGame.Play() != GameResult.Draw) {
                Result.Status = "Failed";
                Result.ErrorMessage = "Scenario 1: Draw failed!";
                return Result;
            }

            m_inputProvider.SetInput("보");
            m_miniGame.SetComputerChoice("보");
            if (m_miniGame.Play() != GameResult.Draw) {
                Result.Status = "Failed";
                Result.ErrorMessage = "Scenario 2: Draw failed!";
                return Result;
            }

            m_inputProvider.SetInput("바위");
            m_miniGame.SetComputerChoice("바위");
            if (m_miniGame.Play() != GameResult.Draw) {
                Result.Status = "Failed";
                Result.ErrorMessage = "Scenario 3: Draw failed!";
                return Result;
            }
            
            Result.Status = "Success";
            return Result;
        }
    }
}
