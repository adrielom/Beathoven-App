
namespace Beathoven.Core.GuessNote
{
    using System.Collections.Generic;
    using Beathoven.Core.FeedbackSystem;
    using Beathoven.Core.GameType;
    using Beathoven.Core.Notes;
    using Beathoven.Core.Staff;
    using UnityEngine;

    class NoteGuesser : IGuesser, IGameType
    {
        private readonly List<MusicNote> _musicNotes;
        private NoteRandomizer _randomizer;
        public static MusicNote RoundSelectedNote { get; set; }
        public IStaff Staff { get; set; }
        public uint notePoolCount { get; set; } = 1;
        private INoteFeedback _noteFeedback;

        public NoteGuesser(IStaff staff)
        {
            this.Staff = staff;
            this._musicNotes = staff.GetMusicNotes();
        }

        public void Initialize()
        {
            RoundSelectedNote = GuessNote();
            UIButtonNoteGuesser.onMatchingNotes += MatchNotes;
            UIButtonNoteGuesser.onRightNoteSelected += RightNoteSelected;
            Staff.SetNoteOnStaff(RoundSelectedNote);
        }

        ~NoteGuesser()
        {
            UIButtonNoteGuesser.onMatchingNotes -= MatchNotes;
            UIButtonNoteGuesser.onRightNoteSelected -= RightNoteSelected;
        }

        void RightNoteSelected()
        {
            RoundSelectedNote = GuessNote();
            Staff.SetNoteOnStaff(RoundSelectedNote);
        }

        public MusicNote GuessNote()
        {
            _randomizer = new NoteRandomizer(_musicNotes);
            MusicNote note = _randomizer.GetRandomNote();
            Debug.Log($"Selected note is {note.ToString()}");
            return note;
        }

        public bool MatchNotes(MusicNote noteA)
        {
            return RoundSelectedNote.Equals(noteA);
        }

    }
}