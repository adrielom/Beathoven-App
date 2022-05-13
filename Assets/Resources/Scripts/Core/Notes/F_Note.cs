using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class F_Note : IMusicNote
    {
        public F_Note()
        {
            notePitch = 4;
            noteTime = new QuarterNoteTime();
        }

        public F_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public string name { get; set; } = "F";
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