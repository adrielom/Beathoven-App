using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class F_Note : MusicNote
    {
        public F_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public F_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public override string name { get; set; } = "F";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }









    }
}