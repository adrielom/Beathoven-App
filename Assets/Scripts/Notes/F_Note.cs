namespace Beathoven.Collection.Notes
{
    public class F_Note : IMusicNote
    {
        public F_Note()
        {
        }

        public F_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "F";
        public uint notePitch { get; set; }
    }
}