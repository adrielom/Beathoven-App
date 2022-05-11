using System.Collections.Generic;
using Beathoven.Core.Notes;
using UnityEngine;

namespace Beathoven.Core.GuessNote
{
    class NoteRandomizer
    {
        private readonly List<IMusicNote> _notes;

        public NoteRandomizer(List<IMusicNote> notes)
        {
            this._notes = notes;
        }

        public IMusicNote GetRandomNote()
        {
            return _notes[Random.Range(0, _notes.Count - 1)];
        }
    }
}