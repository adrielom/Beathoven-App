using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class B_Note : IMusicNote
    {
        public B_Note()
        {
        }

        public B_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "B";
        public uint notePitch { get; set; }
        public bool isAccident { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public INoteAccident noteAccident { get; set; }
        public INoteTime noteTime { get; set; }

    }
}