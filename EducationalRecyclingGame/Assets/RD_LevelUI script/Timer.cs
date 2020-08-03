using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // for timer
    public Text timer;
    int timeleft = SendInfo.NUMSECONDS;
    string time_text;
    bool fastComplete = false;

    // for level complete menu
    public GameObject levelCompleteCanvas;
    public Text levelCompleteTitle;
    public Text finalLevelScore;

    // bins
    public GameObject trashBin;
    public GameObject recycleBin;
    public GameObject glassBin;
    public GameObject compostBin;

    // 
    void Start() {

        // sets levelCompleteCanvas to false upon start
        levelCompleteCanvas.SetActive(false);

        // adjusts which bins are visible on the scene
        ChangeBins();

        // changes the time left displayed every second
        InvokeRepeating("Countdown", 0f, 1f);
    }

    void Update() {
        // dev shortcut—-pressing 'f' exits the level
        if (Input.GetKeyDown("f")) {
            fastComplete = true;
        }
    }


    void Countdown() {
        // changes the text on the scene every second
        // also levels up when time runs out
        time_text = timeleft.ToString();
        timer.text = time_text;
        timeleft--;
        if (timeleft <= 0 || fastComplete) {
            LevelComplete();
        }
    }

    void LevelUp() {
        
        // changes bins
        ChangeBins();

        // resets timer
        timeleft = SendInfo.NUMSECONDS;

        // resets fastComplete
        fastComplete = false;
        
        // destroyes all current item prefabs
        DragAndDrop[] items = FindObjectsOfType(typeof(DragAndDrop))
            as DragAndDrop[];

        foreach (DragAndDrop item in items) {
            Destroy(item.gameObject);
        }



    }

    void LevelComplete() {
        // sets levelCompleteCanvas to active
        levelCompleteCanvas.SetActive(true);

        // increments level number
        SendInfo.levelNumber++;

        // pauses time
        Time.timeScale = 0;

        // changes text to be level and score specific
        levelCompleteTitle.text = "Level " + 
            (SendInfo.levelNumber-1).ToString() + " Complete!";
        finalLevelScore.text = "Score: " + SendInfo.points;

    }

    public void Continue() {
        // the continue button on the levelCompleteCanvas
        // continues the game
        levelCompleteCanvas.SetActive(false);
        Time.timeScale = 1;

        LevelUp();
    }

    ArrayList ArrayOfBinsByLevel(int level) {
        // returns an ArrayList of bins available during the level

        var bins = new ArrayList();

        // trash and recycling bins are always available
        bins.Add("Trash");
        bins.Add("Recycling");

        // adds bins if level is above 3 and/or 4
        if (level > 3) { bins.Add("Glass"); }
        if (level > 4) { bins.Add("Compost"); }

        return bins;
    
    }

    void ChangeBins() {
        // updates binArray static var
        SendInfo.binArray = ArrayOfBinsByLevel(SendInfo.levelNumber);

        // creates an array of bins to facilitate iteration
        GameObject[] allBins = { trashBin, recycleBin, glassBin, compostBin };

        // sets all bins to not active
        foreach (GameObject bin in allBins) {
            bin.SetActive(false);
        }

        // if the bin is in binArray, sets bin to active
        foreach (string binStr in SendInfo.binArray) {
            foreach (GameObject bin in allBins) {
                if (bin.name.Contains(binStr)) {
                    bin.SetActive(true);
                }
            }
        }
    }

}
