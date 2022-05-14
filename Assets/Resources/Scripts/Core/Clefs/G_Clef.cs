namespace Beathoven.Core.Clef
{
    using UnityEngine;
    class G_Clef : IClef
    {
        public string initialNote { get; set; } = "E";

        public void RenderCleff(SpriteRenderer renderer)
        {
            renderer.sprite = Resources.Load("Images/SVGs/Clefs/GClef", typeof(Sprite)) as Sprite;
            renderer.transform.position = new Vector3(-2.3f, 3.62f, 0);
        }
    }
}