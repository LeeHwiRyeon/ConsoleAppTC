using MiniGames;
using System.Reflection;

namespace MiniGameTC {
    [IgnoreScenario]
    internal abstract class RPS_TestScenarioBase : ITestScenario {
        protected RockPaperScissors m_miniGame;
        protected MockInputProvider m_inputProvider;
        protected MockOutputProvider m_outputProvider;
        public TestScenarioReport Report { get; protected set; }

        public virtual void OnInitialize()
        {
            Report = new TestScenarioReport(GetType().Name);
            m_miniGame = new RockPaperScissors();
            m_inputProvider = new MockInputProvider();
            m_outputProvider = new MockOutputProvider();
            m_miniGame.Init(m_inputProvider, m_outputProvider);
        }

        public abstract TestScenarioReport ExecuteScenario();

        public virtual void OnFinalize()
        {

        }
    }
}