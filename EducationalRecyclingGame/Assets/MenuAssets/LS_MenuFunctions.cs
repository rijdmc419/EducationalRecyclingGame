using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LS_MenuFunctions : MonoBehaviour {
    // Start is called before the first frame update
    public static int levelNumber;

    // sets the player preferences upon opening
    public void Start() {
        levelNumber = PlayerPrefs.GetInt("LevelNumber");
        if (levelNumber == 0) {
            levelNumber = 1;
        }

        // if (PlayerPrefs.GetInt("AudioState") >= 0) {
        //     SendInfo.audioToggleState = true;
        // }
        // else if (PlayerPrefs.GetInt("AudioState") == -1) {
        //     SendInfo.audioToggleState = false;
        // }

    }

    // switches scene to LevelUi
    public void Play() {
        SendInfo.levelNumber = levelNumber;
    	SceneManager.LoadScene(sceneName: "RD_Level_UI");
    }

    // switches scene to options menu
    public void Options() {
    	SceneManager.LoadScene(sceneName: "LS_Options_Scene");
    }

    // saves preferences and quits
    public void Quit() {
        SavePrefs();
    	Application.Quit();
    }

    // switches to levels scene
    public void Levels() {
        SceneManager.LoadScene(sceneName: "LS_Choose_Level");
    }

    // plays the chosen level of the game
    public void ChooseLevels() {
        levelNumber = Int32.Parse(current.currentSelectedGameObject.name);
        Play();
    }

    // USE FOR ALL BACK ARROWS
    public void Back() {
        if (current.currentSelectedGameObject.name == "Back") {
            SceneManager.LoadScene(sceneName: "LS_Options_Scene");
        }
        else {
            SceneManager.LoadScene(sceneName: "LS_Menu");
        }
    }

    // not sure if we really need this function (it's for the audio toggle)
    public void Toggle(string name) {
        GameObject toggle = GameObject.Find(name);
        SendInfo.audioToggleState = toggle.GetComponent<Toggle>().isOn;
        
    }

    // saves level number to preferences
    // note: add high score etc
    void SavePrefs() {
        PlayerPrefs.SetInt("LevelNumber", SendInfo.levelNumber);
        // using 1 and -1 to differentiate from 0 (the default int)
        // if (SendInfo.audioToggleState is true) {
        //     PlayerPrefs.SetInt("AudioState", 1);
        // }
        // else {
        //     PlayerPrefs.SetInt("AudioState", -1);
        // }
        PlayerPrefs.Save();
    }

}

