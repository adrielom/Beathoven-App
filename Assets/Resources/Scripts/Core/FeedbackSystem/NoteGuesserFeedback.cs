namespace Beathoven.Core.FeedbackSystem
{
    using UnityEngine;
    using DG.Tweening;
    using Beathoven.Core.GuessNote;
    using Beathoven.Utils;
    using System;

    public class NoteGuesserFeedback : INoteFeedback
    {
        private float DEFAULT_TIMING = Configs.DEFAULT_NOTE_FEEDBACK_TIMING;

        public GameObject musicNoteGameObject { get; set; }


        public NoteGuesserFeedback()
        {
            UIButtonNoteGuesser.onRightNoteSelected += RightNoteSelectedFeedback;
            UIButtonNoteGuesser.onWrongNoteSelected += WrongNoteSelectedFeedback;
        }

        public void RightNoteSelectedFeedback()
        {
            if (musicNoteGameObject)
            {
                SetRightScaleFeedback();
                SetRightColorFeedback();
            }
        }

        public void WrongNoteSelectedFeedback()
        {
            if (musicNoteGameObject)
            {
                SetWrongColorFeedback();
                SetWrongScaleFeedback();
            }
        }

        private void SetRightColorFeedback()
        {
            SetSpriteColor(Color.green);
        }

        private void SetWrongColorFeedback()
        {
            SetSpriteColor(Color.red);
        }

        private void SetRightScaleFeedback()
        {
            SetGameObjectScale(0.4f, DEFAULT_TIMING / 2);
        }

        private void SetWrongScaleFeedback()
        {
            musicNoteGameObject.transform.DOShakeScale(DEFAULT_TIMING / 2, strength: 0.2f);
        }

        private void SetGameObjectScale(float scalerFactor, float timing)
        {
            Vector3 initialScale = musicNoteGameObject.transform.localScale;
            musicNoteGameObject?.transform.DOScale(initialScale / scalerFactor, timing);
            musicNoteGameObject?.transform.DOScale(initialScale, timing);
        }

        private void SetSpriteColor(Color color)
        {
            SpriteRenderer spriteRenderer = musicNoteGameObject.GetComponentInChildren<SpriteRenderer>();
            Color initialColor = spriteRenderer.color;
            spriteRenderer.color = color;
            spriteRenderer.DOColor(initialColor, DEFAULT_TIMING);
        }
    }
}