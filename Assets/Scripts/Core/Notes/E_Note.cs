using Beathoven.Core.Note;

namespace Beathoven.Core.Notes
{
    public class E_Note : IMusicNote
    {
        public E_Note()
        {
        }

        public E_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "E";
        public uint notePitch { get; set; }
        public bool isAccident { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public INoteAccident noteAccident { get; set; }

    }
}