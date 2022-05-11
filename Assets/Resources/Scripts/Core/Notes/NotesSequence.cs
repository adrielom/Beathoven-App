using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Beathoven.Core.Notes
{
    class NotesSequence
    {
        NaturalNotesEnumeration notesEnumeration;
        NotesFactory notesFactory = new NotesFactory();

        public void TraverseSequence(string startingNote, int amountOfNotes, Action<int> iterationCallback)
        {
            List<string> notesSequence = Enum.GetNames(typeof(NaturalNotesEnumeration)).ToList();
            int indexOfTargetNote = notesSequence.IndexOf(startingNote);
            int arrayIndexer = indexOfTargetNote;

            for (var i = indexOfTargetNote; i < amountOfNotes + indexOfTargetNote; i++)
            {
                if (arrayIndexer >= notesSequence.Count) arrayIndexer = 0;

                iterationCallback(arrayIndexer);
                arrayIndexer++;
            }

        }

        public List<IMusicNote> TraverseAndGetNotesStartingFromIndex(string startingNote, int amountOfNotes)
        {
            List<IMusicNote> notes = new List<IMusicNote>();

            TraverseSequence(startingNote, amountOfNotes, (arrayIndexer) =>
            {
                notes.Add(notesFactory.Create((NaturalNotesEnumeration)arrayIndexer));
            });
            return notes;

        }


    }
}