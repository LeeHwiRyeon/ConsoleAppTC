using MiniGames;

namespace MiniGameTC {
    internal class RockPaperScissorsTestCaseBase : ITestCase {
        protected RockPaperScissors m_miniGame;
        protected TCInputProvider m_inputProvider;
        public TCResult Result { get; private set; }

        public virtual void OnInitialize()
        {
            Result = new TCResult();
            m_miniGame = new RockPaperScissors();
            m_inputProvider = new TCInputProvider();
            m_miniGame.Init(m_inputProvider);
        }

        public virtual TCResult OnUpdate()
        {
            return Result;
        }

        public virtual void OnClose()
        {

        }
    }
}