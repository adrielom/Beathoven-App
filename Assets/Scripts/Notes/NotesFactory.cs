namespace Beathoven.Collection.Notes
{
    using Beathoven.Utils;

    class NotesFactory : AbstractFactory<IMusicNote, NotesEnumeration>
    {
        public override IMusicNote Create(NotesEnumeration notesEnumeration)
        {
            switch (notesEnumeration)
            {
                case NotesEnumeration.A:
                    return new A_Note();
                case NotesEnumeration.B:
                    return new B_Note();
                case NotesEnumeration.C:
                    return new C_Note();
                case NotesEnumeration.D:
                    return new D_Note();
                case NotesEnumeration.E:
                    return new E_Note();
                case NotesEnumeration.F:
                    return new F_Note();
                case NotesEnumeration.G:
                    return new G_Note();
                default:
                    return new A_Note();
            }

        }
    }
}