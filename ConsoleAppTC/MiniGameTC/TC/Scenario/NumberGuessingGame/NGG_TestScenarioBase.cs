using MiniGames;
using System.Reflection;

namespace MiniGameTC {
    [IgnoreScenario]
    public abstract class NGG_TestScenarioBase : ITestScenario {
        protected NumberGuessingGame m_game;
        protected MockInputProvider m_inputProvider;
        protected MockOutputProvider m_outputProvider;
        public TestScenarioReport Report { get; protected set; }

        public virtual void OnInitialize()
        {
            Report = new TestScenarioReport(GetType().Name);
            m_game = new NumberGuessingGame();
            m_inputProvider = new MockInputProvider();
            m_outputProvider = new MockOutputProvider();
            m_game.Init(m_inputProvider, m_outputProvider);
        }

        public abstract TestScenarioReport ExecuteScenario();

        public virtual void OnFinalize()
        {
            // 후처리 작업 (해당 게임에 필요한 경우)
        }
    }
}