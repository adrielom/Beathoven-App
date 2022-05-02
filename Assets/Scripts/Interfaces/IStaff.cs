namespace Beathoven.Collection
{
    public interface IStaff
    {
        public void RenderStaff(IMusicNote note);
        void SetMusicNotesOnStaff(ICleff cleff);
    }

}