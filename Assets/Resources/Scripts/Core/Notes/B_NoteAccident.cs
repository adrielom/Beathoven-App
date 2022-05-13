using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class B_NoteAccident : IMusicNote, INoteAccident
    {

        public B_NoteAccident()
        {
            notePitch = 4;
            noteTime = new QuarterNoteTime();
        }

        public B_NoteAccident(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;

        }
        public string name { get; set; } = "B";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }
        public string flat { get { return $"{name}b"; } }
        public string sharp { get { return $"{name}#"; } }

        public override bool Equals(object obj)
        {
            bool condition = ((IMusicNote)obj).name == this.sharp ||
                             ((IMusicNote)obj).name == this.flat;
            return condition;
        }

        public override string ToString()
        {
            return $"{notePitch}{flat}";
        }
    }
}