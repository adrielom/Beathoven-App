using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class C_NoteAccident : MusicNote, INoteAccident
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

        public override string name { get; set; } = "C";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }


        public string flat { get { return $"Db"; } }
        public string sharp { get { return $"{name}#"; } }

        public override bool Equals(object obj)
        {
            bool condition = ((MusicNote)obj).name == this.sharp ||
                             ((MusicNote)obj).name == this.flat;
            return condition;
        }

        public override string ToString()
        {
            return $"{notePitch}{flat}";
        }
    }
}