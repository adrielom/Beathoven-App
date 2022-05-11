namespace Beathoven.Core.Staff
{
    using Beathoven.Core.Notes;
    using UnityEngine;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Beathoven.Core.Cleff;
    using Beathoven.Utils;
    using Beathoven.Core.Time;

    public class Staff : MonoBehaviour, IStaff
    {

        const ushort NOTES_ON_STAFF = 26;
        const float DISTANCE_BETWEEN_NOTES = 0.17f;
        const ushort START_OF_PENTAGRAM = 6;
        const uint STARTING_PITCH = 1;
        const ushort END_OF_PENTAGRAM = 16;
        [SerializeField]
        GameObject firstLine, notesPoolGameObject;
        List<IMusicNote> musicNotes = new List<IMusicNote>();
        NotesSequence notesSequence = new NotesSequence();
        CleffFactory factory = new CleffFactory();

        [SerializeField]
        CleffsEnumeration staffCleff;

        void Start()
        {
            ICleff cleff = factory.Create(staffCleff);
            SetMusicNotesOnStaff(cleff);
            MusicNoteFacade facade = new MusicNoteFacade(new QuarterNoteTime(), notesPoolGameObject.transform);
            IMusicNote note = musicNotes[10];
            Debug.Log(GetMusicNoteOnStaffHeight(musicNotes.IndexOf(note)) + $" {note}");
            facade.InstantiateNote(new Vector3(0, GetMusicNoteOnStaffHeight(musicNotes.IndexOf(note)), 0));

        }

        public void SetMusicNotesOnStaff(ICleff cleff)
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

        private float GetMusicNoteOnStaffHeight(int index)
        {
            return ((DISTANCE_BETWEEN_NOTES * index) + firstLine.transform.position.y);

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