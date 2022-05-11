using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class B_Note : IMusicNote
    {
        public B_Note()
        {
        }

        public override string ToString()
        {
            return $"Note: {notePitch}{name}\n";
        }

        public string name { get; set; } = "B";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }

    }
}