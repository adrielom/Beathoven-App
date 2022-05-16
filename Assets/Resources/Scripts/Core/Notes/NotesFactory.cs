namespace Beathoven.Core.Notes
{
    using Beathoven.Utils;

    class NotesFactory : AbstractFactory<MusicNote, ChromaticNotesEnumeration>
    {
        public override MusicNote Create(ChromaticNotesEnumeration notesEnumeration)
        {
            switch (notesEnumeration)
            {
                case ChromaticNotesEnumeration.A_Note:
                    return new A_Note();
                case ChromaticNotesEnumeration.A_NoteAccident:
                    return new A_NoteAccident();
                case ChromaticNotesEnumeration.B_Note:
                    return new B_Note();
                case ChromaticNotesEnumeration.C_Note:
                    return new C_Note();
                case ChromaticNotesEnumeration.C_NoteAccident:
                    return new C_NoteAccident();
                case ChromaticNotesEnumeration.D_Note:
                    return new D_Note();
                case ChromaticNotesEnumeration.D_NoteAccident:
                    return new D_NoteAccident();
                case ChromaticNotesEnumeration.E_Note:
                    return new E_Note();
                case ChromaticNotesEnumeration.F_Note:
                    return new F_Note();
                case ChromaticNotesEnumeration.F_NoteAccident:
                    return new F_NoteAccident();
                case ChromaticNotesEnumeration.G_Note:
                    return new G_Note();
                case ChromaticNotesEnumeration.G_NoteAccident:
                    return new G_NoteAccident();
                default:
                    return new A_Note();
            }

        }
    }
}