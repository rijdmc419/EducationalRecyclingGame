using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    int timeleft = 60;
    string time_text;

    // Start is called before the first frame update
    void Start()
    {
        //timer = GetComponent<Text>();
        InvokeRepeating("Countdown", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Countdown()
    {
        time_text = timeleft.ToString();
        timer.text = time_text;
        print(timeleft);
        timeleft--;
    }
}
