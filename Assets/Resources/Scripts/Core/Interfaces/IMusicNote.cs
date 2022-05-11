
namespace Beathoven.Core.Notes
{
    using Beathoven.Core.Note;
    using Beathoven.Core.Time;
    public interface IMusicNote
    {
        string name { get; set; }
        uint notePitch { get; set; }
        INoteTime noteTime { get; set; }

    }
}