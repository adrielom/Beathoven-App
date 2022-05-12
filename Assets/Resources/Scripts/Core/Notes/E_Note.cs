using Beathoven.Core.Note;
using Beathoven.Core.Time;

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
        public INoteTime noteTime { get; set; }
        public override bool Equals(object obj)
        {
            return ((IMusicNote)obj).name == this.name;
        }

        public override string ToString()
        {
            return $"{notePitch}{name}";
        }

    }
}