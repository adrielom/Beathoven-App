using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class G_Note : IMusicNote
    {
        public G_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public G_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }
        public string name { get; set; } = "G";
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