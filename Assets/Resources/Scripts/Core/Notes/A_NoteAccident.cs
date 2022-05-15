namespace Beathoven.Core.Notes
{
    using Beathoven.Core.Note;
    using Beathoven.Core.Time;

    public class A_NoteAccident : MusicNote, INoteAccident
    {
        public A_NoteAccident()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }
        public A_NoteAccident(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public override string name { get; set; } = "A";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }


        public string flat { get { return $"Bb"; } }
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