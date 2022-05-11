using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
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
        public override string ToString()
        {
            return $"Note: {notePitch}{name}\n";
        }

        public string name { get; set; } = "G";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }

    }
}