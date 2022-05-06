using Beathoven.Collection.Cleff;
using Beathoven.Collection.Notes;

namespace Beathoven.Collection.Staff
{
    public interface IStaff
    {
        void RenderStaff(IMusicNote note);
        void SetMusicNotesOnStaff(ICleff cleff);
    }

}