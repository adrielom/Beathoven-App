namespace Beathoven.Collection.Staff
{
    using Beathoven.Collection.Notes;
    using UnityEngine;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Staff : MonoBehaviour, IStaff
    {
        Dictionary<uint, IMusicNote> notesOnStaff = new Dictionary<uint, IMusicNote>();
        public void RenderStaff(IMusicNote note)
        {
            throw new System.NotImplementedException();
        }

        public void SetMusicNotesOnStaff(ICleff cleff)
        {
            uint count = 0;
            List<string> notesSequence = Enum.GetNames(typeof(NotesSequence)).ToList();
            uint noteIndex = (uint) notesSequence.IndexOf(cleff.initialNote);
        }
    }
}