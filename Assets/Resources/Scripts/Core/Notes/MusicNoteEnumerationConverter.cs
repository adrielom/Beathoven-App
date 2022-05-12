using System;

namespace Beathoven.Core.Notes
{
    class MusicNoteEnumerationParser
    {
        private const string notesNamespacePath = "Beathoven.Core.Notes.";

        public string GetClassName(ChromaticNotesEnumeration enumeration)
        {
            return Enum.GetName(typeof(ChromaticNotesEnumeration), enumeration);
        }

        public IMusicNote NoteEnumerationToMusicNote(ChromaticNotesEnumeration enumeration)
        {
            string className = GetClassName(enumeration);
            return (IMusicNote)Activator.CreateInstance(Type.GetType(notesNamespacePath + className));
        }
    }
}