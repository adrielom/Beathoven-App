using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class G_Note : MusicNote
    {
        public G_Note()
        {
            notePitch = 2;
            noteTime = new QuarterNoteTime();
        }

        public G_Note(uint notePitch, INoteTime noteTime)
        {
            this.notePitch = notePitch;
            this.noteTime = noteTime;
        }
        public override string name { get; set; } = "G";
        public override uint notePitch { get; set; }

        public override INoteTime noteTime { get; set; }









    }
}