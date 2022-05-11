namespace Beathoven.Core.Staff
{
    using Beathoven.Core.Notes;
    using UnityEngine;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Beathoven.Core.Clef;
    using Beathoven.Utils;
    using Beathoven.Core.Time;
    using Beathoven.Core.GuessNote;

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
        NoteRandomizer randomizer;

        [SerializeField]
        ClefsEnumeration staffCleff;

        void Start()
        {
            IClef clef = factory.Create(staffCleff);
            SetMusicNotesOnStaff(clef);
            MusicNoteFacade facade = new MusicNoteFacade(new QuarterNoteTime(), notesPoolGameObject.transform);
            randomizer = new NoteRandomizer(musicNotes);
            IMusicNote note = randomizer.GetRandomNote();
            IMusicNote anote = new A_Note();

            print(anote.Equals(note));


            print(note.ToString());
            facade.InstantiateNote(new Vector3(0, GetMusicNoteOnStaffHeight(musicNotes.IndexOf(note)), 0));




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
            //0
            // 0.15 * 0 + 4,05 - 0.15 = 3.9
            //1
            // 0.15 * 1 + 4.05 - 0.15 = 4.05
            //2
            // 0.15 * 2 + 4.05 - 0.15 = 4.2
            //3
            // 0.15 * 3 + 4.05 - 0.15 = 4.35
            float initialNotePosition = firstLine.transform.position.y - DISTANCE_BETWEEN_NOTES;
            float noteDistanceFromInitialPosition = (DISTANCE_BETWEEN_NOTES * noteIndexPosition);
            return (noteDistanceFromInitialPosition + initialNotePosition);

        }

        public List<IMusicNote> GetPentagramNotesList()
        {
            return musicNotes.GetRange(START_OF_PENTAGRAM, 10);
        }

        public List<IMusicNote> GetLowerNotesList()
        {
            throw new NotImplementedException();
        }

        public List<IMusicNote> GetHigherNotesList()
        {
            throw new NotImplementedException();
        }
    }
}