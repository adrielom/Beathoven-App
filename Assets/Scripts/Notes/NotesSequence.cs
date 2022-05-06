using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Beathoven.Collection.Notes
{
    class NotesSequence
    {
        NotesEnumeration notesEnumeration;
        NotesFactory notesFactory = new NotesFactory();

        public List<IMusicNote> TraverseAndGetNotesStartingFromIndex(string startingNote, int amountOfNotes)
        {
            List<string> notesSequence = Enum.GetNames(typeof(NotesEnumeration)).ToList();
            if (amountOfNotes < notesSequence.Count)
                throw new Exception("The amount requested is less than the natural notes");

            List<IMusicNote> notes = new List<IMusicNote>();

            int indexOfTargetNote = notesSequence.IndexOf(startingNote);
            int arrayIndexer = indexOfTargetNote;

            for (int i = indexOfTargetNote; i < amountOfNotes + indexOfTargetNote; i++)
            {
                if (arrayIndexer >= notesSequence.Count)
                {
                    arrayIndexer = 0;
                }

                notes.Add(notesFactory.Create((NotesEnumeration)arrayIndexer));
                arrayIndexer++;
            }

            return notes;

        }


    }
}