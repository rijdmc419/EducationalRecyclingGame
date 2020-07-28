using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LS_MenuFunctions : MonoBehaviour {
    // Start is called before the first frame update
    public static int levelNumber = 1;

    public void Play() {
        
        SendInfo.levelNumber = levelNumber;
    	SceneManager.LoadScene(sceneName: "RD_Level_UI");
    }

    public void Options() {
    	SceneManager.LoadScene(sceneName: "LS_Options_Scene");
    }

    public void Quit() {
        Save();
    	Application.Quit();
    }

    public void Levels() {
        SceneManager.LoadScene(sceneName: "LS_Choose_Level");
    }

    public void ChooseLevels() {
        levelNumber = Int32.Parse(current.currentSelectedGameObject.name);
        Play();
    }

    public void Back() {
        if (current.currentSelectedGameObject.name == "Back") {
            SceneManager.LoadScene(sceneName: "LS_Options_Scene");
        }
        else {
            SceneManager.LoadScene(sceneName: "LS_Menu");
        }
    }

    public void Toggle(string name) {
        GameObject toggle = GameObject.Find(name);
        SendInfo.audioToggleState = toggle.GetComponent<Toggle>().isOn;
        
    }

    void Save() {
        PlayerPrefs.SetInt("LevelNumber", SendInfo.levelNumber);
        if (SendInfo.audioToggleState is true) {
            PlayerPrefs.SetInt("AudioState", 1);
        }
        else {
            PlayerPrefs.SetInt("AudioState", 0);
        }
    }

}

