using Beathoven.Core.Note;

namespace Beathoven.Core.Notes
{
    public class C_Note : IMusicNote
    {
        public C_Note()
        {
        }

        public C_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "C";
        public uint notePitch { get; set; }
        public bool isAccident { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public INoteAccident noteAccident { get; set; }

    }
}