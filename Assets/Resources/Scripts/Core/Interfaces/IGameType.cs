namespace Beathoven.Core.GameType
{
    public interface IGameType
    {
        uint notePoolCount { get; set; }
        void Initialize();
        void OnGameEnd();

    }
}