namespace Beathoven.Collection.Notes
{
    public class D_Note : IMusicNote
    {
        public D_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "D";
        public uint notePitch { get; set; }
    }
}