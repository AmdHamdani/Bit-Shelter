﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    public Button playButton;
    public Button settingButton;
    public Button aboutButton;
    public Text levelSelect;
    public Button reduceButton;
    public Button addButton;
    public Button backAboutButton;
    public Text loadingText;

    private int levelNumber = 1;
    private BackButtonController back;

    private void Start()
    {
        back = GetComponent<BackButtonController>();

        settingButton.onClick.AddListener(() => back.ChangeMenu(MenuType.Setting));
        aboutButton.onClick.AddListener(() => back.ChangeMenu(MenuType.About));
        backAboutButton.onClick.AddListener(() => back.ChangeMenu(MenuType.Main));
        addButton.onClick.AddListener(() => { levelNumber++; UpdateText(); });
        playButton.onClick.AddListener(() => {
            back.ChangeMenu(MenuType.Loading);
            loadingText.text = "Loading Level " + levelNumber;
            StartCoroutine(Fun.LoadSceneAsync("Level " + GlobalConfig.CurrentLevel, 1f
                ,(progress) => Debug.Log("Loading : " + progress)));
        });
        reduceButton.onClick.AddListener(() => { 
            if(levelNumber > 1) {
                levelNumber--; 
                levelSelect.text = levelNumber.ToString(); 
            }
        });
    }

    private void UpdateText() {
        levelSelect.text = levelNumber.ToString();
    }

}
