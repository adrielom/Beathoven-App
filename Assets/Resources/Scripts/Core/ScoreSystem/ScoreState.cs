namespace Beathoven.Core.ScoreSystem
{
    using Beathoven.Core.GuessNote;
    using UnityEngine;
    using TMPro;
    using Beathoven.Utils;

    class ScoreState : MonoBehaviour
    {
        [SerializeField]
        TMP_Text scoreText;
        [SerializeField]
        TMP_Text multiplierText;
        [SerializeField]
        uint score;
        [SerializeField]
        uint multiplier;
        [SerializeField]
        uint attempts;

        void Awake()
        {
            attempts = Configs.DEFAULT_GUESSING_ATTEMPTS;
            UIButtonNoteGuesser.onRightNoteSelected += IncreaseScore;
            UIButtonNoteGuesser.onWrongNoteSelected += ResetMultiplier;
            UIButtonNoteGuesser.onWrongNoteSelected += DecreaseAttempts;
        }

        void Update()
        {
            scoreText.text = score.ToString();
            multiplierText.text = multiplier > 1 ? $"x{multiplier}" : "";
        }

        void IncreaseScore()
        {
            if (score % 10 == 0 && multiplier <= 5) multiplier++;
            uint amount = multiplier == 0 ? 1 : 1 * multiplier;
            score += amount;
        }

        void ResetMultiplier()
        {
            multiplier = 0;
        }

        void DecreaseAttempts()
        {
            attempts--;
        }
    }
}