namespace Beathoven.Core.Staff
{
    using Beathoven.Core.Notes;
    using UnityEngine;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Beathoven.Core.Cleff;
    using Beathoven.Utils;

    public class Staff : MonoBehaviour, IStaff
    {

        const UInt16 NOTES_ON_STAFF = 26;
        const UInt16 START_OF_PENTAGRAM = 6;
        const UInt16 END_OF_PENTAGRAM = 16;
        List<IMusicNote> musicNotes = new List<IMusicNote>();
        NotesSequence notesSequence = new NotesSequence();
        CleffFactory factory = new CleffFactory();

        [SerializeField]
        CleffsEnumeration staffCleff;

        void Start()
        {
            ICleff cleff = factory.Create(staffCleff);
            SetMusicNotesOnStaff(cleff);
        }

        public void RenderStaff(IMusicNote note)
        {
            throw new System.NotImplementedException();
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