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

    public class Staff : MonoBehaviour, IStaff
    {

        const ushort NOTES_ON_STAFF = 23;
        const float DISTANCE_BETWEEN_NOTES = 0.225f;
        const ushort START_OF_PENTAGRAM = 6;
        const uint STARTING_PITCH = 1;
        const ushort END_OF_PENTAGRAM = 16;
        public IGameType gameType { get; set; }
        [SerializeField]
        GameObject firstLine, notesPoolGameObject;
        [SerializeField]
        SpriteRenderer cleffImage;
        List<MusicNote> musicNotes = new List<MusicNote>();
        NotesSequence notesSequence = new NotesSequence();
        ClefFactory factory = new ClefFactory();
        [SerializeField]
        ScoreState scoreState;

        [SerializeField]
        ClefsEnumeration staffCleff;

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
            facade.InstantiateNote(new Vector3(0, GetMusicNoteOnStaffHeight(musicNotes.FindIndex(predicate)), 0));
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