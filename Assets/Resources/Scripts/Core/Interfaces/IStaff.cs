using System.Collections.Generic;
using Beathoven.Core.Clef;
using Beathoven.Core.GameType;
using Beathoven.Core.Notes;
using Beathoven.Core.Time;

namespace Beathoven.Core.Staff
{
    public interface IStaff
    {
        IGameType gameType { get; set; }
        void SetMusicNotesOnStaff(IClef cleff);
        void SetNoteOnStaff(MusicNote note);
        List<MusicNote> GetMusicNotes();
    }

}