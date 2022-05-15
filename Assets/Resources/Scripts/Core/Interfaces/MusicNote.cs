
namespace Beathoven.Core.Notes
{
    using Beathoven.Core.FeedbackSystem;
    using Beathoven.Core.Time;
    public abstract class MusicNote
    {
        public abstract string name { get; set; }
        public abstract uint notePitch { get; set; }
        public abstract INoteTime noteTime { get; set; }

        public override bool Equals(object obj)
        {
            return ((MusicNote)obj).name == this.name;
        }

        public override string ToString()
        {
            return $"{notePitch}{name}";
        }

    }
}