using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class C_Note : IMusicNote
    {
        public C_Note()
        {
        }

        public override string ToString()
        {
            return $"Note: {notePitch}{name}\n";
        }

        public string name { get; set; } = "C";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }

    }
}