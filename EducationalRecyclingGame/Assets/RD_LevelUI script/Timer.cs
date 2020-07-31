using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    int timeleft = SendInfo.NUMSECONDS;
    string time_text;
    public GameObject levelCompleteCanvas;
    public Text levelCompleteTitle;
    public Text finalLevelScore;


    // Start is called before the first frame update
    void Start() {
        //timer = GetComponent<Text>();
        levelCompleteCanvas.SetActive(false);
        InvokeRepeating("Countdown", 0f, 1f);
    }

    void Countdown() {
        time_text = timeleft.ToString();
        timer.text = time_text;
        // print(timeleft);
        timeleft--;
        if (timeleft == 0) {
            LevelUp();
        }
    }

    void LevelUp() {
        SendInfo.levelNumber++;
        timeleft = SendInfo.NUMSECONDS;
        DragAndDrop[] items = FindObjectsOfType(typeof(DragAndDrop))
            as DragAndDrop[];

        foreach (DragAndDrop item in items) {
            Destroy(item.gameObject);
        }

        LevelComplete();


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
    }

}
