namespace MiniGames {
    public interface IGame {
        void Init(IInputProvider inputProvider);
        void Play();
    }
}