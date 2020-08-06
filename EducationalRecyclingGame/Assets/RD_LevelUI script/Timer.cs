using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // for timer
    public Text timer;
    public Slider truck;
    public Text highScore;
    float timeleft = SendInfo.NUMSECONDS;
    string time_text;

    // for dev shortcut to end level
    bool fastComplete = false;

    // for level complete menu
    public GameObject levelCompleteCanvas;
    public Text levelCompleteTitle;
    public Text finalLevelScore;

    // list of item prefabs on screen at end of level
    DragAndDrop[] items;

    // game over canvas
    public GameObject gameOverCanvas;

    // bins
    public GameObject trashBin;
    public GameObject recycleBin;
    public GameObject glassBin;
    public GameObject compostBin;

    void Start() {

        // sets levelCompleteCanvas to false upon start
        levelCompleteCanvas.SetActive(false);

        // makes the truck timer non-interactable
        truck.interactable = false;

        // adjusts which bins are visible on the scene
        ChangeBins();

        // changes the time left displayed every second
        InvokeRepeating("Countdown", 0f, 1f);

        highScore.text = SendInfo.pointArray[SendInfo.levelNumber - 1].ToString();
    }

    void Update() {
        // dev shortcut—-pressing 'f' exits the level
        if (Input.GetKeyDown("f")) {
            fastComplete = true;
        }

        // updates high score text if necessary
        if (SendInfo.points < SendInfo.pointArray[SendInfo.levelNumber-1]) {
            highScore.text = 
                    SendInfo.pointArray[SendInfo.levelNumber-1].ToString();
        }
        else {
            highScore.text = SendInfo.points.ToString();
        }
    }


    void Countdown() {
        /* changes the text on the scene every second
        also completes level when time runs out */

        time_text = timeleft.ToString();
        timer.text = time_text;
        truck.value = 1f - (timeleft / SendInfo.NUMSECONDS);
        Debug.Log("Time" + truck.value.ToString());
        timeleft--;
        if (timeleft <= 0 || fastComplete) {
            LevelComplete(); // level complete sequence begins when timer is 0
        }
    }

    void LevelComplete() {
        /* shows level complete menu and increments the level number */

        // sets levelCompleteCanvas to active
        levelCompleteCanvas.SetActive(true);

        // sets high score if need be
        SetPointArray();

        // saves highest level if applicable
        if (SendInfo.levelNumber == SendInfo.highestLevel) {
            SendInfo.highestLevel++;
        }

        // changes text to be level and score specific
        levelCompleteTitle.text = "Level " + 
            (SendInfo.levelNumber).ToString() + " Complete!";
        finalLevelScore.text = "Score: " + SendInfo.points;

        // resets points to 0
        SendInfo.points = 0;

        // increments level number
        if (SendInfo.levelNumber < 9) {
            SendInfo.levelNumber++;
        }
        else {
            GameOver();
        }
        
        // pauses game
        Time.timeScale = 0;

        // disables drag and drop on all item prefabs
        items = FindObjectsOfType(typeof(DragAndDrop))
            as DragAndDrop[];

        foreach (DragAndDrop item in items) {
            item.enabled = false;
        }


    }

    public void SetPointArray() {
        /* updates high score in pointArray
        called each time the player completes a menu
        and on all "menu" buttons */

        if (SendInfo.pointArray[SendInfo.levelNumber - 1] < SendInfo.points)
        {
            SendInfo.pointArray[SendInfo.levelNumber - 1] = SendInfo.points;
        }
    }

    public void Continue() {
        /* disables the level complete canvas
        and calls LevelUp()
        called when the player clicks the continue
        button on the level complete canvas */

        levelCompleteCanvas.SetActive(false);
        Time.timeScale = 1;

        // resets timer
        timeleft = SendInfo.NUMSECONDS;

        LevelUp();
    }

    void LevelUp() {
        /* changes physical elements displayed */
        
        // changes available bins
        ChangeBins();

        // resets fastComplete bool
        fastComplete = false;
        
        // destroys all item prefabs from the level just completed
        foreach (DragAndDrop item in items) {
            Destroy(item.gameObject);
        }

    }

    void ChangeBins() {
        /* updates binArray static variable and 
        sets the correct bins visible for the level */

        SendInfo.binArray = ArrayOfBinsByLevel(SendInfo.levelNumber);

        // creates an array of bins to facilitate iteration
        GameObject[] allBins = { trashBin, recycleBin, glassBin, compostBin };

        // sets all bins in SendInfo.binArray to active
        foreach (GameObject bin in allBins) {
            if (SendInfo.binArray.Contains(bin.tag)) {
                bin.SetActive(true);
            }
        }
    }

    ArrayList ArrayOfBinsByLevel(int level) {
        /* returns an ArrayList of bins available during the level */

        var bins = new ArrayList();

        // trash and recycling bins are always available
        bins.Add(trashBin.tag);
        bins.Add(recycleBin.tag);

        // adds bins if level is above 3 and/or 4
        if (level > 3) { bins.Add(glassBin.tag); }
        if (level > 4) { bins.Add(compostBin.tag); }

        return bins;
    
    }

    void GameOver() {
        /* activates game complete canvas and deactivates timer.cs */

        // ensures that the level complete canvas cannot be seen
        levelCompleteCanvas.SetActive(false);
        // makes the game complete canvas visible
        gameOverCanvas.SetActive(true);

        // displays highest score achieved for every level
        Text report = gameOverCanvas.transform.GetChild(2).GetComponent<Text>();
        report.text = "Your high scores:\n";

        for (int i=0; i<SendInfo.pointArray.Length; i++) {
            report.text += "Level " + (i+1).ToString() + ": " 
                + SendInfo.pointArray[i] + "\n";
        }

        // deactivates this script
        this.gameObject.GetComponent<Timer>().enabled = false;
    }


}
