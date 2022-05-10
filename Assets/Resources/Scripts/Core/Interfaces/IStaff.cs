using System.Collections.Generic;
using Beathoven.Core.Cleff;
using Beathoven.Core.Notes;

namespace Beathoven.Core.Staff
{
    public interface IStaff
    {
        void SetMusicNotesOnStaff(ICleff cleff);
        List<IMusicNote> GetPentagramNotesList();
        List<IMusicNote> GetLowerNotesList();
        List<IMusicNote> GetHigherNotesList();
    }

}