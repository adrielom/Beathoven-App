using System.Collections.Generic;
using Beathoven.Core.Clef;
using Beathoven.Core.Notes;

namespace Beathoven.Core.Staff
{
    public interface IStaff
    {
        void SetMusicNotesOnStaff(IClef cleff);
        List<IMusicNote> GetPentagramNotesList();
        List<IMusicNote> GetLowerNotesList();
        List<IMusicNote> GetHigherNotesList();
    }

}