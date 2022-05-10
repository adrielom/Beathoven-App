using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class F_Note : IMusicNote
    {
        public F_Note()
        {
        }

        public F_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "F";
        public uint notePitch { get; set; }
        public bool isAccident { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public INoteAccident noteAccident { get; set; }
        public INoteTime noteTime { get; set; }

    }
}