using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    bool tutorialIsNow;

    void Start()
    {
        startTutorial();
        
    }
    
    public void startTutorial()
    {
        tutorialIsNow = true;
        int level = SendInfo.levelNumber;

        levelSpecific();

        if (level < 7) {

            Time.timeScale = 0;
            for (int ii = 0; ii < transform.childCount; ii++){
                if(transform.GetChild(ii).gameObject.tag == Constants.TAG_TUTORIALUI)
                {
                    ////activate button
                    transform.GetChild(ii).gameObject.SetActive(true);
                }
                else if(ii == level -1)
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
        else {
            endTutorial();
        }
        
    }
    
    public void endTutorial()
    {  
        //deactivate tutorial stuff, including button
        for (int ii = 0; ii < transform.childCount; ii++){
            transform.GetChild(ii).gameObject.SetActive(false);
        }
        Time.timeScale = 1;
        tutorialIsNow = false;
    }

    void Update()
    {
 
    }

    void levelSpecific()
    {
        if(SendInfo.levelNumber == 3)
        {
            transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);//hid the continue button
        }
    }

    //Start of each tutorial should be triggered in "Timer"
    //each tutorial should have a button that triggers the end of the text (or start of new text)
}
