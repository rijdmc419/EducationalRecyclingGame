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

    // for level complete menu
    public GameObject levelCompleteCanvas;
    public Text levelCompleteTitle;
    public Text finalLevelScore;

    // tutorial menu script
    // public GameObject TutorialCanvas;

    // bins
    public GameObject trashBin;
    public GameObject recycleBin;
    public GameObject glassBin;
    public GameObject compostBin;

    // Start is called before the first frame update
    void Start() {
        //timer = GetComponent<Text>();
        levelCompleteCanvas.SetActive(false);
        SendInfo.binArray = ArrayOfBinsByLevel(SendInfo.levelNumber);
        ChangeBins();
        // TutorialCanvas.GetComponent<TutorialManager>.startTutorial(SendInfo.levelNumber);
        InvokeRepeating("Countdown", 0f, 1f);
    }


    void Countdown() {
        time_text = timeleft.ToString();
        timer.text = time_text;
        // print(timeleft);
        timeleft--;
        if (timeleft <= 0) {
            LevelUp();
        }
    }

    void LevelUp() {
        SendInfo.levelNumber++;
        SendInfo.binArray = ArrayOfBinsByLevel(SendInfo.levelNumber);

        LevelComplete();
        
        ChangeBins();

        timeleft = SendInfo.NUMSECONDS;
        
        DragAndDrop[] items = FindObjectsOfType(typeof(DragAndDrop))
            as DragAndDrop[];

        foreach (DragAndDrop item in items) {
            Destroy(item.gameObject);
        }



    }

    void LevelComplete() {
        levelCompleteCanvas.SetActive(true);
        Time.timeScale = 0;
        levelCompleteTitle.text = "Level " + 
            (SendInfo.levelNumber-1).ToString() + " Complete!";
        finalLevelScore.text = "Score: " + SendInfo.points;

    }

    public void Continue() {
        levelCompleteCanvas.SetActive(false);
        Time.timeScale = 1;
        // tutorial.startTutorial(SendInfo.levelNumber);
    }

    ArrayList ArrayOfBinsByLevel(int level) {
        // returns an ArrayList of bins available during the level

        var bins = new ArrayList();
        bins.Add("Trash");
        bins.Add("Recycling");

        // if (level > 1) { bins.Add("Paper"); bins.Add("Plastic"); }
        // if (level > 2) { bins.Add("Metal"); }
        if (level > 3) { bins.Add("Glass"); }
        if (level > 4) { bins.Add("Compost"); }

        return bins;
    
    }

    void ChangeBins() {
        GameObject[] allBins = { trashBin, recycleBin, glassBin, compostBin };

        foreach (GameObject bin in allBins) {
            bin.SetActive(false);
        }

        foreach (string binStr in SendInfo.binArray) {
            foreach (GameObject bin in allBins) {
                if (bin.name.Contains(binStr)) {
                    bin.SetActive(true);
                }
            }
        }
    }

}
