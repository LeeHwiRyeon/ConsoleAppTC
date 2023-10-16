namespace MiniGames {
    public interface IGame {
        void Init(IInputProvider inputProvider);
        GameResult Play();
    }

    public enum GameResult {
        Win,
        Draw,
        Lose
    }
}