
namespace Beathoven.Core.GuessNote
{
    using System.Collections.Generic;
    using Beathoven.Core.GameType;
    using Beathoven.Core.Notes;
    using Beathoven.Core.Staff;
    using Beathoven.Core.Time;
    using UnityEngine;

    class NoteGuesser : IGuesser, IGameType
    {
        private readonly List<IMusicNote> _musicNotes;
        private NoteRandomizer _randomizer;
        public static IMusicNote RoundSelectedNote { get; set; }
        public IStaff Staff { get; set; }
        public uint notePoolCount { get; set; } = 1;

        public NoteGuesser(IStaff staff)
        {
            this.Staff = staff;
            this._musicNotes = staff.GetMusicNotes();
            Initialize();
        }

        public void Initialize()
        {
            RoundSelectedNote = GuessNote();
            UIButtonNoteGuesser.onMatchingNotes += MatchNotes;
            UIButtonNoteGuesser.onRightNoteSelected += RightNoteSelected;
            Staff.SetNoteOnStaff(RoundSelectedNote, new QuarterNoteTime());
        }

        ~NoteGuesser()
        {
            UIButtonNoteGuesser.onMatchingNotes -= MatchNotes;
            UIButtonNoteGuesser.onRightNoteSelected -= RightNoteSelected;
        }

        void RightNoteSelected()
        {
            RoundSelectedNote = GuessNote();
            Staff.SetNoteOnStaff(RoundSelectedNote, new QuarterNoteTime());
        }

        public IMusicNote GuessNote()
        {
            _randomizer = new NoteRandomizer(_musicNotes);
            IMusicNote note = _randomizer.GetRandomNote();
            Debug.Log($"Selected note is {note.name}");
            return note;
        }

        public bool MatchNotes(IMusicNote noteA)
        {
            return RoundSelectedNote.Equals(noteA);
        }

    }
}