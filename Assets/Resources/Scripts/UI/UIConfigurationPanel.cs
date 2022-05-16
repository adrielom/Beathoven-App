using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Beathoven.Core.Staff;
using Beathoven.Core.Clef;
using UnityEngine.SceneManagement;
using Beathoven.Utils;

public class UIConfigurationPanel : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Button backButton;
    private ClefFactory factory = new ClefFactory();

    void Start()
    {
        dropdown.value = PlayerPrefs.GetInt(Configs.DEFAULT_PLAYER_PREFS_KEY_SELECTED_CLEF, 0);
        dropdown.onValueChanged.AddListener(SetCleff);
        backButton.onClick.AddListener(HandleBackButton);
    }

    private void HandleBackButton()
    {
        SceneManager.LoadScene(Configs.DEFAULT_ROUTE_HOME_MENU);
    }

    private void SetCleff(int index)
    {
        Staff.clef = factory.GetCleffByEnumerationIndex(index);
        PlayerPrefs.SetInt(Configs.DEFAULT_PLAYER_PREFS_KEY_SELECTED_CLEF, index);
    }
}
