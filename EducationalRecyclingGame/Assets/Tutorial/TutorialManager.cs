using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    bool tutorialIsNow;
    public GameObject tutorialLvl3Item;
    GameObject continueButton;

    void Start()
    {
        continueButton = transform.GetChild(transform.childCount - 1).gameObject;

        tutorialLvl3Item.SetActive(false);
        
        startTutorial();
        
    }
    
    public void startTutorial()
    {
        tutorialIsNow = true;
        int level = SendInfo.levelNumber;

        //we only have tutorials through level 6... so if it's later, there shouldn't be one
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

            levelSpecific();

            //you shouldn't be able to drag around on screen items at the beginning of the tutorial (no matter the level)
            DragAndDrop[] onScreenItems = FindObjectsOfType(typeof(DragAndDrop)) as DragAndDrop[];
            for (int ii = 0; ii < onScreenItems.Length; ii++)
            {
                onScreenItems[ii].enabled = false;
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

        //enable drag and drop on items
        DragAndDrop[] onScreenItems = FindObjectsOfType(typeof(DragAndDrop)) as DragAndDrop[];
        for (int ii = 0; ii < onScreenItems.Length; ii++)
        {
            onScreenItems[ii].enabled = true;
        }


        Time.timeScale = 1;
        tutorialIsNow = false;

        SendInfo.gamePlay = true;
    }

    void Update()
    {
        //really specific if statement: if it's the lvl 3 tutorial and the milk carton has been right clicked (so it's tag is now plastic)
        //turn on the continue button
        if(tutorialIsNow && SendInfo.levelNumber == 3 && tutorialLvl3Item.tag == Constants.TAG_PLASTIC)
        {
            continueButton.gameObject.SetActive(true);
        }
    }

    //Any level specific override things should go in here
    void levelSpecific()
    {
        if (SendInfo.levelNumber == 3)
        {
            continueButton.SetActive(false);//hid the continue button
            tutorialLvl3Item.SetActive(true); //activate the milk carton
        }

        
    }

    //Start of each tutorial should be triggered in "Timer"
    //each tutorial should have a button that triggers the end of the text (or start of new text)
}
