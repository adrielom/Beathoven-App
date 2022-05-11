namespace Beathoven.Core.Clef
{
    public interface IClef
    {
        void RenderCleff(UnityEngine.SpriteRenderer renderer);
        string initialNote { get; set; }
    }

}