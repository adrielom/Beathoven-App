
namespace Beathoven.Core.Notes
{
    using Beathoven.Core.Note;
    using Beathoven.Core.Time;
    using Unity;
    public interface IMusicNote
    {
        string name { get; set; }
        uint notePitch { get; set; }
        bool isAccident { get; }
        INoteAccident noteAccident { get; set; }
        INoteTime noteTime { get; set; }
    }
}