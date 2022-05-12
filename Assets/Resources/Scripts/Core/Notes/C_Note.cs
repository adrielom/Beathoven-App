using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class C_Note : IMusicNote
    {
        public C_Note()
        {
        }

        public string name { get; set; } = "C";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }
        public override bool Equals(object obj)
        {
            return ((IMusicNote)obj).name == this.name;
        }

        public override string ToString()
        {
            return $"{notePitch}{name}";
        }
    }
}