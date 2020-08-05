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

        if (SendInfo.firstTime) {
            UponStart();
            SendInfo.firstTime = false;
        }
    }

    public void UponStart() {
        levelNumber = PlayerPrefs.GetInt("LevelNumber");

        if (levelNumber == 0) {
            levelNumber = 1;
        }

        SendInfo.highestLevel = PlayerPrefs.GetInt("HighestLevel");

        if (SendInfo.highestLevel == 0) {
            SendInfo.highestLevel = 1;
        }
        
        if(levelNumber == 0)
        {
            levelNumber = 1;
        }

        // only changes if LevelState = 1 because
        // the default of seeAllLevels is false
        if (PlayerPrefs.GetInt("LevelState") == 1) {
            SendInfo.seeAllLevels = true;
        }

        for (int i=0; i<9; i++) {
            int j = PlayerPrefs.GetInt("High Score"+i);
            SendInfo.pointArray[i] = j;
        }
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

    // Changes the scene to the previous scene
    public void Back() {
        SavePrefs();
        UponStart();
        Time.timeScale = 1;
        if (current.currentSelectedGameObject.name == "Back") {
            SceneManager.LoadScene(sceneName: "LS_Options_Scene");
        }
        else {
            SceneManager.LoadScene(sceneName: "LS_Menu");
            SendInfo.points = 0;
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
        // saving level number
        PlayerPrefs.SetInt("LevelNumber", SendInfo.levelNumber);

        // saving highest level
        PlayerPrefs.SetInt("HighestLevel", SendInfo.highestLevel);
        
        // using 0 as false, 1 as true
        if (SendInfo.seeAllLevels) {
            PlayerPrefs.SetInt("LevelState", 1);
        }
        else {
            PlayerPrefs.SetInt("LevelState", 0);
        }

        // saving high score array
        for (int i=0; i<9; i++) {
            PlayerPrefs.SetInt("High Score"+i, SendInfo.pointArray[i]);

        }

        PlayerPrefs.Save();
    }

}

