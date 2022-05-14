using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class F_NoteAccident : MusicNote, INoteAccident
    {
        public F_NoteAccident()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }
        public F_NoteAccident(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }
        public override string name { get; set; } = "F";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }


        public string flat { get { return $"Gb"; } }
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