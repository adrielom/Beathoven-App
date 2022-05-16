using Beathoven.Core.GuessNote;
using Beathoven.Core.ScoreSystem;
using Beathoven.Core.Staff;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEndGamePanel : MonoBehaviour
{
    [SerializeField] private Button PlayAgainButton, HomeButton;
    [SerializeField] private TMP_Text scoreMessage;
    void Awake()
    {
        PlayAgainButton.onClick.AddListener(PlayAgain);
        HomeButton.onClick.AddListener(GoToHome);
    }

    void Update()
    {
        scoreMessage.text = $"<b>Game Over!</b>\n\nYou got {ScoreState.Score} points!\n\n";
    }

    void PlayAgain()
    {
        NoteGuesser.OnInitialize();
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
