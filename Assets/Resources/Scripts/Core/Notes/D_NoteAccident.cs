using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class D_NoteAccident : IMusicNote, INoteAccident
    {
        public string name { get; set; } = "D";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }
        public string flat { get { return $"{name}b"; } }
        public string sharp { get { return $"{name}#"; } }
    }
}