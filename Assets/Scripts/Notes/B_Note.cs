namespace Beathoven.Collection.Notes
{
    public class B_Note : IMusicNote
    {
        public B_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "B";
        public uint notePitch { get; set; }
    }
}