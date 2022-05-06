namespace Beathoven.Collection.Notes
{
    public class C_Note : IMusicNote
    {
        public C_Note()
        {
        }

        public C_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "C";
        public uint notePitch { get; set; }
    }
}