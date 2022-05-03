namespace Beathoven.Collection.Notes
{
    public class A_Note : IMusicNote
    {
        public A_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "A";
        public uint notePitch { get; set; }

    }
}