namespace Beathoven.Core.ScoreSystem
{
    using Beathoven.Core.GuessNote;
    using UnityEngine;
    using TMPro;
    using Beathoven.Utils;
    using Unity.VectorGraphics;
    using System.Linq;

    public class ScoreState : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _multiplierText;
        [SerializeField] private uint _score;
        [SerializeField] private uint _multiplier;
        [SerializeField] private uint _attempts;
        [SerializeField] private GameObject _attemptsHeartsParentElement;
        private UIHeartAttemptManager _uIHeartAttemptManager;

        public uint Attempts
        {
            get => _attempts; set
            {
                _attempts = value;
                _uIHeartAttemptManager.UpdateHearts((int)_attempts);
            }
        }

        void Awake()
        {
            _uIHeartAttemptManager = new UIHeartAttemptManager(_attemptsHeartsParentElement.GetComponentsInChildren<SVGImage>().ToList());
            Attempts = Configs.DEFAULT_GUESSING_ATTEMPTS;
            UIButtonNoteGuesser.onRightNoteSelected += HandleIncreaseScore;
            UIButtonNoteGuesser.onWrongNoteSelected += HandleResetMultiplier;
            UIButtonNoteGuesser.onWrongNoteSelected += HandleDecreaseAttempts;
            UIButtonNoteGuesser.onWrongNoteSelected += HandleUpdateAttempstUI;
        }

        void Update()
        {
            UpdateUIText();
        }

        void HandleUpdateAttempstUI()
        {
            _uIHeartAttemptManager.UpdateHearts((int)Attempts);
        }

        void UpdateUIText()
        {
            _scoreText.text = _score.ToString();
            _multiplierText.text = _multiplier > 1 ? $"x{_multiplier}" : "";
        }

        void HandleIncreaseScore()
        {
            if (_score % 10 == 0 && _multiplier <= 5) _multiplier++;
            uint amount = _multiplier == 0 ? 1 : 1 * _multiplier;
            _score += amount;
        }

        void HandleResetMultiplier()
        {
            _multiplier = 0;
        }

        void HandleDecreaseAttempts()
        {
            _attempts--;
        }
    }
}