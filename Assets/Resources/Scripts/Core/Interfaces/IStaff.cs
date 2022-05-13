using System.Collections.Generic;
using Beathoven.Core.Clef;
using Beathoven.Core.Notes;
using Beathoven.Core.Time;

namespace Beathoven.Core.Staff
{
    public interface IStaff
    {
        void SetMusicNotesOnStaff(IClef cleff);
        void SetNoteOnStaff(IMusicNote note, INoteTime time);
        List<IMusicNote> GetMusicNotes();
    }

}