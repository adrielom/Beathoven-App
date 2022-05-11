using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class A_Note : IMusicNote
    {
        public A_Note()
        {

        }

        public string name { get; set; } = "A";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }
    }
}