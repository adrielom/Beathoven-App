namespace Beathoven.Core.GameType
{
    interface IGameType
    {
        uint notePoolCount { get; set; }
        void Initialize();
    }
}