namespace MiniGames {
    public interface IGame {
        IInputProvider InputProvider { get; }
        IOutputProvider OutputProvider { get; }
        void Init(IInputProvider inputProvider, IOutputProvider outputProvider);
        GameResult Play();
    }

    public enum GameResult {
        Win,
        Draw,
        Lose
    }
}