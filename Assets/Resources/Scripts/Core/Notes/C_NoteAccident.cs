using Beathoven.Core.Note;
using Beathoven.Core.Time;

namespace Beathoven.Core.Notes
{
    public class C_NoteAccident : IMusicNote, INoteAccident
    {
        public string name { get; set; } = "C";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }
        public string flat { get { return $"{name}b"; } }
        public string sharp { get { return $"{name}#"; } }
    }
}