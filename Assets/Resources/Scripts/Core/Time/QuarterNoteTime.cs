namespace Beathoven.Core.Time
{
    class QuarterNoteTime : INoteTime
    {
        public TimeEnumeration timeEnumeration { get; set; } = TimeEnumeration.Quarter;
        public string imagePath { get; } = "quarterNote.svg";
    }
}