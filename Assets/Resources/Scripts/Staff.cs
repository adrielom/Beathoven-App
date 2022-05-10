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
        const float DISTANCE_BETWEEN_LINES = 0.3f;
        const ushort START_OF_PENTAGRAM = 6;
        const ushort END_OF_PENTAGRAM = 16;
        List<IMusicNote> musicNotes = new List<IMusicNote>();
        NotesSequence notesSequence = new NotesSequence();
        CleffFactory factory = new CleffFactory();

        [SerializeField]
        CleffsEnumeration staffCleff;

        public float GetDistanceBetweenLines()
        {
            return DISTANCE_BETWEEN_LINES;
        }

        void Start()
        {
            ICleff cleff = factory.Create(staffCleff);
            SetMusicNotesOnStaff(cleff);
            MusicNoteFacade facade = new MusicNoteFacade(new QuarterNoteTime());
            facade.InstantiateNote(new Vector3(GetDistanceBetweenLines() * musicNotes[0].notePitch, 0, 0));

        }

        public void SetMusicNotesOnStaff(ICleff cleff)
        {
            musicNotes = notesSequence.TraverseAndGetNotesStartingFromIndex(cleff.initialNote, NOTES_ON_STAFF);
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