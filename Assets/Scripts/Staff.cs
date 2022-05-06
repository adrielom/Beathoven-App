namespace Beathoven.Collection.Staff
{
    using Beathoven.Collection.Notes;
    using UnityEngine;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Beathoven.Collection.Cleff;
    using Beathoven.Utils;

    public class Staff : MonoBehaviour, IStaff
    {

        const UInt16 NOTES_ON_STAFF = 26;
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


    }
}