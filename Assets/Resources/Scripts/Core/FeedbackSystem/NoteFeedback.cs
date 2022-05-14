namespace Beathoven.Core.FeedbackSystem
{
    using UnityEngine;
    using DG.Tweening;

    public class NoteFeedback : INoteFeedback
    {
        private GameObject _musicNote;

        public NoteFeedback(GameObject note)
        {
            this._musicNote = note;
        }

        public void RightNoteSelectedFeedback()
        {
            _musicNote.transform.DOScale(1.2f, 0.5f);
        }

        public void WrongNoteSelectedFeedback()
        {
            throw new System.NotImplementedException();
        }
    }
}