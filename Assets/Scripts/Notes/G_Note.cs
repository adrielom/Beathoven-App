namespace Beathoven.Collection.Notes
{
    public class G_Note : IMusicNote
    {
        public G_Note()
        {
        }

        public G_Note(string name, uint notePitch)
        {
            this.name = name;
            this.notePitch = notePitch;
        }

        public string name { get; set; } = "G";
        public uint notePitch { get; set; }
    }
}