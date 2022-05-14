using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class B_Note : MusicNote
    {
        public B_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public B_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public override string name { get; set; } = "B";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }










    }
}