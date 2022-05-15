namespace Beathoven.Core.ScoreSystem
{
    using Beathoven.Core.GuessNote;
    using UnityEngine;
    using TMPro;
    using Beathoven.Utils;
    using Unity.VectorGraphics;
    using System.Linq;
    using Beathoven.Core.Staff;

    public class ScoreState : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _multiplierText;
        [SerializeField] private uint _multiplier;
        [SerializeField] private uint _attempts;
        [SerializeField] private GameObject _attemptsHeartsParentElement;
        [SerializeField] private Staff staff;
        [SerializeField] private GameObject scene;
        public static uint Score { get; set; }

        public uint Attempts
        {
            get => _attempts; set
            {
                _attempts = value;
                _uIHeartAttemptManager.UpdateHearts((int)_attempts);
            }
        }
        private UIHeartAttemptManager _uIHeartAttemptManager;

        void Awake()
        {
            _uIHeartAttemptManager = new UIHeartAttemptManager(_attemptsHeartsParentElement.GetComponentsInChildren<SVGImage>().ToList());
            Attempts = Configs.DEFAULT_GUESSING_ATTEMPTS;
            UIButtonNoteGuesser.onRightNoteSelected += HandleIncreaseScore;
            UIButtonNoteGuesser.onWrongNoteSelected += HandleResetMultiplier;
            UIButtonNoteGuesser.onWrongNoteSelected += HandleDecreaseAttempts;
            UIButtonNoteGuesser.onWrongNoteSelected += HandleUpdateAttempstUI;
            NoteGuesser.OnInitialize += ResetState;
        }

        public void ResetState()
        {
            Attempts = Configs.DEFAULT_GUESSING_ATTEMPTS;
            scene.GetComponent<Animator>().Play("InitialState");
            Score = 0;
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
            _scoreText.text = Score.ToString();
            _multiplierText.text = _multiplier > 1 ? $"x{_multiplier}" : "";
        }

        void HandleIncreaseScore()
        {
            if (Score % 10 == 0 && _multiplier <= 5) _multiplier++;
            uint amount = _multiplier == 0 ? 1 : 1 * _multiplier;
            Score += amount;
        }

        void HandleResetMultiplier()
        {
            _multiplier = 0;
        }

        void HandleDecreaseAttempts()
        {
            _attempts--;
            if (_attempts <= 0)
            {
                staff.gameType.OnGameEnd();
            }
        }
    }
}