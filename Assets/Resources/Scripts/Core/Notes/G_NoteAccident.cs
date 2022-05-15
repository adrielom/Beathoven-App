using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class G_NoteAccident : MusicNote, INoteAccident
    {
        public G_NoteAccident()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }
        public G_NoteAccident(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }
        public override string name { get; set; } = "G";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }


        public string flat { get { return $"Ab"; } }
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