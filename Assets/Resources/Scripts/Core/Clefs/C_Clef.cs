namespace Beathoven.Core.Clef
{
    using UnityEngine;
    class C_Clef : IClef
    {
        public string initialNote { get; set; } = "F";

        public void RenderCleff(SpriteRenderer renderer)
        {
            renderer.transform.position = new Vector3(-2.5f, 3.70f, 0);
            renderer.sprite = Resources.Load("Images/SVGs/Clefs/CClef", typeof(Sprite)) as Sprite;
        }
    }
}