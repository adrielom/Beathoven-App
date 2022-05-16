using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuHome : MonoBehaviour
{

    [SerializeField] private Button startGameButton, configButton;

    void Start()
    {
        startGameButton.onClick.AddListener(StartGameScene);
        configButton.onClick.AddListener(ConfigScene);
    }

    private void ConfigScene()
    {
        SceneManager.LoadScene("Configuration");
    }

    private void StartGameScene()
    {
        SceneManager.LoadScene("GuessNote");
    }
}
