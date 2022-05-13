using Beathoven.Core.Notes;

namespace Beathoven.Core.GuessNote
{
    public interface IGuesser
    {
        bool MatchNotes(IMusicNote noteA);
    }
}