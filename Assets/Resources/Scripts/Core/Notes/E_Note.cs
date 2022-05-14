using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class E_Note : MusicNote
    {
        public E_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public E_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }
        public override string name { get; set; } = "E";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }










    }
}