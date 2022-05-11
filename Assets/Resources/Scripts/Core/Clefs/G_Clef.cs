namespace Beathoven.Core.Clef
{
    using UnityEngine;
    class G_Clef : IClef
    {
        public string initialNote { get; set; } = "E";

        public void RenderCleff(SpriteRenderer renderer)
        {
            renderer.transform.position = new Vector3(-2.7f, 5.62f, 0);
            renderer.sprite = Resources.Load("Images/SVGs/Clefs/GClef", typeof(Sprite)) as Sprite;
        }
    }
}