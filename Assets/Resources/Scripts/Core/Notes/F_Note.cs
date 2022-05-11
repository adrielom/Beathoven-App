using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class F_Note : IMusicNote
    {
        public F_Note()
        {
        }

        public override string ToString()
        {
            return $"Note: {notePitch}{name}\n";
        }

        public string name { get; set; } = "F";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }

    }
}