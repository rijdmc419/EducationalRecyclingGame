﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFunctions : MonoBehaviour
{
    void Start()
    {
        StartTutorial(1);
    }
    public void StartTutorial(int level)
    {
        Time.timeScale = 0;
        for (int ii = 0; ii < transform.childCount; ii++){
            if(transform.GetChild(ii).gameObject.tag == Constants.TAG_TUTORIALUI)
            {
                ////activate button
                transform.GetChild(ii).gameObject.SetActive(true);
            }
            else if(ii == level - 1)
            {
                //activate text/panel
                transform.GetChild(ii).gameObject.SetActive(true);
            }else
            {
                //deactivate other text/panels
                transform.GetChild(ii).gameObject.SetActive(false);
            }
        }    
    }
    
    public void EndTutorial()
    {  
        //deactivate tutorial stuff, including button
        for (int ii = 0; ii < transform.childCount; ii++){
            transform.GetChild(ii).gameObject.SetActive(false);
        }
        Time.timeScale = 1;
    }

    //Start of each tutorial should be triggered in level completion in "Timer"
    //each tutorial should have a button that triggers the end of the text (or start of new text)
}
