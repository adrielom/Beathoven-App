namespace Beathoven.Core.Staff
{
    using UnityEngine;
    using Beathoven.Core.Notes;
    using System.Collections.Generic;
    using Beathoven.Core.Clef;
    using Beathoven.Core.Time;
    using Beathoven.Core.GuessNote;
    using Beathoven.Core.GameType;

    public class Staff : MonoBehaviour, IStaff
    {

        const ushort NOTES_ON_STAFF = 23;
        const float DISTANCE_BETWEEN_NOTES = 0.225f;
        const ushort START_OF_PENTAGRAM = 6;
        const uint STARTING_PITCH = 1;
        const ushort END_OF_PENTAGRAM = 16;
        [SerializeField]
        GameObject firstLine, notesPoolGameObject;
        [SerializeField]
        SpriteRenderer cleffImage;
        List<IMusicNote> musicNotes = new List<IMusicNote>();
        NotesSequence notesSequence = new NotesSequence();
        ClefFactory factory = new ClefFactory();

        IGameType gameType;
        [SerializeField]
        ClefsEnumeration staffCleff;

        void Awake()
        {
            IClef clef = factory.Create(staffCleff);
            SetMusicNotesOnStaff(clef);
            gameType = new NoteGuesser(this);
        }

        public void SetNoteOnStaff(IMusicNote note, INoteTime time)
        {
            MusicNoteFacade facade = new MusicNoteFacade(time, notesPoolGameObject.transform, gameType);

            facade.InstantiateNote(new Vector3(0, GetMusicNoteOnStaffHeight(musicNotes.IndexOf(note)), 0));
        }


        public List<IMusicNote> GetMusicNotes()
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
            float initialNotePosition = firstLine.transform.position.y - DISTANCE_BETWEEN_NOTES;
            float noteDistanceFromInitialPosition = (DISTANCE_BETWEEN_NOTES * noteIndexPosition);
            return (noteDistanceFromInitialPosition + initialNotePosition);

        }

    }
}