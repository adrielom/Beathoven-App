using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class D_Note : MusicNote
    {
        public D_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public D_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public override string name { get; set; } = "D";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }









    }
}