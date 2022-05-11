namespace Beathoven.Core.Notes
{
    using Beathoven.Core.Note;
    using Beathoven.Core.Time;

    public class A_NoteAccident : IMusicNote, INoteAccident
    {
        public string name { get; set; } = "A";
        public uint notePitch { get; set; }
        public INoteTime noteTime { get; set; }
        public string flat { get { return $"{name}b"; } }
        public string sharp { get { return $"{name}#"; } }

        public override string ToString()
        {
            return $"Note: {notePitch}{name}\n";
        }
    }
}