namespace Beathoven.Core.Notes
{
    using Beathoven.Utils;

    class NotesFactory : AbstractFactory<IMusicNote, NaturalNotesEnumeration>
    {
        public override IMusicNote Create(NaturalNotesEnumeration notesEnumeration)
        {
            switch (notesEnumeration)
            {
                case NaturalNotesEnumeration.A:
                    return new A_Note();
                case NaturalNotesEnumeration.B:
                    return new B_Note();
                case NaturalNotesEnumeration.C:
                    return new C_Note();
                case NaturalNotesEnumeration.D:
                    return new D_Note();
                case NaturalNotesEnumeration.E:
                    return new E_Note();
                case NaturalNotesEnumeration.F:
                    return new F_Note();
                case NaturalNotesEnumeration.G:
                    return new G_Note();
                default:
                    return new A_Note();
            }

        }
    }
}