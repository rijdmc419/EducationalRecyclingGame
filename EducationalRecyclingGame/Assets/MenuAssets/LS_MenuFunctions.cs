﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventSystem;
using UnityEngine.SceneManagement;

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

}

