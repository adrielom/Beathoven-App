using Beathoven.Core.Note;

namespace Beathoven.Core.Notes
{
    public class A_Note : IMusicNote
    {
        public A_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public A_Note()
        {

        }

        public string name { get; set; } = "A";
        public uint notePitch { get; set; }
        public bool isAccident { get; } = false;
        public INoteAccident noteAccident { get; set; }

    }
}