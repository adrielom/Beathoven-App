using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class A_Note : MusicNote
    {
        public A_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public A_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public override string name { get; set; } = "A";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }

    }
}