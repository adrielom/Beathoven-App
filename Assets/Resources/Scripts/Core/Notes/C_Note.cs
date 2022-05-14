using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class C_Note : MusicNote
    {
        public C_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public C_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }

        public override string name { get; set; } = "C";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }









    }
}