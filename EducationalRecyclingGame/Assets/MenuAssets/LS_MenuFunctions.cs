using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LS_MenuFunctions : MonoBehaviour {

    // creates a level number
    public static int levelNumber;

    // sets the player preferences upon opening
    public void Start() {

        if (SendInfo.firstTime) {
            UponStart();
            SendInfo.firstTime = false;
        }
    }

    public void UponStart() {
        /* Gets the current level number, the highest level
        achieved, if the levels are grayed out or not,
        and the high scores for each level */

        // level number
        levelNumber = PlayerPrefs.GetInt("LevelNumber");

        // sets the level number to 1 in case
        // PlayerPrefs has not yet been set
        // (the default int is 0)
        if (levelNumber == 0) {
            levelNumber = 1;
        }

        // highest level
        SendInfo.highestLevel = PlayerPrefs.GetInt("HighestLevel");

        if (SendInfo.highestLevel == 0) {
            SendInfo.highestLevel = 1;
        }

        // only changes if LevelState = 1 because
        // the default of seeAllLevels is false
        if (PlayerPrefs.GetInt("LevelState") == 1) {
            SendInfo.seeAllLevels = true;
        }

        // high scores
        for (int i=0; i<9; i++) {
            int j = PlayerPrefs.GetInt("High Score"+i);
            SendInfo.pointArray[i] = j;
        }
    }

    public void Play() {
        /* switches scene to LevelUI */

        SendInfo.levelNumber = levelNumber;
    	SceneManager.LoadScene(sceneName: "RD_Level_UI");
    }

    public void Quit() {
        /* saves preferences and quits */

        SavePrefs();
    	Application.Quit();
    }

    public void Levels() {
        /* switches to levels scene */

        SceneManager.LoadScene(sceneName: "LS_Choose_Level");
    }

    public void ChooseLevels() {
        /* plays the chosen level of the game */
        levelNumber = Int32.Parse(current.currentSelectedGameObject.name);
        Play();
        
    }

    
    public void Back() {
        /* Changes the scene to the menu */

        SavePrefs();
        UponStart();

        // unpauses the time if necessary
        Time.timeScale = 1;
        SendInfo.gamePlay = false;

        SceneManager.LoadScene(sceneName: "LS_Menu");

        // resets points
        SendInfo.points = 0;

    }

    void SavePrefs() {
        /* saves preferences */

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

    public void Reset() {
        /* resets all preferences to their default state */

        PlayerPrefs.SetInt("LevelNumber", 1);

        PlayerPrefs.SetInt("HighestLevel", 1);

        PlayerPrefs.SetInt("LevelState", 0);
        SendInfo.seeAllLevels = false;

        for (int i=0; i<9; i++) {
            PlayerPrefs.SetInt("High Score"+i, 0);

        }

        UponStart();

    }


}

