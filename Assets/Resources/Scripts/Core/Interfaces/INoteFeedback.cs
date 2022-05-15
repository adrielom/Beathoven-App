
namespace Beathoven.Core.FeedbackSystem
{
    using UnityEngine;
    public interface INoteFeedback
    {
        GameObject musicNoteGameObject { get; set; }
        void RightNoteSelectedFeedback();
        void WrongNoteSelectedFeedback();
    }
}