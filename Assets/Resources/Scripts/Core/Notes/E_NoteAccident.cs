using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class E_NoteAccident : MusicNote, INoteAccident
    {
        public E_NoteAccident()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }
        public E_NoteAccident(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }
        public override string name { get; set; } = "E";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }


        public string flat { get { return $"{name}b"; } }
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