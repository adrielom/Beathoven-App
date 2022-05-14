using System.Collections.Generic;
using Beathoven.Core.Notes;
using UnityEngine;

namespace Beathoven.Core.GuessNote
{
    class NoteRandomizer
    {
        private readonly List<MusicNote> _notes;

        public NoteRandomizer(List<MusicNote> notes)
        {
            this._notes = notes;
        }

        public MusicNote GetRandomNote()
        {
            return _notes[Random.Range(0, _notes.Count - 1)];
        }
    }
}