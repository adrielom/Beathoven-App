using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class C_NoteAccident : IMusicNote, INoteAccident
    {
        public C_NoteAccident()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public C_NoteAccident(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public string name { get; set; } = "C";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }
        public string flat { get { return $"Db"; } }
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