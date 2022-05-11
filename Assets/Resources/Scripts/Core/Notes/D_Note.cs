using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class D_Note : IMusicNote
    {
        public D_Note()
        {
        }

        public override string ToString()
        {
            return $"Note: {notePitch}{name}\n";
        }

        public string name { get; set; } = "D";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }

    }
}