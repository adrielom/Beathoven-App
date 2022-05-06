
namespace Beathoven.Core.Notes
{
    using Beathoven.Core.Note;
    using Unity;
    public interface IMusicNote
    {
        string name { get; set; }
        uint notePitch { get; set; }
        bool isAccident { get; }
        INoteAccident noteAccident { get; set; }

    }
}