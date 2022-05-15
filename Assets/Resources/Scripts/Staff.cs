namespace Beathoven.Core.Staff
{
    using UnityEngine;
    using Beathoven.Core.Notes;
    using System.Collections.Generic;
    using Beathoven.Core.Clef;
    using Beathoven.Core.Time;
    using Beathoven.Core.GuessNote;
    using Beathoven.Core.GameType;
    using System;
    using Beathoven.Core.ScoreSystem;
    using Beathoven.Core.FeedbackSystem;
    using Beathoven.Utils;

    public class Staff : MonoBehaviour, IStaff
    {

        public IGameType gameType { get; set; }
        private const ushort NOTES_ON_STAFF = 23;
        private const float DISTANCE_BETWEEN_NOTES = 0.225f;
        private const ushort START_OF_PENTAGRAM = 6;
        private const uint STARTING_PITCH = 1;
        private const ushort END_OF_PENTAGRAM = 16;
        [SerializeField] private GameObject firstLine, notesPoolGameObject;
        [SerializeField] private SpriteRenderer cleffImage;
        [SerializeField] private ScoreState scoreState;
        [SerializeField] private ClefsEnumeration staffCleff;
        private List<MusicNote> musicNotes = new List<MusicNote>();
        private NotesSequence notesSequence = new NotesSequence();
        private ClefFactory factory = new ClefFactory();
        private INoteFeedback noteFeedback = new NoteGuesserFeedback();

        void Awake()
        {
            IClef clef = factory.Create(staffCleff);
            clef.RenderCleff(cleffImage);
            SetMusicNotesOnStaff(clef);
            gameType = new NoteGuesser(this);
            gameType.Initialize();
        }

        public void SetNoteOnStaff(MusicNote note)
        {
            MusicNoteFacade facade = new MusicNoteFacade(note, notesPoolGameObject.transform, this);
            Predicate<MusicNote> predicate = (el) => el.name == note.name && el.notePitch == note.notePitch;
            // StartCoroutine(Delayer.WaitFor(Configs.DEFAULT_NOTE_FEEDBACK_TIMING * 2));
            GameObject freshNote = facade.InstantiateNote(new Vector3(0, GetMusicNoteOnStaffHeight(musicNotes.FindIndex(predicate)), 0));
            noteFeedback.musicNoteGameObject = freshNote;
        }


        public List<MusicNote> GetMusicNotes()
        {
            return musicNotes;
        }

        public void SetMusicNotesOnStaff(IClef cleff)
        {
            musicNotes = notesSequence.TraverseAndGetNotesStartingFromIndex(cleff.initialNote, NOTES_ON_STAFF);
            SetMusicNotesPitchesAccordingToCleff();
        }

        private void SetMusicNotesPitchesAccordingToCleff()
        {
            int counter = (int)STARTING_PITCH;

            for (var i = 0; i < musicNotes.Count; i++)
            {
                bool hasLoopedAgain = i % 7 == 0;
                if (hasLoopedAgain) counter++;
                musicNotes[i].notePitch = (uint)counter;
            }
        }

        private float GetMusicNoteOnStaffHeight(int noteIndexPosition)
        {
            Debug.Log($"Selected index {noteIndexPosition}");
            float initialNotePosition = firstLine.transform.position.y - DISTANCE_BETWEEN_NOTES;
            float noteDistanceFromInitialPosition = (DISTANCE_BETWEEN_NOTES * noteIndexPosition);
            return (noteDistanceFromInitialPosition + initialNotePosition);

        }

    }
}