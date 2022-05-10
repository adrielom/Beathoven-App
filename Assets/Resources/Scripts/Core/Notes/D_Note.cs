using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class D_Note : IMusicNote
    {
        public D_Note()
        {
        }

        public D_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "D";
        public uint notePitch { get; set; }
        public bool isAccident { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public INoteAccident noteAccident { get; set; }
        public INoteTime noteTime { get; set; }

    }
}