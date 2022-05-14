namespace Beathoven.Core.Clef
{
    using UnityEngine;
    class F_Clef : IClef
    {
        public string initialNote { get; set; } = "G";

        public void RenderCleff(SpriteRenderer renderer)
        {
            renderer.transform.position = new Vector3(-2.3f, 3.82f, 0);
            renderer.sprite = Resources.Load("Images/SVGs/Clefs/FClef", typeof(Sprite)) as Sprite;
        }
    }
}