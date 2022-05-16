
namespace Beathoven.Core.GuessNote
{
    using System;
    using System.Collections.Generic;
    using Beathoven.Core.FeedbackSystem;
    using Beathoven.Core.GameType;
    using Beathoven.Core.Notes;
    using Beathoven.Core.ScoreSystem;
    using Beathoven.Core.Staff;
    using Beathoven.Utils;
    using UnityEngine;

    class NoteGuesser : IGuesser, IGameType
    {
        private readonly List<MusicNote> _musicNotes;
        private Animator _animator;
        private NoteRandomizer _randomizer;
        public static MusicNote RoundSelectedNote { get; set; }
        public IStaff Staff { get; set; }
        public uint notePoolCount { get; set; } = 1;
        private INoteFeedback _noteFeedback;
        public static Action OnInitialize;

        public NoteGuesser(IStaff staff, Animator animator)
        {
            this.Staff = staff;
            this._musicNotes = staff.GetMusicNotes();
            this._animator = animator;
            OnInitialize += Initialize;
        }

        public void Initialize()
        {
            this._animator.Play("InitialState");
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

        public void OnGameEnd()
        {
            if (PlayerPrefs.GetInt(Configs.DEFAULT_PLAYER_PREFS_KEY_TOP_SCORE, 0) < ScoreState.Score)
                PlayerPrefs.SetInt(Configs.DEFAULT_PLAYER_PREFS_KEY_TOP_SCORE, (int)ScoreState.Score);
            _animator.Play(Configs.DEFAULT_ANIMATION_KEY_END_GAME);
        }
    }
}