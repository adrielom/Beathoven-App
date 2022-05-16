using System;
using System.Collections;
using System.Collections.Generic;
using Beathoven.Utils;
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
        SceneManager.LoadScene(Configs.DEFAULT_ROUTE_CONFIG_MENU);
    }

    private void StartGameScene()
    {
        SceneManager.LoadScene(Configs.DEFAULT_ROUTE_GUESS_NOTE);
    }
}
